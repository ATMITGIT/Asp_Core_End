using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
	public class Course
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CourseId { get; set; }
		public string CourseImage { get; set; }
		public string CourseTitle { get; set; }
		public string CourseDescription { get; set; }
	
	

	}
}
