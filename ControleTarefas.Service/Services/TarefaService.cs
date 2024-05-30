using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Helper.Exceptions;
using ControleTarefas.Helper.Messages;
using ControleTarefas.Repository.Interface.IRepositories;
using ControleTarefas.Service.Interface.Services;
using log4net;

namespace ControleTarefas.Service.Services
{
    public class TarefaService : ITarefaService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(TarefaService));
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository) { _tarefaRepository = tarefaRepository;}

        public List<TarefaDTO> DeletarTarefa(string nomeTarefa)
        {
            var tarefa = _tarefaRepository.ObterTarefa(nomeTarefa);
            if (tarefa != null)
            {
                _tarefaRepository.Deletar(tarefa);
                _log.InfoFormat("A tarefa '{0}' foi deletada com sucesso!", nomeTarefa);
            }
            else
            {
                _log.InfoFormat("A tarefa '{0}' não existe na lista de tarefas.", nomeTarefa);
                throw new ServiceException(string.Format(BusinessMessages.RegisterNotFound, nomeTarefa));
            }

            return _tarefaRepository.ListarTodasTarefasDTO();
        }

        public List<TarefaDTO> EditarTarefa(string tarefa, string novoNomeTarefa)
        {


            var tarefaExistente = _tarefaRepository.ObterTarefa(tarefa);
            if (tarefaExistente != null)
            {
                tarefaExistente.Titulo = novoNomeTarefa;
                _log.InfoFormat("A tarefa '{0}' foi editada para '{1}' com sucesso!", tarefa, novoNomeTarefa);
            }
            else
            {
                _log.InfoFormat("A tarefa '{0}' nao existe na lista de tarefas.", tarefa);
                throw new ServiceException($"A tarefa {tarefa} nao existe na lista de tarefas");
            }

            return _tarefaRepository.ListarTodasTarefasDTO();
        }

        public List<TarefaDTO> InserirTarefa(string novaTarefa)
        {
            var tarefa = _tarefaRepository.ObterTarefa(novaTarefa);

            if (tarefa != null)
            {
                _log.InfoFormat("A tarefa '{0}' ja` existe na lista de tarefas", novaTarefa);
                throw new ServiceException($"A tarefa '{tarefa}' ja` existe na lista de tarefas");
            }

            tarefa = new Tarefa(novaTarefa);
            _tarefaRepository.Inserir(tarefa);
            _log.InfoFormat("A tarefa '{0}' foi inserida com sucesso!", novaTarefa);

            return _tarefaRepository.ListarTodasTarefasDTO();
        }

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
