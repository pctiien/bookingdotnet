using bookingdotcom.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace bookingdotcom.Filters{
    public class JwtAuthorizeFilter : IAuthorizationFilter
    {
        private readonly string _role;
        public ITokenService _ITokenService {set;get;}
        
        public JwtAuthorizeFilter(ITokenService ITokenService,string role)
        {
            _role = role;
            _ITokenService = ITokenService;
        }
        public JwtAuthorizeFilter(ITokenService ITokenService):this(ITokenService,"User")
        {
            _ITokenService = ITokenService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var jwtToken = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            try
            {
                if(jwtToken==null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                if(_ITokenService.ValidateJwtToken(jwtToken,_role,out var UserId))
                {
                    context.HttpContext.Items["UserId"]=UserId;

                }else
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (System.Exception)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}