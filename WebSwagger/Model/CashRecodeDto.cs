using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSwagger.Model
{
    public class CashRecodeDto
    {

        [Key]
        public int Id { get; set; }
        public string CustomerorderNum { get; set; }
        public int CashType { get; set; }
        public int PayType { get; set; }
        public int PayeeId { get; set; }
        public DateTime CashTime { get; set; }
        public int DeptId { get; set; }
        public int CashBoxId { get; set; }
        public double Amounts { get; set; }
        public int isPosting { get; set; }
        public int RedGuid { get; set; }
    }
}
