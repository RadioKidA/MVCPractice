using MVCPractice.Cache.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCPractice.Cache.Redis
{
    class RedisManager:ICache
    {
        public RedisManager()
        {

        }

        private RedisManager _instance;

        public RedisManager Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                
            }
        }

        
    }
}
