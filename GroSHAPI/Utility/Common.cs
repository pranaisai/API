using DTO.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
				NetworkCredential NetworkCred = new NetworkCredential("richtech.socialmedia@gmail.com", "richtech@2017");
				smtpClient.Port = 587;				
				smtpClient.Host = "smtp.googlemail.com";
				MailMessage mailMessage = new MailMessage
				{
					Subject = emailModel.Subject,
					Body = emailModel.Body,
				};				
				MailAddress ma = new MailAddress("richtech.socialmedia@gmail.com", "ShareMyBasket");
				mailMessage.From = ma;
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
					string[] CCEmail = emailModel.CCEmail.Split(',');
					foreach (var item in CCEmail)
					{
						mailMessage.CC.Add(new MailAddress(item.ToString()));
					}
				}				
				mailMessage.Priority = MailPriority.High;
				mailMessage.IsBodyHtml = true;
				smtpClient.EnableSsl = true;			
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = NetworkCred;
				smtpClient.Send(mailMessage);
				return true;				
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
