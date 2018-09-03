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
    public class HonorClass
    {

        public ResponseSuccess POST(Honor request, int userId)
        {

            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                /* veri kontrolleri yapılacak */
                using (var db = new LinkedinContext())
                {
                    var user = db.Users.Where(x => x.Id == userId).Include(x => x.Honors).First();
                    request.UserId = userId;
                    if (request.Id == 0)
                        user.Honors.Add(request);
                    else
                    {
                        var oldEntity = user.Honors.Where(x => x.Id == request.Id).First();
                        oldEntity.Details = request.Details;

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
        public ResponseSuccess DELETE(int HonorId)
        {
            ResponseSuccess responseObject = new ResponseSuccess();
            try
            {
                using (var db = new LinkedinContext())
                {
                    var entity = db.Honors.Where(x => x.Id == HonorId).FirstOrDefault();
                    if (entity == null)
                        throw new Exception("honor_not_found");
                    db.Honors.Remove(entity);
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