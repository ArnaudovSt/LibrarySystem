using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LibrarySystem.Services.Common.Contracts;
using Microsoft.AspNet.Identity;

namespace LibrarySystem.Services.Common
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpContextBase httpContext;

        public IdentityService(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public Guid GetUserId()
        {
            return Guid.Parse(this.httpContext.User.Identity.GetUserId());
        }

        public string GetUsername()
        {
            return this.httpContext.User.Identity.GetUserName();
        }
    }
}
