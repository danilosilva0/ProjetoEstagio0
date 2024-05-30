using ControleTarefas.Helper.Messages;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;
using ControleTarefas.Helper.Response;
using log4net;
using System.Diagnostics;

namespace ControleTarefas.WebApi.Middleware
{
    public class ApiMiddleware : IMiddleware
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(ApiMiddleware));
        public ApiMiddleware()
        {
            
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                await next.Invoke(context);
                stopwatch.Stop();
                _log.InfoFormat("Serviço executado com sucesso: {0} {1} [{2} ms]", context.Request.Method, context.Request.Path, stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _log.Error($"Erro no serviço: {context.Request.Path} / Mensagem: {ex.Message} [{stopwatch.ElapsedMilliseconds}]", ex);
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            var response = context.Response;
            var messages = new List<string>(); 
            response.ContentType = "application/json";

            switch (ex)
            {
                case ServiceException:
                    messages.Add(ex.Message);
                    break;
                default:
                    messages.Add(InfraMessages.UnexpectedError);
                    break;
            }

            await response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse(HttpStatusCode.InternalServerError,messages)));
        }
    }
}
