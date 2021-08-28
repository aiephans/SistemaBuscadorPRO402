using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscador.Filters
{
    public class SessionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string sessionId = context.HttpContext.Request.Cookies["sessionId"];
            if (string.IsNullOrEmpty(sessionId) || !sessionId.Equals(context.HttpContext.Session.GetString("sessionId")))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        
    }
}
