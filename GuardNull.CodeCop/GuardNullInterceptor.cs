using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCop.Core;
using CodeCop.Core.Contracts;

namespace GuardNull.CodeCop
{
    public class GuardNullInterceptor : ICopIntercept
    {
        public void OnBeforeExecute(InterceptionContext context)
        {
            foreach (var parameter in context.Parameters)
            {
                if (!parameter.IsOptional && (parameter.Value == null || (parameter.Value is string && string.IsNullOrEmpty(parameter.Value.ToString()))))
                {
                    throw new ArgumentNullException(parameter.Name);
                }
            }
        }

        public void OnAfterExecute(InterceptionContext context)
        {

        }
    }
}
