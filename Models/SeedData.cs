using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesStudent.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesStudentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesStudentContext>>()))
            {
                // Look for any students.
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(
                    new Student
                    {
                        FirstName = "John",
                        LastName = "Smith",
                        CertifiedDate = DateTime.Parse("1989-2-12"),
                        Location = "Chicago",
                        Program = "UC_WDES",
                        TandF = 7.99M,
                        
                    },

                    new Student
                    {
                        FirstName = "Joan",
                        LastName = "Marks",
                        CertifiedDate = DateTime.Parse("1989-2-12"),
                        Location = "Chicago",
                        Program = "UC_WDES", 
                        TandF = 7.99M,
                       
                    },

                    new Student
                    {
                        FirstName = "Phil",
                        LastName = "Williams",
                        CertifiedDate = DateTime.Parse("1989-2-12"),
                        Location = "Naperville",
                        Program = "Guest Student",
                        TandF = 7.99M,
                       
                    },

                    new Student
                    {
                        FirstName = "Harry",
                        LastName = "Hamlin",
                        CertifiedDate = DateTime.Parse("1989-2-12"),
                        Location = "Skokie",
                        Program = "Guest Student",
                        TandF = 7.99M,
                       
                    }
                );
                context.SaveChanges();
            }
        }
    }
}