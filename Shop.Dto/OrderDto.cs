using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class OrderDto
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState OrderState { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceiveName { get; set; }
        /// <summary>
        /// 订单商品
        /// </summary>
        public List<GoodsDto> OrderGoods { get; set; }
    }
}
