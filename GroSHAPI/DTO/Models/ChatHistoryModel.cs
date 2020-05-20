using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
	public class ChatHistoryModel
	{
		public int chatId { get; set; }
		public int? sender { get; set; }
		public int? receiver { get; set; }
		public string messages { get; set; }
		public int? itemId { get; set; }
		public DateTime? SendDateTime{get;set;}
	}
}
