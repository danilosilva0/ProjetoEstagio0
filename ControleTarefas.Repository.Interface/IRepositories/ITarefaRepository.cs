using ControleTarefas.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleTarefas.Repository.Interface.IRepositories
{
    public interface ITarefaRepository
    {
        List<TarefaDTO> ListarTarefasDTO(List<string> tarefas);
        List<TarefaDTO> ListarTodasTarefasDTO();
    }
}
