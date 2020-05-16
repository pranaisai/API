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
		public double? Distance { get; set; }
		public string UnitOfLength { get; set; } = "Mile";
		public bool? IsActive { get; set; }
		public bool IsSendRequest { get; set; }
		public int RequestStatus { get; set; }
	}
}
