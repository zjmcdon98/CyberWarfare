using CyberWarfare.Models;
using CyberWarfare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace Cyberwarfare.WebAPI.Controllers
{
    [Authorize]
    public class DataCollectController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            DataCollectService dataCollectService = CreateDataCollectService();
            var dataCollection = dataCollectService.GetDataCollection();
            return Ok(dataCollection);
        }

        public IHttpActionResult Get(int id)
        {
            DataCollectService dataCollectService = CreateDataCollectService();
            var dataCollect = dataCollectService.GetDataCollectById(id);
            return Ok(dataCollect);
        }

        public IHttpActionResult Post(DataCollectCreate dataCollect)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDataCollectService();

            if (!service.CreateDataCollectItem(dataCollect))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DataCollectEdit dataCollect)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDataCollectService();

            if (!service.UpdateDataCollectItem(dataCollect))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDataCollectService();

            if (!service.DeleteDataCollectItem(id))
                return InternalServerError();

            return Ok();
        }

        private DataCollectService CreateDataCollectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dataCollectService = new DataCollectService(userId);
            return dataCollectService;
        }
    }
}
