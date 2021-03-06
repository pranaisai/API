﻿using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public interface IProcessBusinessLayer
	{
		int SendRequest(int senderId, int receiverId, int itemId);
		int AcceptOrReject(int userId, int requestId, int status);
		List<NotificationModel> GetNotifications(int userId);
		int GetNewNotificationCounts(int userId);
		List<ChatHistoryModel> GetHistory(int senderId, int receiverId, int itemId);
	}
}
