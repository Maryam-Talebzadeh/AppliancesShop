using Microsoft.EntityFrameworkCore;
using SM.Domain.Core.OrderAgg.Entities;
using SM.Domain.Core.ProductAgg.Entities;
using SM.Domain.Core.ProductCategoryAgg.Entities;
using SM.Domain.Core.SliderAgg.Entities;
using SM.Infrastructure.DB.SqlServer.EFCore.Configurations.ProductCategoryAgg;


namespace SM.Infrastructure.DB.SqlServer.EFCore.Contexts
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            
        }

        #region OrderAgg

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        #endregion

        #region ProductCategoryAgg

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        #endregion

        #region Product

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }

        #endregion

        #region Slide

        public DbSet<Slide> Slides { get; set; }
        public DbSet<SlidePicture> SlidePictures { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
