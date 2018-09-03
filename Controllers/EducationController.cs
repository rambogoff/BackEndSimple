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
    public class EducationController
    {
        [HttpPost]
        public ResponseSuccess POST(Education request, int userId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                /* veri kontrolleri yapılacak */
                using (var db = new LinkedinContext())
                {
                    var user = db.Users.Where(x => x.Id == userId).Include(s => s.Educations).First();
                    request.UserId = userId;
                    if (request.Id == 0)
                        user.Educations.Add(request);
                    else
                    {
                        var oldEntity = user.Educations.Where(x => x.Id == request.Id).First();
                        oldEntity.Name = request.Name;
                        oldEntity.StartingYear = request.StartingYear;
                        oldEntity.EndYear = request.EndYear;
                        oldEntity.Degree = request.Degree; 
                        oldEntity.Activities=request.Activities;
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
        public ResponseSuccess DELETE(int EducationId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                using (var db = new LinkedinContext())
                {
                    var entity = db.Education.Where(x => x.Id == EducationId).FirstOrDefault();
                    if (entity == null)
                        throw new Exception("education_not_found");
                    db.Education.Remove(entity);
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