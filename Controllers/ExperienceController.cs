using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using react.DTO;
using react.Models;
using react_backend;
using Microsoft.EntityFrameworkCore;
namespace react.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController
    {
        [HttpPost]
        public ResponseSuccess POST(Experience request, int UserID) // save and update işlemi
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                using (var db = new LinkedinContext())
                {
                    
                    if (string.IsNullOrEmpty(request.CompanyName))
                        throw new Exception("company_name_error");
                    if (request.StartingDate == null || request.StartingDate == DateTime.MinValue)
                        throw new Exception("starting_date_error");
                    /* diğer veri kontrolleri yapılacak */

                    var user = db.Users.Where(x => x.Id == UserID).Include(s=>s.Experiencies).FirstOrDefault();
                    request.UserId = UserID;
                    if (request.Id == 0)
                    {
                        user.Experiencies.Add(request);
                    }
                    else
                    {
                        var oldEntity = user.Experiencies.Where(x => x.Id == request.Id).FirstOrDefault();
                        oldEntity.CompanyName = request.CompanyName;
                        oldEntity.StartingDate = request.StartingDate;
                        oldEntity.EndDate = request.EndDate;
                        oldEntity.Location = request.Location;
                        oldEntity.Position = request.Position;
                        oldEntity.Description = request.Description;
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
        public ResponseSuccess DELETE(int ExperienceId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                using (var db = new LinkedinContext())
                {
                    var entity = db.Experiencies.Where(x => x.Id == ExperienceId).FirstOrDefault();
                    if (entity == null)
                        throw new Exception("experience_not_found");
                    db.Experiencies.Remove(entity);
                    db.SaveChanges();
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