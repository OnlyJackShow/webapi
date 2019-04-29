using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebSwagger.Common
{
    /// <summary>
    /// 基础服务
    /// </summary>
    public class BaseServices
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        public  IConfiguration _configuration;

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="configuration"></param>
        public BaseServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 重写
        /// </summary>
        /// <returns></returns>
        public  IDbConnection GetConnection()
        {
            return new MySqlConnection(_configuration.GetValue<string>("ConnectionString:RetailkingDb"));
        }
    }
}
