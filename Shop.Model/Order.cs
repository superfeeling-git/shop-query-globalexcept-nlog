using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderState
    {
        /// <summary>
        /// 未确认
        /// </summary>
        UnConfirm,
        /// <summary>
        /// 已确认
        /// </summary>
        Confirm,
        /// <summary>
        /// 未发货
        /// </summary>
        UnShipping,
        /// <summary>
        /// 已发货
        /// </summary>
        Shipping,
        /// <summary>
        /// 已完成
        /// </summary>
        Success
    }


    public class Order
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
        public virtual List<OrderGoods> OrderGoods { get; set; }
    }
}