using MVCPractice.WebForms.ViewPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;

namespace MVCPractice.WebForms.NewFolder1
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : BaseHandler
    {
        public void CheckLogin(HttpContext context)
        {
            if (context.Request["username"]=="admin"&&context.Request["password"]=="123")
            {
                context.Response.Write("AshxSuccess");
                context.Response.End();
            }
            else
            {
                context.Response.Write("AshxFailure");
                context.Response.End();
            }
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