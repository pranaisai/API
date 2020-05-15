using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
	public class NotificationModel
	{
		public int RequestId { get; set; }
		public int Itemid { get; set; }
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public string ExchangeItem { get; set; }
		public string ImageName { get; set; }
		public string Distance { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string AddressLine { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public string Zipcode { get; set; }
	}
}
