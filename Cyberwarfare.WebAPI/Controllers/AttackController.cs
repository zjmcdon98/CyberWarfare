using ClassWarfare.Models;
using ClassWarfare.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cyberwarfare.WebAPI.Controllers
{
    [Authorize]
    public class AttackController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            AttackService attackService = CreateAttackService();
            var attacks = attackService.GetAttacks();
            return Ok(attacks);
        }

        public IHttpActionResult Get(int id)
        {
            AttackService attackService = CreateAttackService();
            var attack = attackService.GetAttackById(id);
            return Ok(attack);
        }

        public IHttpActionResult Post(AttackCreate attack)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAttackService();

            if (!service.CreateAttack(attack))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AttackEdit attack)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
​
            var service = CreateAttackService();
​
            if (!service.UpdateAttack(attack))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAttackService();
​
            if (!service.DeleteAttack(id))
                return InternalServerError();

            return Ok();
        }

        private AttackService CreateAttackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var attackService = new AttackService(userId);
            return attackService;
        }
    }
}
