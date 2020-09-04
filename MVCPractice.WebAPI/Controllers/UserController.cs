using MVCPractice.WebAPI.Attributes;
using MVCPractice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MVCPractice.WebAPI.Controllers
{
    [ApiAuthorize]
    [EnableCors("*","*","*")]
    public class UserController : ApiController
    {
        public string Get()
        {
            AuthInfo info = RequestContext.RouteData.Values["auth"] as AuthInfo;
            if (info == null)
            {
                return "获取不到，失败";
            }
            else
            {
                return $"获取到了，auth的name是{info.UserName}";
            }

        }
    }
}
