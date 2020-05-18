using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Wh
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int WhId { get; set; }
		public string WhName { get; set; }
		public int CourseId { get; set; }
	}
}
