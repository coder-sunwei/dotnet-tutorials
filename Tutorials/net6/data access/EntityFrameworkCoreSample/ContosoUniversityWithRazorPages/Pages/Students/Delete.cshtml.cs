#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversityWithRazorPages.Models;

namespace ContosoUniversityWithRazorPages.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly Data.SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(Data.SchoolContext context,
             ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Student Student { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangeError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }

            if (saveChangeError.GetValueOrDefault())
            {
                ErrorMessage = string.Format("Delete {ID} failed. Try again.", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }

            try
            {
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }


        }
    }
}
