using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer
{
	public class ProcessDataAccess : IProcessDataAccess
	{
		/// <summary>
		/// This interface implementation is used to Accept or Reject service request
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="requestId"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public int AcceptOrReject(int userId, int requestId,  int status)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					SendReceiveRequest sendReceiveReq = (from x in db.SendReceiveRequests
									   where x.id == requestId
									   select x).First();
					sendReceiveReq.status = status;
					sendReceiveReq.acceptOrRejectDate = DateTime.Now;
					flag = db.SaveChanges();					
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}

		/// <summary>
		/// This interface implementation is used to get New notification count
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public int GetNewNotificationCounts(int userId)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var outputParameter = new ObjectParameter("result", typeof(int));
					var result = db.sp_TotalRequest(userId, outputParameter);					
					flag = (int)outputParameter.Value;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}

		/// <summary>
		/// This interface method is used to get notification list
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<NotificationModel> GetNotifications(int userId)
		{
			List<NotificationModel> notificationlst = new List<NotificationModel>();			
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var ctx = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
					var root = ctx + "/ItemImages";

					var result = (from NotificationModel in db.sp_GetNotification(userId)
								  select NotificationModel).ToList();
					if(result!=null)
					{
						foreach (var item in result)
						{
							NotificationModel notification = new NotificationModel();
							notification.RequestId = item.id;
							notification.Itemid = item.itemId;
							notification.ItemName = item.ItemName;
							notification.ExchangeItem = item.exchangeItem;
							notification.ImageName = item.imageName;
							notification.Distance = Convert.ToString(item.distance);
							notification.FirstName = item.first_Name;
							notification.LastName = item.last_Name;
							notification.Email = item.email;
							notification.Phone = item.phone;
							notification.AddressLine = item.addressLine;
							notification.City = item.city;
							notification.State = item.state;
							notification.Country = item.country;
							notification.Zipcode = item.zipcode;
							notificationlst.Add(notification);
						}
					}
					
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return notificationlst;
		}

		/// <summary>
		/// This interface implementation is used to send request
		/// </summary>
		/// <param name="senderId"></param>
		/// <param name="receiverId"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>

		public int SendRequest(int senderId, int receiverId, int itemId)
		{
			int flag = 0;
			try
			{
				using (GroSHDBEntities db = new GroSHDBEntities())
				{
					var result = db.SendReceiveRequests.Add(new SendReceiveRequest()
					{
						itemId = itemId,
						sender = senderId,
						receiver = receiverId,
						sendDate = DateTime.Now,
						acceptOrRejectDate = DateTime.Now,
						isSendRequest = true,						
						status = 0
					});
					flag = db.SaveChanges();					
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return flag;
		}
	}
}
