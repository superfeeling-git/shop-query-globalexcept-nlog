using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using NLog;
using Shop.DAL;
using Shop.Model;

namespace Shop.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public IHttpActionResult GetOrder(string UserName = null, string userId = null, string GoodsName = null, string GoodsCode = null, string OrderCode = null, DateTime? StartTime = null, DateTime? EndTime = null, int PageIndex = 1, int PageSize = 10)
        {
            OrderDAL orderDAL = new OrderDAL();

            var order = orderDAL.GetOrder(UserName, userId, GoodsName, GoodsCode, OrderCode, StartTime, EndTime, PageIndex, PageSize);

            return Json(order);
        }

        [HttpGet]
        public IHttpActionResult Test(string str = null)
        {
            _logger.Info("测试信息");

            if(str == "abc")
            {
                throw new Exception("这是一个异常测试");
            }
            
            return Ok();
        }
    }
}
