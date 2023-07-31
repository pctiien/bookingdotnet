using bookingdotcom.Filters;
using bookingdotcom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace bookingdotcom.Attributes
{
    public class JwtAuthorizeAttribute : TypeFilterAttribute
    {
        public JwtAuthorizeAttribute(string role) : base(typeof(JwtAuthorizeFilter))
        {
            Arguments = new object[] { role };
        }
        public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
        {
            Arguments = new object[] {"User"};
        }
    }
}