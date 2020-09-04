using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPractice.WebAPI.Models
{
    public class AuthInfo
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public bool IsAdmin { get; set; }


    }
}