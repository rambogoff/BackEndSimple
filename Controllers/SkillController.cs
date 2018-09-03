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
    public class SkillController
    {
        public ResponseSuccess POST(Skill request, int userId)
        {

            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                /* veri kontrolleri yapılacak */
                using (var db = new LinkedinContext())
                {
                    var user = db.Users.Where(x => x.Id == userId).Include(x => x.Skills).First();
                    request.UserId = userId;
                    if (request.Id == 0)
                        user.Skills.Add(request);
                    else
                    {
                        var oldEntity = user.Skills.Where(x => x.Id == request.Id).First();
                        oldEntity.Name=request.Name;
                        
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
        public ResponseSuccess DELETE(int SkillId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                using (var db = new LinkedinContext())
                {
                    var entity = db.Skills.Where(x => x.Id == SkillId).FirstOrDefault();
                    if (entity == null)
                        throw new Exception("skill_not_found");
                    db.Skills.Remove(entity);
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