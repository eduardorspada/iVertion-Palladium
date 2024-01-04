using Microsoft.EntityFrameworkCore;

namespace iVertion.Infra.Data.Context
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
private readonly ApplicationDbContext _context;
 
        public DatabaseInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
 
        public void MigrateDatabase()
        {
            try
            {
                _context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                // Trate qualquer exceção que possa ocorrer durante a migração.
                // Isso é importante para lidar com problemas de migração em tempo de execução.
            }
        }
    }
}