using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Progno.Web.Models.Extension
{
    public static class IdentityExtensions
    {
        public static string GetUserImage(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("ImageFileUrl");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetUserEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("EmailAddress");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}