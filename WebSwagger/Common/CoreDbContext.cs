using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSwagger.Model;

namespace WebSwagger.Common
{

    /// <summary>
    /// 数据库连接
    /// </summary>
    public class CoreDbContext : DbContext
    {

        /// <summary>
        /// 重载注入
        /// </summary>
        /// <param name="options"></param>
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        { }

        /// <summary>
        /// 对应表信息
        /// </summary>
        public DbSet<CashRecodeDto> cashrecodes { get; set; }
    }
}
