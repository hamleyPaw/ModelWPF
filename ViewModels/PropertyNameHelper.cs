using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTemplate.ViewModels
{
    public static class PropertyNameHelper
    {
        public static string GetPropertyName(Expression<Func<object>> expression)
        {
            return GetPropertyNameUntyped(expression);
        }

        public static string GetPropertyNameUntyped(LambdaExpression untypedExpression)
        {
            Expression body = ((LambdaExpression)untypedExpression).Body;

            // if expression if of the form x => (T)x.Property, remove the cast
            if (body.NodeType == ExpressionType.Convert)
            {
                body = ((UnaryExpression)body).Operand;
            }

            return ((MemberExpression)body).Member.Name;
        }
    }
}
