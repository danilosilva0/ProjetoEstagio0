using ControleTarefas.Entity.DTO;
using ControleTarefas.Repository.Interface.IRepositories;
using ControleTarefas.Service.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Service.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository) { _tarefaRepository = tarefaRepository;}

        public List<TarefaDTO> ListarTarefasDTO(List<string> tarefas) 
        {
            if (tarefas == null) return _tarefaRepository.ListarTodasTarefasDTO();
            else
            {
                tarefas = tarefas.Select(t => t.ToUpper()).ToList();
                return _tarefaRepository.ListarTarefasDTO(tarefas);
            }
        }
    }
}
