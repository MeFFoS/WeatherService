using Microsoft.EntityFrameworkCore;

namespace WeatherService.Models
{

    public class ApplicationContext : DbContext
    {
        public DbSet<ApiHistory> ApiHistories { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
