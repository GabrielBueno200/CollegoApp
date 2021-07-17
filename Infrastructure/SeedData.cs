using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

using Infrastructure;

namespace Infrastructure
{
    public class Seed
    {
        
        public static async Task SeedData(DataContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager){

            if (!userManager.Users.Any() && !roleManager.Roles.Any()){

                List<string> roles = new List<string>{
                    new string("ADMIN"),
                    new string("STUDENT")
                };

                foreach (string role in roles){
                    await roleManager.CreateAsync(new IdentityRole(role));
                };

                List<User> users = new List<User>{
                    
                    new User{
                        Id = "ADM1",
                        FullName = "Gabriel Bueno",
                        UserName = "gabrielbueno",
                        Email = "gabriel.bueno@collego.com.br",
                        Course = null
                    },

                    new User{
                        Id = "ADM2",
                        FullName = "Gabriel Duarte",
                        UserName = "brunobigide",
                        Email = "gabriel.duarte@collego.com.br",
                        Course = null
                    },
                };
                
                foreach (User user in users){
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "ADMIN");
                }
            }

            if (!context.Course.Any()){

                var courses = new List<Course>{
                    new Course { Name = "Ciência da Computação" },
                    new Course { Name = "Engenharia da Computação" },
                    new Course { Name = "Engenharia de Software" },
                    new Course { Name = "Engenharia Mecânica" },
                    new Course { Name = "Engenharia Elétrica" },
                    new Course { Name = "Matemática" },
                    new Course { Name = "Física" },
                    new Course { Name = "Literatura" },
                    new Course { Name = "Medicina" },
                    new Course { Name = "Biologia" },
                };

                await context.Course.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }
        }
    }
}