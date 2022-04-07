#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoUniversityWithRazorPages.Models;
using ContosoUniversityWithRazorPages.Models.SchoolViewModels;

namespace ContosoUniversityWithRazorPages.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversityWithRazorPages.Data.SchoolContext _context;

        public CreateModel(ContosoUniversityWithRazorPages.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentViewModel StudentVM { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Students.Add(Student);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            //var emptyStudent = new Student();

            //if (await TryUpdateModelAsync<Student>(emptyStudent, "student", s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            //{
            //    _context.Students.Add(emptyStudent);

            //    await _context.SaveChangesAsync();

            //    return RedirectToPage("./Index");
            //}

            //return Page();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());

            entry.CurrentValues.SetValues(StudentVM);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
