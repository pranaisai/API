using BusinessLayer;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroSHAPI.Controllers
{
	[RoutePrefix("api/Process")]
	[Authorize]
	public class ProcessController : ApiController
	{
		public IProcessBusinessLayer _processBusinessLayer;
		public ProcessController(IProcessBusinessLayer processBusinessLayer)
		{
			this._processBusinessLayer = processBusinessLayer;
		}

		/// <summary>
		/// this method is used to get notification list
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpGet]		
		public HttpResponseMessage GetNotification(int userId)
		{
			Response<int> response = new Response<int>();
			try
			{
				var result = this._processBusinessLayer.GetNewNotificationCounts(userId);
				response.SatusCode = 200;
				response.Data = result;
				response.Message = "sucess";
			}
			catch (Exception)
			{
				response.SatusCode = 201;
				response.Data = 0;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		/// <summary>
		/// this method is used to get notification counts
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpGet]
		public HttpResponseMessage GetNotificationList(int userId)
		{
			Response<List<NotificationModel>> response = new Response<List<NotificationModel>>();
			try
			{
				List<NotificationModel> items = this._processBusinessLayer.GetNotifications(userId);
				response.SatusCode = 200;
				response.Data = items;
				response.Message = "sucess";
			}
			catch (Exception)
			{
				response.SatusCode = 201;
				response.Data = null;
				response.Message = Utility.Constants.FailedMesg;
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		/// <summary>
		/// this method is used to send request
		/// </summary>
		/// <param name="senderId"></param>
		/// <param name="receiverId"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		[HttpPost]
		public HttpResponseMessage SendRequest([FromUri] int senderId, int receiverId, int itemId)
		{
			Response<int> response = new Response<int>();
			try
			{
				var result = this._processBusinessLayer.SendRequest(senderId, receiverId, itemId);
				if (result > 0)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = "Success";
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return Request.CreateResponse(response);// Ok(response);
		}

		/// <summary>
		/// this method is used to AcceptOrReject request
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="requestId"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		[HttpPost]
		public HttpResponseMessage AcceptOrReject([FromUri] int userid, int requestId, int status)
		{
			Response<int> response = new Response<int>();
			try
			{
				var result = this._processBusinessLayer.AcceptOrReject(userid, requestId, status);
				if (result > 0)
				{
					response.SatusCode = 200;
					response.Data = result;
					response.Message = "Success";
				}
				else
				{
					response.SatusCode = 500;
					response.Data = result;
					response.Message = Utility.Constants.FailedMesg;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
			return Request.CreateResponse(response);// Ok(response);
		}
	}
}
