using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using MVCPractice.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web.Http;

namespace MVCPractice.WebAPI.Controllers
{
    public class HomeController : ApiController
    {
        public LoginResult Post([FromBody] LoginRequest request)
        {
            LoginResult rs = new LoginResult();
            if (request.UserName == "wangshibang" && request.Password == "123456")
            {
                AuthInfo info = new AuthInfo { UserName = "wangshibang", Roles = new List<string> { "Admin", "Manage" }, IsAdmin = true };
                try
                {
                    const string secret = "To Live is to change the world";
                    IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                    IJsonSerializer serializer = new JsonNetSerializer();
                    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                    IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                    var token = encoder.Encode(info, secret);

                    rs.Message = "XXXXX";
                    rs.Token = token;
                    rs.Success = true;
                }
                catch (Exception ex)
                {
                    rs.Message = ex.Message;
                    rs.Success = false;
                }
            }
            else
            {
                rs.Message = "fail";
                rs.Success = false;
            }
            return rs;
        }
    }
}
