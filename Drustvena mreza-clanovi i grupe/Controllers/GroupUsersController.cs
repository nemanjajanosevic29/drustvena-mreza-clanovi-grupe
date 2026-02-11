using Drustvena_mreza_clanovi_i_grupe.Models;
using Drustvena_mreza_clanovi_i_grupe.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drustvena_mreza_clanovi_i_grupe.Controllers
{
    [Route("api/groups/{groupId}/users")]
    [ApiController]
    public class GroupUsersController : ControllerBase
    {
        private UserRepository userRepository = new UserRepository();
        private GroupRepository groupRepository = new GroupRepository();
        private GroupUsersRepository groupUsersRepository = new GroupUsersRepository();

        [HttpGet]
        public ActionResult<List<User>> GetUsersByGroup(int groupId)
        {
            if (!GroupRepository.Data.ContainsKey(groupId))
            {
                return NotFound();
            }

            Group group = GroupRepository.Data[groupId];
            return Ok(group.Korisnici);
        }
    }
}
