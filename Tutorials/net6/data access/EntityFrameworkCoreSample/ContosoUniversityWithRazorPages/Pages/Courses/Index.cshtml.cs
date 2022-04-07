using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityWithRazorPages.Models.SchoolViewModels;

namespace ContosoUniversityWithRazorPages.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversityWithRazorPages.Data.SchoolContext _context;

        public IndexModel(ContosoUniversityWithRazorPages.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            CourseVM = await _context.Courses
               .Select(p => new CourseViewModel
               {
                   CourseID = p.CourseID,
                   Title = p.Title,
                   Credits = p.Credits,
                   DepartmentName = p.Department.Name
               }).ToListAsync();
        }
    }
}
