using System;
using System.Collections.Generic;
using System.Text;

namespace EntityGraphQL
{
    internal static class GraphQLValidation
    {
        public static List<GraphQLError> Errors { get; set; } = new List<GraphQLError>();
    }
}