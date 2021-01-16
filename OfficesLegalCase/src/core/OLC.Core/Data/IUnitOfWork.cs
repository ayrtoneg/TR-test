using System.Threading.Tasks;

namespace OLC.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
