using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
 public	class EmailModel
	{
		public string Email { get; set; }
		public string OTP { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public string ToEmail { get; set; }
		public string BCCEmail { get; set; }
		public string CCEmail { get; set; }
	}
}
