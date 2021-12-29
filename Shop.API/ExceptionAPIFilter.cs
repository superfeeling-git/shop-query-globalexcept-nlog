using NLog;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Shop.API
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class ExceptionAPIFilter : IExceptionFilter
    {
        private readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        public bool AllowMultiple => true;

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var ex = actionExecutedContext.Exception.InnerException ?? actionExecutedContext.Exception;
            return Task.Run(() =>
            {
                string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
                string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                string param = actionExecutedContext.Request.Method.ToString();
                //记录日志
                _logger.Error(DateTime.Now + string.Format(" Location：{0}/{1} Param：{2} UserIP：{3} Exception：{4}", controllerName, actionName, param, "", ex.Message));
                var result = new ResultInfo { code = 999, msg = ex.Message};
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);

                HttpResponseMessage httpResponse = new HttpResponseMessage();
                HttpContent httpContent = new StringContent(json);
                httpResponse.Content = httpContent;
                actionExecutedContext.Response = httpResponse;
            });
        }
    }
}