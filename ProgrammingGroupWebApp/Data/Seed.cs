using Microsoft.AspNetCore.Identity;
using ProgrammingGroupWebApp.Data.ENUM;
using ProgrammingGroupWebApp.Models;
using System.Diagnostics;
using System.Net;

namespace ProgrammingGroupWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.groups.Any())
                {
                    context.groups.AddRange(new List<Group>()
                    {
                        new Group()
                        {
                            Title = "Programming Group 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Trainee Developer Group",
                            GroupCategory = GroupCategory.Trainee_Developer,
                            Language = new AddLanguage()
                            {
                                Language = "Javascript",
                                City = "Lagos",
                                Name = "Destiny",
                                Description = "Trainee Developer in Javascript"
                            }
                         },
                        new Group()
                        {
                            Title = "Programming Group 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Senior Developer Group",
                            GroupCategory = GroupCategory.Senior_Developer,
                            Language = new AddLanguage()
                            {
                                Language = "React Javascript",
                                City = "Abuja",
                                Name = "Beeshop",
                                Description = "Senior Developer in Javascript"
                            }
                        },
                        new Group()
                        {
                            Title = "Programming Group 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Senior Developer Group",
                            GroupCategory = GroupCategory.Middle_Developer,
                            Language = new AddLanguage()
                            {
                                Language = "ASP.NET 6.0",
                                City = "Lagos",
                                Name = "Obueh",
                                Description = "Senior Developer in ASP.Net 6"
                            }
                        },
                        new Group()
                        {
                            Title = "Programming Group 4",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Junior Developer Group",
                            GroupCategory = GroupCategory.Junior_Developer,
                            Language = new AddLanguage()
                            {
                                Language = "SQL",
                                City = "Benue",
                                Name = "Obafemi",
                                Description = "Junoir Developer in SQL"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //CodingMeetUp
                if (!context.codingMeetUps.Any())
                {
                    context.codingMeetUps.AddRange(new List<CodingMeetUp>()
                    {
                        new ()
                        {
                            Title = "Programming group for React Javascript",
                            Image = "https://media.sketchfab.com/models/350b1d11189b49919184ceda21886ebc/thumbnails/9b15af9655904474a31f0b7a48ff4955/72351db1ea1b4386aec2da04b2da68a1.jpeg",
                            Description = "This is the description of the React Developer",
                            MeetUpCategory = MeetUpCategory.ReactJavascript,
                            Language = new AddLanguage()
                            {
                               Language = "React Javascript",
                                City = "Abuja",
                                Name = "Beeshop",
                                Description = "Senior Developer in Javascript"
                            }
                        },
                        new CodingMeetUp() 
                        {
                            Title = "ASP.Net",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the Dot Net Developers",
                            MeetUpCategory = MeetUpCategory.DotNet,
                            Language = new AddLanguage()
                            {
                                Language = "ASP.NET 6.0",
                                City = "Lagos",
                                Name = "Obueh",
                                Description = "Senior Developer in ASP.Net 6"
                            }
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
