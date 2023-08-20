using asp.netCoreIntro.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.netCoreIntro.Repository
{
    public class TutorialRepositorycs<TTutorial>
    {
        public readonly DbContext _dbContext;
        public TutorialRepositorycs(DbContext dBContext) {
            _dbContext = dBContext;
        }

        public async Task<Tutorial?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Tutorial>().FindAsync(id);
        }

    }
}
