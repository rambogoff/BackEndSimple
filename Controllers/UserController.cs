using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using react.DTO;
using react.Models;
using react_backend;
namespace react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ResponseSuccess POST(User request) // UPDATE ve Create işlemi burada.
        {
            ResponseSuccess responseObject = new ResponseSuccess() { Success = false };

            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    throw new Exception("name_is_empty");
                if (request == null)
                    throw new Exception("request_is_empty");
                /* diğer veri kontrolleri yapılacak */
                using (var db = new LinkedinContext())
                {

                    if (request.Id == 0)
                    {
                        // id null geldi yeni kullanıcı ekleyeceğiz demektir.
                        db.Users.Add(request);
                    }
                    else
                    {
                        db.Users.Update(request);
                    }
                    db.SaveChanges();
                    responseObject.Success = true;

                }
            }
            catch (Exception ex)
            {
                responseObject.Success = false;
                responseObject.Details = ex.Message;
            }

            return responseObject;
        }

        [HttpDelete]
        public ResponseSuccess DELETE(int UserId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();

            using (var db = new LinkedinContext())
            {
                var user = db.Users.Where(x => x.Id == UserId).FirstOrDefault();
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    responseObject.Success = true;
                }
                else
                {
                    responseObject.Success = false;
                    responseObject.Details = "user_not_found";
                }
            }
            return responseObject;
        }

    }
}