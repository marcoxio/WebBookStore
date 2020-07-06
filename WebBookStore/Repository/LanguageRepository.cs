using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBookStore.Data;
using WebBookStore.Models;

namespace WebBookStore.Repository
{
    public class LanguageRepository
    {
         private readonly BookStoreContext _context = null;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages(){
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}