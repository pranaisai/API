using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using DTO.Models;

namespace GroSHAPI.Hubs
{
	[HubName("BroadcastHub")]
	public class BroadcastHub : Hub
	{
		public async Task NewRequest(string name, string message)
		{
			await Clients.All.newMessageRequest(name, message);
		}

		public async Task JoinRoom(string groupName)
		{
			await Groups.Add(Context.ConnectionId, groupName);
			await Clients.Group(groupName).Send("Joined");
		}

		public Task LeaveRoom(string groupName)
		{
			return Groups.Remove(Context.ConnectionId, groupName);
		}	

		public void SendMessage(ChatModel objChatModel)
		{
			try
			{
				if (objChatModel.FirstUser != 0 && objChatModel.SecondUser != 0)
				{
					var groupName = objChatModel.FirstUser < objChatModel.SecondUser ? objChatModel.FirstUser.ToString() + objChatModel.SecondUser.ToString() : objChatModel.FirstUser.ToString() + objChatModel.SecondUser.ToString();
					Clients.OthersInGroup(groupName).SendChatMessage(objChatModel);
				}
			}
			catch (Exception)
			{
				///Handle with log
			}
		}
	}
}