﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UWT.Web.Startup))]
namespace UWT.Web {
    
    public partial class Startup {
    
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }

    }

}