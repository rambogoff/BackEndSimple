using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using react.DTO;
using react_backend;

namespace react.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public ResponseAuthorization POST(RequestAuthorization requestObject)
        {
            ResponseAuthorization _responseAuth = new ResponseAuthorization()
            {
                Success = false
            };

            if (requestObject != null)
            {
                try
                {
                    using (var db = new LinkedinContext()) // veritabanı connection 
                    {
                        var user = db.Users.Where(x => x.Mail == requestObject.UserMail).FirstOrDefault(); // linq ile sorgulama işlemi

                        if (user == null)
                            throw new ArgumentException("user_not_found");
                        if (user.Password != requestObject.Password)
                            throw new ArgumentException("password_error");

                        _responseAuth.Success = true;
                        _responseAuth.UserId = user.Id;
                    }
                }
                catch (Exception ex)
                {
                    _responseAuth.Success=false;
                    _responseAuth.Details=ex.Message;
                }
            }

            return _responseAuth;
        }
    }
}