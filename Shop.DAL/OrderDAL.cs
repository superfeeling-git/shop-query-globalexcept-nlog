using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Dto;
using Shop.Model;
using System.Dynamic;
using System.Linq.Dynamic.Core;

namespace Shop.DAL
{
    public class OrderDAL
    {
        /// <summary>
        /// 联查方式实现
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="userId"></param>
        /// <param name="GoodsName"></param>
        /// <param name="GoodsCode"></param>
        /// <param name="OrderCode"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public (int, List<OrderDto>) GetOrder(string UserName, string userId,string GoodsName, string GoodsCode, string OrderCode, DateTime? StartTime, DateTime? EndTime,int PageIndex = 1,int PageSize=10)
        {
            MyDbContext db = new MyDbContext();

            //用户表、订单表、商品表、订单商品中间表先进行联查
            //可以用linq实现
            var list = db.Users
                .Join(db.Order, a => a.UserId, b => b.UserId, (a, b) => new { a, b })
                .Join(db.OrderGoods, a => a.b.OrderId, b => b.OrderId, (a, b) => new { a, b })
                .Join(db.Goods, a => a.b.GoodsId, b => b.GoodsId, (a, b) => new {a,b});

            #region 条件拼接部分

            if (!string.IsNullOrWhiteSpace(userId))
            {
                list = list.Where(m => m.a.a.a.UserId == new Guid(userId));
            }

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                list = list.Where(m => m.a.a.a.UserId == new Guid(userId));
            }

            if (!string.IsNullOrWhiteSpace(GoodsName))
            {
                list = list.Where(m => m.b.GoodsName.Contains(GoodsName));
            }

            if (!string.IsNullOrWhiteSpace(GoodsCode))
            {
                list = list.Where(m => m.b.GoodsCode.Contains(GoodsCode));
            }

            if (!string.IsNullOrWhiteSpace(OrderCode))
            {
                list = list.Where(m => m.a.a.b.OrderCode == OrderCode);
            }

            if (StartTime != null)
            {
                list = list.Where(m => m.a.a.b.CreateTime > StartTime);
            }

            if (EndTime != null)
            {
                list = list.Where(m => m.a.a.b.CreateTime < EndTime);
            }
            #endregion

            //将查出的数据转换为OrderDto
            var order = db.Order.Select(m => new OrderDto
            {
                //这里是使用linq嵌套查询实现内层的商品信息及购买数量
                OrderGoods = db.Goods.Where(g => m.OrderGoods.Any(a => a.GoodsId == g.GoodsId))
                .Select(s => new GoodsDto
                {
                    GoodsCode = s.GoodsCode,
                    GoodsId = s.GoodsId,
                    GoodsName = s.GoodsName,
                    GoodsPrice = s.GoodsPrice,
                    BuyCount = m.OrderGoods.FirstOrDefault(good=>s.GoodsId == good.GoodsId).BuyCount
                }).ToList(),
                OrderId = m.OrderId,
                OrderCode = m.OrderCode,
                CreateTime = m.CreateTime,
                OrderState = m.OrderState,
                ReceiveName = m.ReceiveName,
                UserId = m.UserId
            })
            .Where(m => list.Select(id => id.a.a.b.OrderId).Contains(m.OrderId));

            //通过安装并引用System.Linq.Dynamic.Core，可以直接使用Page方式即可
            //返回总记录数及分页记录
            return (order.Count(), order.OrderBy(m=>m.OrderId).Page(PageIndex, PageSize).ToList());
        }


        /// <summary>
        /// 联查方式实现
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="userId"></param>
        /// <param name="GoodsName"></param>
        /// <param name="GoodsCode"></param>
        /// <param name="OrderCode"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public (int, List<OrderDto>) GetOrderByForEach(string UserName, string userId, string GoodsName, string GoodsCode, string OrderCode, DateTime? StartTime, DateTime? EndTime, int PageIndex = 1, int PageSize = 10)
        {
            MyDbContext db = new MyDbContext();

            //用户表、订单表、商品表、订单商品中间表先进行联查
            //可以用linq实现
            var list = db.Users
                .Join(db.Order, a => a.UserId, b => b.UserId, (a, b) => new { a, b })
                .Join(db.OrderGoods, a => a.b.OrderId, b => b.OrderId, (a, b) => new { a, b })
                .Join(db.Goods, a => a.b.GoodsId, b => b.GoodsId, (a, b) => new { a, b });

            #region 条件拼接部分

            if (!string.IsNullOrWhiteSpace(userId))
            {
                list = list.Where(m => m.a.a.a.UserId == new Guid(userId));
            }

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                list = list.Where(m => m.a.a.a.UserId == new Guid(userId));
            }

