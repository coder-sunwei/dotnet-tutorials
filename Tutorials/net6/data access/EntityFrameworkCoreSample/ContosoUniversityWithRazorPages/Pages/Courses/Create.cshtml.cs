using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversityWithRazorPages.Models;

namespace ContosoUniversityWithRazorPages.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly Data.SchoolContext _context;

        public CreateModel(Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Courses.Add(Course);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            var emptyCourse = new Course();

            if (await TryUpdateModelAsync(emptyCourse,
                "course",
                s => s.CourseID,
                s => s.DepartmentID,
                s => s.Title,
                s => s.Credits))
            {
                _context.Courses.Add(emptyCourse);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}
