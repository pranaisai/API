using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DataAccessLayer;

namespace BusinessLayer
{
	public class ProcessBusinessLayer : IProcessBusinessLayer
	{
		private IProcessDataAccess _processDataAccess;
		public ProcessBusinessLayer(IProcessDataAccess processDataAccess)
		{
			this._processDataAccess = processDataAccess;
		}
		public int AcceptOrReject(int userId, int requestId, int status)
		{
			return this._processDataAccess.AcceptOrReject(userId, requestId, status);
		}

		public List<ChatHistoryModel> GetHistory(int senderId, int receiverId, int itemId)
		{
			return this._processDataAccess.GetHistory(senderId, receiverId, itemId);
		}

		public int GetNewNotificationCounts(int userId)
		{
			return this._processDataAccess.GetNewNotificationCounts(userId);
		}

		public List<NotificationModel> GetNotifications(int userId)
		{
			return this._processDataAccess.GetNotifications(userId);
		}

		public int SendRequest(int senderId, int receiverId, int itemId)
		{
			return this._processDataAccess.SendRequest(senderId, receiverId, itemId);
		}
	}
}
