using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MVCPractice.Config
{
    public class ConfigHelper
    {
        private static IConfigurationRoot _configuration;
        //private static string fullPath;

        static ConfigHelper()
        {

            var fileName = "appsettings.json";

            // 只能获取到客户端执行路径
            // 用test项目调用返回的路径为test项目的启动路径
            // 就离谱
            //var directory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //directory = directory.Replace("\\", "/");


            //fullPath = Path.Combine("/MVCPractice.Config/", fileName);
            //if (!File.Exists(fullPath))
            //{
            //    var length = directory.IndexOf("/bin");
            //    fullPath = $"{directory.Substring(0, length)}/{fileName}";
            //}

            // 蠢办法
            //fullPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("MVCPractice.")));
            //fullPath = Path.Combine(fullPath, "MVCPractice.Config", fileName);

            //var appSettings = ConfigurationManager.AppSettings;

            //var builder = new ConfigurationBuilder().AddJsonFile(fullPath, false, true);
            //_configuration = builder.Build();

            _configuration = new ConfigurationBuilder()
            .AddJsonFile(fileName, true, true)
            .Build();

            
        }

        /// <summary>
        /// 读取设置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ReadSetting(string key)
        {
            return _configuration.GetSection(key).Value;
        }


        //public void WriteUpdateSetting(string key,string value)
        //{

        //}


    }
}
