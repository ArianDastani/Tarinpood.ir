using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtility
    {
        public static long? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                ClaimsIdentity? claimsIdentity = User.Identity as ClaimsIdentity;
                long? userId = long.Parse(claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
