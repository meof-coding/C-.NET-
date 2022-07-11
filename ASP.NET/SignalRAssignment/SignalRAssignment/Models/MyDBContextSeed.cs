using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SignalRAssignment.Areas.Identity.Data;
using SignalRAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.Models
{
    public class MyDBContextSeed
    {
        private const int MAX_DATA = 5;
        private const int MIN_WORD = 10;
        //Seed data in MyDBContext
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Lab2Context(serviceProvider.GetRequiredService<DbContextOptions<Lab2Context>>()))
            {
                if (context == null)
                {
                    throw new ArgumentNullException("Null Lab2Context");
                }
                //Look for any suppliers
                if (!context.Suppliers.Any())
                {
                    //Seeding Suppliers
                    for (int i = 0; i < MAX_DATA; i++)
                    {
                        Supplier supplier = new Supplier();
                        supplier.SupplierId = $"S00{i}";
                        supplier.CompanyName = Faker.Company.Name();
                        supplier.Address = Faker.Address.StreetAddress();
                        supplier.Phone = Faker.Phone.Number();
                        context.Suppliers.Add(supplier);
                    }
                }
                //Look for any category
                if (!context.Categories.Any())
                {
                    string[] category_names = { "Salads", "Entrees", "Soups", "Desserts", "Beverages" };
                    for (int i = 0; i < MAX_DATA; i++)
                    {
                        Category category = new Category();
                        category.CategoryId = i;
                        category.CategoryName = category_names[i];
                        category.Description = Faker.Lorem.Sentence(MIN_WORD);
                        context.Categories.Add(category);
                    }
                }
                //Look for any products
                if (!context.Products.Any())
                {
                    //Seeding Product
                    for (int i = 0; i < MAX_DATA; i++)
                    {
                        Product product = new Product();
                        Random random = new Random();
                        product.SupplierId = $"S00{i}";
                        product.CategoryId = i;
                        product.ProductName = Faker.Name.Last();
                        product.QuantityPerUnit = random.Next(10);
                        product.UnitPrice = random.Next(100);
                        context.Products.Add(product);
                    }
                }
                //Look for any discount
                if (!context.Discounts.Any())
                {
                    //Seeding Disocunt
                    for (int i = 0; i < MAX_DATA; i++)
                    {
                        Discount discount = new Discount();
                        Random random = new Random();
                        discount.Name = Faker.Name.Last();
                        discount.Description = Faker.Lorem.Sentence(MIN_WORD);
                        discount.DiscountPercent = random.Next(50);
                        discount.Active = true;
                        discount.ExperiedAt = DateTime.Now.AddDays(random.Next(50));
                        context.Discounts.Add(discount);
                    }
                }
                context.SaveChanges();
            }
        }

        //seed user in identity
        public static async Task SeedAsync(SignalRAssignmentContext identityMySQLContext, UserManager<SignalRAssignmentUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            identityMySQLContext.Database.Migrate();

            try
            {
                if (!identityMySQLContext.Roles.Any())
                {
                    var roles = GetSeedingRoles();
                    foreach (var role in roles)
                    {
                        IdentityResult result = await roleManager.CreateAsync(role);
                    }
                }

                if (!identityMySQLContext.Users.Any())
                {
                    var users = GetSeedingUsers();
                    foreach (var user in users)
                    {
                        IdentityResult result = await userManager.CreateAsync(user, "Customer1_");
                        await userManager.AddToRoleAsync(user, "Customer");
                    }

                    var managers = GetSeedingStaff();
                    foreach (var manager in managers)
                    {
                        IdentityResult result = await userManager.CreateAsync(manager, "Staff1_");
                        await userManager.AddToRoleAsync(manager, "Staff");
                    }

                    var admins = GetSeedingAdmin();
                    foreach (var admin in admins)
                    {
                        IdentityResult result = await userManager.CreateAsync(admin, "Admin1_");
                        await userManager.AddToRoleAsync(admin, "Admin");
                    }
                }

                //if (!identityMySQLContext.RoleClaims.Any())
                //{
                //    var roles = roleManager.Roles.ToList();
                //    foreach (var role in roles)
                //    {
                //        if (role.Name == "Admin")
                //        {
                //            foreach (var claim in AuthorizationConstants.LIST_PERMISSION)
                //            {
                //                roleManager.AddClaimAsync(role, new Claim(claim.Name, claim.Name)).Wait();
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        static IEnumerable<SignalRAssignmentUser> GetSeedingUsers()
        {
            return new List<SignalRAssignmentUser>()
            {
                new SignalRAssignmentUser { UserName = "customer"},
            };
        }

        static IEnumerable<SignalRAssignmentUser> GetSeedingStaff()
        {
            return new List<SignalRAssignmentUser>()
            {
                new SignalRAssignmentUser { UserName = "staff"},
            };
        }

        static IEnumerable<SignalRAssignmentUser> GetSeedingAdmin()
        {
            return new List<SignalRAssignmentUser>()
            {
                new SignalRAssignmentUser { UserName = "admin"},
            };
        }

        static IEnumerable<IdentityRole> GetSeedingRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin"},
                new IdentityRole { Name = "Customer" },
                new IdentityRole { Name = "Staff" },
            };
        }
    }
}
