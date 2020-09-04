using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MVCPractice.WebForms.ViewPages
{
    /// <summary>
    /// BaseHandler 的摘要说明
    /// </summary>
    public class BaseHandler : IHttpHandler
    {
        
        public void ProcessRequest(HttpContext context)
        {
            var action = context.Request["action"].ToString();
            MethodInfo method = GetType().GetMethod(action);
            method?.Invoke(this, new object[] { context });
            context.Response.ContentType = "text/plain";
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}