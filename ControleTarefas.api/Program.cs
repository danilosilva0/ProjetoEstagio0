using ControleTarefas.WebApi;
using Microsoft.AspNetCore;

var webhost = WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

webhost.Build().Run();