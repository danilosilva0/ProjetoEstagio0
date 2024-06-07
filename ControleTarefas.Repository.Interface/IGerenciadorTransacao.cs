using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ControleTarefas.Repository.Interface
{
    public interface IGerenciadorTransacao
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel);
        Task CommitTransactionsAsync();
        Task RollbackTransactionsAsync();
    }
}
