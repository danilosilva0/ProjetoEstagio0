using ControleTarefas.Helper.Messages;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace ControleTarefas.WebApi.Middleware
{
    public class ApiMiddleware
    {
        public ApiMiddleware()
        {
            
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }catch (Exception ex)
            {
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
                    messages.Add(InfraMessages);
                    break;
            }

            await response.WriteAsync(JsonConvert.SerializeObject(new DefaultResponse(HttpStatusCode.InternalServerError,messages)));
        }
    }
}
