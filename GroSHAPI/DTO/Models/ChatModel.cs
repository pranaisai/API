using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
	public class ChatModel
	{
		public int FirstUser { get; set; }

		public int SecondUser { get; set; }

		public string Message { get; set; }

		public DateTime SendTime { get; set; }

		public string Sender { get; set; }
	}
}
