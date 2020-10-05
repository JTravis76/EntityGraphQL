using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityGraphQL.Authorization
{
    //public static class AuthorizationExt
    //{
    //    public static Schema.Field WithAuthorization(this Schema.Field field, params string[] policy)
    //    {
    //        field.Policy = policy;
    //        return field;
    //    }        
    //}

    //public struct GraphQLAuthorize
    //{
    //    public static bool IsAuthorize(Schema.ISchemaProvider schemaProvider, string name, string contextName)
    //    {
    //        Schema.Field field = null;
    //        string[] userRoles = schemaProvider.User.Roles;

    //        if (schemaProvider.Type("DataContext").HasField(name))
    //        {
    //            field = schemaProvider.Type("DataContext").GetField(name);

    //            if ((field != null && field.Policy == null) || (field.Policy != null && userRoles.Any(x => field.Policy.Contains(x))))
    //                return true;

    //            throw new Schema.EntityQuerySchemaError($"Not authorize to access '{name}' field.");
    //        }
    //        else
    //        {
    //            bool hasMember = false;

    //            try
    //            {
    //                //could be member and not field
    //                hasMember = schemaProvider.Type(contextName).HasField(name);                   
    //            }
    //            catch (Exception) { }

    //            if (hasMember)
    //            {
    //                field = schemaProvider.Type(contextName).GetField(name);

    //                if ((field != null && field.Policy == null) || (field.Policy != null && userRoles.Any(x => field.Policy.Contains(x))))
    //                    return true;

    //                throw new Schema.EntityQuerySchemaError($"Not authorize to access '{name}' field.");
    //            }
    //        }

    //        return true;
    //    }

    //    public static bool IsAuthorize(QueryRequest request, Schema.ISchemaProvider schemaProvider)
    //    {
    //        /* Authorization Rules:
    //        * Allow "Introspection Query"
    //        * Allow "Authentication mutation
    //        * If Fields/Mutation as policy, test it against SchemaProvider's Roles
    //        */

    //        //TODO: Known Bug!! Can bypass authorization by placing the word "__schema is comments !!
    //        bool isIntrospection = request.Query.Contains("__schema {") && request.Query.Contains(" IntrospectionQuery ");
    //        bool isMutation = request.Query.Contains("mutation");
    //        bool isAuthentication = isMutation && request.Query.Contains("authentication");

    //        string[] userRoles = schemaProvider.User.Roles;
    //        string[] policies = null;
    //        string rootField = "";

    //        //TODO: Not a fan of parsing like this, since already using Ant
    //        //parse out the root field from query
    //        string q = request.Query.Replace(Environment.NewLine, "").Replace("\n", "");
    //        string[] d = q.Split('{');
    //        rootField = d[1].Trim();

    //        //check if root fields has parameters
    //        if (rootField.Contains("("))
    //        {
    //            d = rootField.Split('(');
    //            rootField = d[0];
    //        }

    //        if (!isMutation)
    //        {
    //            Schema.Field field = schemaProvider.Type("DataContext").GetField(rootField);
    //            if (field != null)
    //                policies = field.Policy;
    //        }
    //        else
    //        {
    //            Schema.MutationType mutation = (Schema.MutationType)schemaProvider.GetMutations()
    //                .FirstOrDefault(x => x.Name == rootField);

    //            if (mutation != null)
    //                policies = mutation.Policy;
    //        }

    //        if (isIntrospection || isAuthentication || policies == null || policies.Length == 0 || (policies.Length > 0 && userRoles.Any(x => policies.Contains(x))))
    //            return true;


    //        throw new Schema.EntityQuerySchemaError($"Not authorize to access '{rootField}' field/mutation.");
    //    }
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    //public class GraphQLAutorizeAttribute : Attribute
    //{
    //    internal string Policy = "";

    //    public GraphQLAutorizeAttribute(params string[] Roles) => Policy = $"{string.Join(",", Roles)}";
    //}
}

namespace EntityGraphQL.Schema
{
    //public partial class Field
    //{
    //    /// <summary>
    //    /// Collection of policies or roles
    //    /// </summary>
    //    public string[] Policy { get; set; }
    //}

    //public partial class MutationType
    //{
    //    /// <summary>
    //    /// Collection of policies or roles
    //    /// </summary>
    //    public string[] Policy { get; set; }
    //}
}