using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Level
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BgId { get; set; }
		public string BgLevelTitle { get; set; }
		public string BgLevelText { get; set; }
		public int CourseId { get; set; }
	}
}
