using Microsoft.EntityFrameworkCore;
using OLC.Cases.Api.Models;
using OLC.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLC.Cases.Api.Data.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly LegalCaseContext _context;

        public CaseRepository(LegalCaseContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Add(Case model)
        {
            await _context.Cases.AddAsync(model);
        }

        public async Task Remove(string caseNumber)
        {
            _context.Cases.Remove(await GetByCaseNumber(caseNumber));
        }

        public void Update(Case model)
        {
            _context.Cases.Update(model);
        }

        public async Task<IEnumerable<Case>> GetAll()
        {
            return await _context.Cases.AsNoTracking().ToListAsync();
        }

        public async Task<Case> GetByCaseNumber(string caseNumber)
        {
            return await _context.Cases.FirstOrDefaultAsync(c => c.CaseNumber == caseNumber);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
