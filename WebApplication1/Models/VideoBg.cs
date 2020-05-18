using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class VideoBg
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int VideoId { get; set; }
		public string VideoImg { get; set; }
		public string VideoTitle{ get; set; }
		public string VideoText { get; set; }
		public int LevelId { get; set; }
		public int CourseId { get; set; }
		public string Link { get; set; }
	}
}
