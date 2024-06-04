using ControleTarefas.Repository.Interface.IRepositories;
using ControleTarefas.Repository.Repositories;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.Service.Services;

namespace ControleTarefas.WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {

        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            InjectRepository(services);
            InjectService(services);
        }

        private static void InjectService(IServiceCollection services)
        {
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }

        private static void InjectRepository(IServiceCollection services)
        {
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
