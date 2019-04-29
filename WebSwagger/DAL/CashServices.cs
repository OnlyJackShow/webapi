using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSwagger.Common;
using WebSwagger.Model;
using Dapper;

namespace WebSwagger.DAL
{
    /// <summary>
    /// 流水服务
    /// </summary>
    public class CashServices: BaseServices
    {
      

        /// <summary>
        /// 继承
        /// </summary>
        /// <param name="configuration"></param>
        public CashServices(IConfiguration configuration) : base(configuration)
        {
        }

        //BaseServices baseServices = new BaseServices();
        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public  CashRecodeDto GetCashrecodeById(int Id)
        {
            using (var conn = GetConnection())
            {
                CashRecodeDto cashrecode = new CashRecodeDto();
                try
                {
                    string sql = "SELECT Id, CustomerorderNum,CashType,PayType,PayeeId,CashTime,DeptId,CashBoxId,Amounts,isPosting,RedGuid FROM cashrecode  WHERE Id=1";
                    cashrecode = conn.Query<CashRecodeDto>(sql).FirstOrDefault();
                    return cashrecode;
                }
                catch (Exception ex)
                {
                    return cashrecode;
                }
            }
        }
    }
}
