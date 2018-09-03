using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using react.DTO;
using react.Models;
using react_backend;
namespace react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController
    {
        public ResponseSuccess POST(Languages request, int userId)
        {

            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                /* veri kontrolleri yapılacak */
                using (var db = new LinkedinContext())
                {
                    var user = db.Users.Where(x => x.Id == userId).Include(x => x.Languages).First();
                    
                    request.UserId = userId;
                    if (request.Id == 0)
                        user.Languages.Add(request);
                    else
                    {
                        var oldEntity = user.Languages.Where(x => x.Id == request.Id).First();
                        oldEntity.Language=request.Language;
                        
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
        public ResponseSuccess DELETE(int LanguageId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                using (var db = new LinkedinContext())
                {
                    var entity = db.Languages.Where(x => x.Id == LanguageId).FirstOrDefault();
                    if (entity == null)
                        throw new Exception("language_not_found");
                    db.Languages.Remove(entity);
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
    }
}