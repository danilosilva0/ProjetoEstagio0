using ControleTarefas.Entity.DTO;
using ControleTarefas.Entity.Entities;
using ControleTarefas.Entity.Model;
using ControleTarefas.Helper.Exceptions;
using ControleTarefas.Helper.Messages;
using ControleTarefas.Repository.Interface.IRepositories;
using ControleTarefas.Service.Interface.Services;
using ControleTarefas.Validator.Manual;
using log4net;

namespace ControleTarefas.Service.Services
{
    public class TarefaService : ITarefaService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(TarefaService));
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository) { _tarefaRepository = tarefaRepository;}

        public async Task<List<TarefaDTO>> DeletarTarefa(string nomeTarefa)
        {
            var tarefa = await _tarefaRepository.ObterTarefa(nomeTarefa);
            if (tarefa != null)
            {
                await _tarefaRepository.Deletar(tarefa);
                _log.InfoFormat("A tarefa '{0}' foi deletada com sucesso!", nomeTarefa);
            }
            else
            {
                _log.InfoFormat("A tarefa '{0}' não existe na lista de tarefas.", nomeTarefa);
                throw new ServiceException(string.Format(ServiceMessages.RegisterNotFound, nomeTarefa));
            }

            return await _tarefaRepository.ListarTodasTarefasDTO();
        }

        public async Task<List<TarefaDTO>> EditarTarefa(string tarefa, string novoNomeTarefa)
        {


            var tarefaExistente = await _tarefaRepository.ObterTarefa(tarefa);
            if (tarefaExistente != null)
            {
                tarefaExistente.Titulo = novoNomeTarefa;
                await _tarefaRepository.Atualizar(tarefaExistente);
                _log.InfoFormat("A tarefa '{0}' foi editada para '{1}' com sucesso!", tarefa, novoNomeTarefa);
            }
            else
            {
                _log.InfoFormat("A tarefa '{0}' nao existe na lista de tarefas.", tarefa);
                throw new ServiceException($"A tarefa {tarefa} nao existe na lista de tarefas");
            }

            return await _tarefaRepository.ListarTodasTarefasDTO();
        }

        public Task<List<TarefaDTO>> InserirTarefa(CadastroTarefaModel novaTarefa)
        {
            var tarefa = await _tarefaRepository.ObterTarefa(novaTarefa.Titulo);

            if (tarefa != null) throw new ServiceException(string.Format(ServiceMessages.ExistentRegister, "Titulo"));

            CadastroTarefaValidator.Validar(novaTarefa, tarefa);

            tarefa = new Tarefa(novaTarefa.Titulo);
            await _tarefaRepository.Inserir(tarefa);
            _log.InfoFormat("A tarefa '{0}' foi inserida com sucesso!", novaTarefa);
            //throw new Exception("erro genérico");
            return await _tarefaRepository.ListarTodasTarefasDTO();
        }

        public Task<List<TarefaDTO>> ListarTarefasDTO(List<string> tarefas) 
        {
            if (tarefas == null) return await _tarefaRepository.ListarTodasTarefasDTO();
            else
            {
                tarefas = tarefas.Select(t => t.ToUpper()).ToList();
                return await _tarefaRepository.ListarTarefasDTO(tarefas);
            }
        }
    }
}
