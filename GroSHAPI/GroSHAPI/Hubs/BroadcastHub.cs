using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using DTO.Models;
using DataAccessLayer;

namespace GroSHAPI.Hubs
{
	[HubName("BroadcastHub")]
	public class BroadcastHub : Hub
	{
		ProcessDataAccess obj = new ProcessDataAccess();
		public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

		public Task SendMessage1(string user, string message)
		{
			return Clients.All.SendAsync("ReceiveMessage", user, message);
		}

		/// <summary>
		/// This method is used to JoinRoom for chat
		/// </summary>
		/// <param name="groupName"></param>
		/// <returns></returns>
		public async Task JoinRoom(string groupName)
		{
			await Groups.Add(Context.ConnectionId, groupName);
			await Clients.Group(groupName).Send("Joined");
		}

		/// <summary>
		/// This method is used to leave group
		/// </summary>
		/// <param name="groupName"></param>
		/// <returns></returns>
		public Task LeaveRoom(string groupName)
		{
			return Groups.Remove(Context.ConnectionId, groupName);
		}	

		/// <summary>
		/// This method is used to join Group
		/// </summary>
		/// <param name="objChatModel"></param>
		public void SendMessage(ChatModel objChatModel)
		{
			try
			{
				if (objChatModel.FirstUser != 0 && objChatModel.SecondUser != 0)
				{
					var groupName = objChatModel.FirstUser < objChatModel.SecondUser ? objChatModel.FirstUser.ToString() + objChatModel.SecondUser.ToString() : objChatModel.FirstUser.ToString() + objChatModel.SecondUser.ToString();
					Clients.OthersInGroup(groupName).SendChatMessage(objChatModel);
					obj.SaveChat(objChatModel);
					
				}
			}
			catch (Exception)
			{
				///Handle with log
			}
		}
	}
}