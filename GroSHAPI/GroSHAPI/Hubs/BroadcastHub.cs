using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace GroSHAPI.Hubs
{
	[HubName("BroadcastHub")]
	public class BroadcastHub : Hub
	{
		public async Task NewRequest(string name, string message)
		{
			await Clients.All.newMessageRequest(name, message);
		}
	}
}