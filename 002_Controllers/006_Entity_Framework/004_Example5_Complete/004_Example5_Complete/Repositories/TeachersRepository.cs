using _004_Example5_Complete.Models;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.Repositories
{
    public class TeachersRepository : IRepository<_004_Example5_Complete.Models.Teachers>
    {

        private _004_Example5_Complete.SchoolDbContext.SchoolDbContext _schoolDbContext;

        public TeachersRepository
            (
                _004_Example5_Complete.SchoolDbContext.SchoolDbContext schoolDbContext
            )
        {
            _schoolDbContext = schoolDbContext;
        }

        public async Task<IEnumerable<Teachers>> GetValues() =>  await _schoolDbContext.Teachers.ToListAsync();

        public async Task<Teachers> GetValue(Guid id) => await _schoolDbContext.Teachers.FindAsync(id);

        public async Task AddValue(Teachers t) => await _schoolDbContext.Teachers.AddAsync(t);
       
        public void Update(Teachers t)
        {
            _schoolDbContext.Teachers.Entry(t);
            _schoolDbContext.Teachers.Attach(t).State = EntityState.Modified;
        }

        public void Delete(Teachers t) => _schoolDbContext.Remove(t);

        public async Task Save() => await _schoolDbContext.SaveChangesAsync();

    }
}
