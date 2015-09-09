using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Services_Common;

[assembly: OwinStartup(typeof(Services_Common.Startup))]

namespace Services_Common
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			app.MapSignalR();
		}
	}
}
