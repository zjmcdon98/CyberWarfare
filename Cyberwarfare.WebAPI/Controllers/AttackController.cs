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
        public IHttpActionResult Get()
        {
            AttackService attackService = CreateAttackService();
            var attacks = attackService.GetAttacks();
            return Ok(attacks);
        }
        private AttackService CreateAttackService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var attackService = new AttackService(userId);
            return attackService;
        }
    }
}
