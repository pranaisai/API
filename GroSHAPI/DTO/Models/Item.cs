using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
	public class Item
	{
		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public string ExchangeItem { get; set; }
		public string ImageName { get; set; }
		public string ImageUrl { get; set; }
	}
}
