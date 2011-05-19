using System.Collections.Generic;

namespace RaccoonDocumentation.Web.Models
{
	public class DocumentationItemResolved
	{
		public ICollection<MenuItem> Menu { get; set; } 
		public string Content { get; set; } 
	}
}