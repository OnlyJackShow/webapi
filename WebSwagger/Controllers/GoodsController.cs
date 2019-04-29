using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebSwagger.DAL;
using WebSwagger.Model;

namespace WebSwagger.Controllers
{
    /// <summary>
    /// 商品服务
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : Controller
    {
        /// <summary>
        /// 申明
        /// </summary>
        protected readonly IServiceProvider _serviceProvider;


        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="serviceProvider"></param>
        public GoodsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }



        // GET api/values/5

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet("GetCashrecode")]
        public CashRecodeDto Get(int id)
        {
            var cashrecode = new CashRecodeDto();
            //创建数据中心访问层对象          
            using (var scope = _serviceProvider.CreateScope())
            {
                //创建数据中心访问层对象
                var CashServices = scope.ServiceProvider.GetService<CashServices>();
                cashrecode = CashServices.GetCashrecodeById(11);
            }
            return cashrecode;
        }
    }
}