using Microsoft.AspNet.SignalR;
using Services_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Common.Hubs
{
	public class DeveloperHub : Hub
	{
		public void AddDeveloper(Developer developer)
		{
			var dc = new TrackerContext();
			dc.Developers.Add(developer);
			dc.SaveChanges();

			Clients.All.developerAdded(developer);
		}
	}
}
