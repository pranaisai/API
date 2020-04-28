using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	public static class Common
	{
		/// <summary>
		/// Method is used to send email
		/// </summary>
		/// <param name="emailModel"></param>
		/// <returns></returns>
		public static bool SendEmail(EmailModel emailModel)
		{
			try
			{
				SmtpClient smtpClient = new SmtpClient();
				NetworkCredential NetworkCred = new NetworkCredential("rakesh22maurya@gmail.com", "manni@07051993");
				smtpClient.Port = 587;
				smtpClient.Credentials = NetworkCred;
				smtpClient.Host = "smtp.gmail.com";
				MailMessage mailMessage = new MailMessage
				{
					Subject = emailModel.Subject,
					Body = emailModel.Body,
				};
				string[] ToEmail = emailModel.ToEmail.Split(',');
				foreach (var item in ToEmail)
				{
					mailMessage.To.Add(new MailAddress(item.ToString()));
				}
				if (!string.IsNullOrEmpty(emailModel.BCCEmail))
				{
					string[] BCCEmail = emailModel.BCCEmail.Split(',');
					foreach (var item in BCCEmail)
					{
						mailMessage.Bcc.Add(new MailAddress(item.ToString()));
					}
				}
				if (!string.IsNullOrEmpty(emailModel.CCEmail))
				{
					//mailMessage.Bcc.Add(new MailAddress("sender@mail.com"));
					string[] CCEmail = emailModel.CCEmail.Split(',');
					foreach (var item in CCEmail)
					{
						mailMessage.CC.Add(new MailAddress(item.ToString()));
					}
				}
				// mailMessage.CC.Add(new MailAddress("sender@mail.com"));
				mailMessage.Priority = MailPriority.High;
				mailMessage.IsBodyHtml = true;
				smtpClient.EnableSsl = true;			
				smtpClient.UseDefaultCredentials = true;
				smtpClient.Send(mailMessage);
				return true;

				//using (MailMessage mm = new MailMessage("rakesh22maurya@gmail.com", emailModel.ToEmail))
				//{
				//	mm.Subject = emailModel.OTP;
				//	mm.Body = emailModel.OTP;

				//	mm.IsBodyHtml = false;
				//	SmtpClient smtp = new SmtpClient();
				//	//smtp.Host = "smtp.gmail.com";
				//	smtp.EnableSsl = true;
				//	NetworkCredential NetworkCred = new NetworkCredential("richtech.cocialmedia@gmail.com", "richtech@2017");
				//	smtp.UseDefaultCredentials = true;
				//	smtp.Credentials = NetworkCred;
				//	//smtp.Port = 587;
				//	smtp.Host = "relay-hosting.secureserver.net";
				//	smtp.Port = 25;

				//	smtp.Send(mm);
				//	return true;
				//}
			}
			catch(Exception ex)
			{
				return false;
			}

		}

		/// <summary>
		/// Generate a random string with a given size  
		/// </summary>
		public static string RandomString(int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random();
			char ch;
			for (int i = 0; i < size; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
				builder.Append(ch);
			}
			if (lowerCase)
				return builder.ToString().ToLower();
			return builder.ToString();
		}
	}
}
