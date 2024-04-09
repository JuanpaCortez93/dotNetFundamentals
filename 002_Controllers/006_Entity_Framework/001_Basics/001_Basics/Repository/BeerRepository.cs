using _001_Basics.Models;
using Microsoft.EntityFrameworkCore;

namespace _001_Basics.Repository
{
    public class BeerRepository : IRepository<BeerModels>
    {
        private BeerContext _context;

        public BeerRepository(BeerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeerModels>> Get() => await _context.BeerModels.ToListAsync();
        public async Task<BeerModels> GetById(int id) => await _context.BeerModels.FindAsync(id);

        public async Task Add(BeerModels entity) => await _context.BeerModels.AddAsync(entity);

        public void Update(BeerModels entity)
        {
            _context.BeerModels.Attach(entity);
            _context.BeerModels.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(BeerModels entity) => _context.BeerModels.Remove(entity);
        public async Task Save() => await _context.SaveChangesAsync();
        public IEnumerable<BeerModels> Search(Func<BeerModels, bool> filter) => _context.BeerModels.Where(filter).ToList();


    }
}
