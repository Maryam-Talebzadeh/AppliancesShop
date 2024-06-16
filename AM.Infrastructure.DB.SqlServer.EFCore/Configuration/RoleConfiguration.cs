using AM.Domain.Core.RoleAgg.Entities;
using IM.Infrastructure.Configuration.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Infrastructure.Configuration.Permissions;

namespace AM.Infrastructure.DB.SqlServer.EFCore.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            #region SeedData       

            var role1 = new Role("مدیرسیستم", new List<Permission>());
            role1.Id = 1;
            builder.HasData(role1);

            var role2 = new Role("کاربر عادی", new List<Permission>());
            role2.Id = 2;
            builder.HasData(role2);

            var role3 = new Role("محتوا گذار", new List<Permission>());
            role3.Id = 3;
            builder.HasData(role3);

            var role4 = new Role("کاربر همکار", new List<Permission>());
            role4.Id = 4;
            builder.HasData(role4);

            #endregion

            builder.OwnsMany(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.ToTable("RolePermissions");
                navigationBuilder.Ignore(x => x.Name);
                navigationBuilder.WithOwner(x => x.Role);

                var permissions = new List<Permission>();

                var permission1 = new Permission(InventoryPermissions.CreateInventory);
                permission1.Id = 1;
                permissions.Add(permission1);

                var permission2 = new Permission(InventoryPermissions.EditInventory);
                permission2.Id = 2;
                permissions.Add(permission2);

                var permission3 = new Permission(InventoryPermissions.Increase);
                permission3.Id = 3;
                permissions.Add(permission3);

                var permission4 = new Permission(InventoryPermissions.Reduce);
                permission4.Id = 4;
                permissions.Add(permission4);

                var permission18 = new Permission(InventoryPermissions.ListInventory);
                permission18.Id = 18;
                permissions.Add(permission18);

                var permission6 = new Permission(InventoryPermissions.OperationLog);
                permission6.Id = 6;
                permissions.Add(permission6);

                var permission7 = new Permission(InventoryPermissions.SearchInventory);
                permission7.Id = 7;
                permissions.Add(permission7);

                var permission8 = new Permission(ShopPermissions.CreateProduct);
                permission8.Id = 8;
                permissions.Add(permission8);

                var permission9 = new Permission(ShopPermissions.EditProduct);
                permission9.Id = 9;
                permissions.Add(permission9);

                var permission10 = new Permission(ShopPermissions.ListProducts);
                permission10.Id = 10;
                permissions.Add(permission10);

                var permission11 = new Permission(ShopPermissions.SearchProducts);
                permission11.Id = 11;
                permissions.Add(permission11);

                var permission12 = new Permission(ShopPermissions.CreateProductCategory);
                permission12.Id = 12;
                permissions.Add(permission12);

                var permission13 = new Permission(ShopPermissions.EditProductCategory);
                permission13.Id = 13;
                permissions.Add(permission13);

                var permission14 = new Permission(ShopPermissions.ListProductCategories);
                permission14.Id = 14;
                permissions.Add(permission14);

                var permission15 = new Permission(ShopPermissions.SearchProductCategories);
                permission15.Id = 15;
                permissions.Add(permission15);

                foreach (var permission in permissions)
                {
                    permission.RoleId = 1;
                }

                navigationBuilder.HasData(permissions);

            });
        }
    }
}
