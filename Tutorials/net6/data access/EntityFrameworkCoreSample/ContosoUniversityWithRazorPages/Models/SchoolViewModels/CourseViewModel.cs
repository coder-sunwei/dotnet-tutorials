using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityWithRazorPages.Models.SchoolViewModels
{
    public class CourseViewModel
    {
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
