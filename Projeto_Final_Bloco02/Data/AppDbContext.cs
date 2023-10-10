using Microsoft.EntityFrameworkCore;

namespace Projeto_Final_Bloco02.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }
    }
}
