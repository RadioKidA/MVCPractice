using MVCPractice.Cache.Common;
using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Configuration;

namespace MVCPractice.Cache.Redis
{
    class RedisManager:ICache
    {

        private static readonly object _locker = new object();

        /// <summary>
        /// 使用单例模式，确保只有一个redis实例
        /// </summary>
        private static ConnectionMultiplexer _instance;

        /// <summary>
        /// Redis连接池
        /// </summary>
        internal static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionCache = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        /// <summary>
        /// 当前连接的Redis中连接字符串，格式为：127.0.0.1:6379,allowadmin=true,passowrd=pwd
        /// </summary>
        internal static readonly string RedisHostConnection = ConfigurationManager.AppSettings["RedisHostConnection"];

        /// <summary>
        /// 当前连接的Redis中的DataBase索引，默认0-16，可以在service.conf配置，最高64
        /// </summary>
        internal static readonly int RedisDataBaseIndex = int.Parse(ConfigurationManager.AppSettings["RedisDataBaseIndex"]);

        public static ConnectionMultiplexer Instance
        {
            get
            {
                //双检锁创建Redis实例
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                        {
                            _instance = GetManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 尝试在Redis连接池中获取
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString)
        {
            if (!ConnectionCache.ContainsKey(connectionString))
            {
                ConnectionCache[connectionString] = GetManager(connectionString);
            }
            return ConnectionCache[connectionString];
        }

        /// <summary>
        /// 获取Redis连接
        /// </summary>
        /// <param name="connecitonString"></param>
        /// <returns></returns>
        private static ConnectionMultiplexer GetManager(string connecitonString = null)
        {
            connecitonString = connecitonString ?? RedisHostConnection;
            var connect = ConnectionMultiplexer.Connect(connecitonString);

            //注册事件
            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionRestored += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        #region Redis事件

        /// <summary>
        /// 配置更改时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender,EndPointEventArgs e)
        {
            //Todo:添加日志
        }

        /// <summary>
        /// 发生错误时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            //Todo:添加日志
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            //Todo:添加日志
        }

        /// <summary>
        /// 连接失败 ， 如果重新连接成功你将不会收到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            //Todo:添加日志
        }

        /// <summary>
        /// 更改集群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            //Todo:添加日志
        }

        /// <summary>
        /// redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            //Todo:添加日志
        }

        #endregion



    }
}
