using _004_Example5_Complete.Models;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.Repositories
{
    public class StudentsRepository : IRepository<_004_Example5_Complete.Models.Students>
    {

        private _004_Example5_Complete.SchoolDbContext.SchoolDbContext _schoolDbContext;

        public StudentsRepository(_004_Example5_Complete.SchoolDbContext.SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        // GET
        public async Task<IEnumerable<Students>> GetValues() => await _schoolDbContext.Students.ToListAsync();
        public async Task<Students> GetValue(Guid id) => await _schoolDbContext.Students.FindAsync(id);
        public async Task AddValue(Students t) => await _schoolDbContext.Students.AddAsync(t);

        public void Update(Students t)
        {
            _schoolDbContext.Students.Attach(t);
            _schoolDbContext.Students.Entry(t).State = EntityState.Modified;
        }

        public void Delete(Students t) => _schoolDbContext.Students.Remove(t);

        public async Task Save()
        {
            await _schoolDbContext.SaveChangesAsync();
        }


    }
}
