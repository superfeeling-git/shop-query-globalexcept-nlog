using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class OrderGoods
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public int OrderId { get; set; }
        public int BuyCount { get; set; }
        public Goods Goods { get; set; }
        public Order Order { get; set; }
    }
}
