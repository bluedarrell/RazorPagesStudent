using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesStudent.Models;

namespace RazorPagesStudent.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesStudentContext _context;

        public IndexModel(RazorPagesStudentContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Location { get; set; }
        [BindProperty(SupportsGet = true)]
        public string StudentLocation { get; set; }

        public async Task OnGetAsync()
{
    // Use LINQ to get list of genres.
    IQueryable<string> genreQuery = from s in _context.Student
                                    orderby s.Location
                                    select s.Location;

    var students = from s in _context.Student
                 select s;

    if (!string.IsNullOrEmpty(SearchString))
    {
        students = students.Where(s => s.FirstName.Contains(SearchString));
    }

    if (!string.IsNullOrEmpty(StudentLocation))
    {
        students = students.Where(x => x.Location == StudentLocation);
    }
    Location = new SelectList(await genreQuery.Distinct().ToListAsync());
    Student = await students.ToListAsync();
}
    }
}