using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EntityGraphQL.Security
{
    internal static class Worker
    {
        public static User CreateUser(ClaimsIdentity claims)
        {
            List<Security.Claim> gqlClaims = new List<Security.Claim>();

            if (claims == null)
                return new User(gqlClaims);

            // convert all claims to a security user claim
            foreach (var claim in claims.Claims)
                gqlClaims.Add(new Security.Claim(claim.Type, claim.Value));

            //// fetch all roles from the Claims Principal (like; Window Auth, JWT, etc)
            //var roleClaims = claims.Claims
            //    .Where(x => x.Type == System.Security.Claims.ClaimTypes.Role)
            //    .Select(x => new Security.Claim(System.Security.Claims.ClaimTypes.Role, x.Value));

            //gqlClaims.AddRange(roleClaims);                
            //gqlClaims.Add(new Security.Claim(Security.ClaimTypes.Name, claims.Name));

            //== Also create custom Claims!! == //
            //gqlClaims.Add(new Security.Claim("Email", "a@b.com"));

            return new User(gqlClaims, claims.IsAuthenticated);
        }
    }

    public class User
    {
        private readonly bool _isAuthenticated;
        private readonly IEnumerable<Security.Claim> _claims;

        internal User(IEnumerable<Security.Claim> claims = null, bool IsAuthenticated = false)
        {
            this._isAuthenticated = IsAuthenticated;
            this._claims = claims;
        }

        public string Name { get => Claims.Where(x => x.Type == Security.ClaimTypes.Name).Select(x => x.Value).FirstOrDefault(); }

        public string[] Roles { get => Claims.Where(x => x.Type == Security.ClaimTypes.Role).Select(x => x.Value).ToArray(); }

        public bool IsAuthenticated { get => _isAuthenticated; }

        public IEnumerable<Security.Claim> Claims { get => _claims; }

        public bool IsInRole(params string[] roles)
        {
            return Roles.Any(x => roles.Contains(x));
        }
    }

    public class Claim
    {
        private string _type;
        private string _value;
        private string _valueType;

        public Claim(string type, string value)
            : this(type, value, "http://www.w3.org/2001/XMLSchema#string")
        {
        }

        internal Claim(string type, string value, string valueType)
        {
            this._type = type ?? throw new ArgumentNullException(nameof(type));
            this._value = value ?? throw new ArgumentNullException(nameof(value));
            this._valueType = string.IsNullOrEmpty(valueType) ? "http://www.w3.org/2001/XMLSchema#string" : valueType;
        }

        public string Type
        {
            get { return this._type; }
        }

        public string Value
        {
            get { return this._value; }
        }

        public string ValueType
        {
            get { return this._valueType; }
        }
    }

    public static class ClaimTypes
    {
        public const string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        public const string Name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    }
}