            if (!string.IsNullOrWhiteSpace(GoodsName))
            {
                list = list.Where(m => m.b.GoodsName.Contains(GoodsName));
            }

            if (!string.IsNullOrWhiteSpace(GoodsCode))
            {
                list = list.Where(m => m.b.GoodsCode.Contains(GoodsCode));
            }

            if (!string.IsNullOrWhiteSpace(OrderCode))
            {
                list = list.Where(m => m.a.a.b.OrderCode == OrderCode);
            }

            if (StartTime != null)
            {
                list = list.Where(m => m.a.a.b.CreateTime > StartTime);
            }

            if (EndTime != null)
            {
                list = list.Where(m => m.a.a.b.CreateTime < EndTime);
            }
            #endregion

            //将查出的数据转换为OrderDto
            //这里仅赋值基本类型
            var order = db.Order.Select(m => new OrderDto
            {               
                OrderId = m.OrderId,
                OrderCode = m.OrderCode,
                CreateTime = m.CreateTime,
                OrderState = m.OrderState,
                ReceiveName = m.ReceiveName,
                UserId = m.UserId
            })
            .Where(m => list.Select(id => id.a.a.b.OrderId).Contains(m.OrderId));

            var orderlist = order.OrderBy(m => m.OrderId).Page(PageIndex, PageSize).ToList();

            orderlist.ForEach(m => {
                var g = db.Goods.Join(db.OrderGoods, a => a.GoodsId, b => b.GoodsId, (a, b) => new { a, b })
                .Where(or => or.b.OrderId == m.OrderId).Select(buy => new GoodsDto
                {
                    BuyCount = buy.b.BuyCount,
                    GoodsCode = buy.a.GoodsCode,
                    GoodsId = buy.a.GoodsId,
                    GoodsName = buy.a.GoodsName,
                    GoodsPrice = buy.a.GoodsPrice
                }).ToList();

                m.OrderGoods = g;
            });

            //取得当前页面数据后，再通过ForEach去查询给List赋值
            orderlist.ForEach(m => {
                m.OrderGoods = db.Goods.Join(db.OrderGoods, a => a.GoodsId, b => b.GoodsId, (a, b) => new { a, b })
                .Where(or => or.b.OrderId == m.OrderId).Select(buy => new GoodsDto {
                    BuyCount = buy.b.BuyCount,
                    GoodsCode = buy.a.GoodsCode,
                    GoodsId = buy.a.GoodsId,
                    GoodsName = buy.a.GoodsName,
                    GoodsPrice = buy.a.GoodsPrice
                }).ToList();                
            });

            //通过安装并引用System.Linq.Dynamic.Core，可以直接使用Page方式即可
            //返回总记录数及分页记录
            return (order.Count(), order.OrderBy(m => m.OrderId).Page(PageIndex, PageSize).ToList());
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="GoodsName"></param>
        /// <param name="GoodsCode"></param>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public List<Order> GetOrder(string GoodsName, string GoodsCode, string OrderCode, DateTime? StartTime, DateTime? EnddateTime)
        {
            MyDbContext db = new MyDbContext();

            //查询
            var orders = db.Order.AsQueryable();

            if (!string.IsNullOrWhiteSpace(GoodsName))
            {
                //查询所有包含该商品名称的商品ID的集合    1,2,3
                var goodsId = db.Goods.Where(g => g.GoodsName.Contains(GoodsName)).Select(s => s.GoodsId).ToList();

                orders = orders.Where(m => m.OrderGoods.Select(g => g.GoodsId).Any(a => goodsId.Contains(a)));
            }

            if (!string.IsNullOrWhiteSpace(OrderCode))
            {
                orders = orders.Where(m => m.OrderCode.Contains(OrderCode));
            }

            if(StartTime != null)
            {
                orders = orders.Where(m => m.CreateTime > StartTime);
            }

            if (EnddateTime != null)
            {
                orders = orders.Where(m => m.CreateTime < EnddateTime);
            }

            return orders.ToList();
        }
    }
}
