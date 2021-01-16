using OLC.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLC.Cases.Api.Models
{
    public interface ICaseRepository : IRepository<Case>
    {
        Task Add(Case model);
        void Update(Case model);
        Task Remove(string caseNumber);
        Task<IEnumerable<Case>> GetAll();
        Task<Case> GetByCaseNumber(string caseNumber);
    }
}
