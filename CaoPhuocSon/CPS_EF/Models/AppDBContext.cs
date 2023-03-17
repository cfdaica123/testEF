using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPS_EF.Models
{
    public class AppDBContext : DbContext
    {

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Image> Product_Images { get; set; }
        
        public string ConnectionString { get; private set; }

        public AppDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var pathApp = Path.Combine(folder.ToString(), "CPS_DB");
            if (!Directory.Exists(pathApp))
            {
                Directory.CreateDirectory(pathApp);
            }
            ConnectionString = Path.Combine(pathApp, "cpsDB.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={ConnectionString}");
        }

        public class BaseEntity
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public DateTime? DateCreated { get; set; }
            public DateTime? DateUpdated { get; set; }
        }
    }
}