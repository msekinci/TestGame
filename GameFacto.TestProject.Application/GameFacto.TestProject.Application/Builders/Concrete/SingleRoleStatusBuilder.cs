using GameFacto.TestProject.Application.Builders.Abstract;
using GameFacto.TestProject.Application.Models;

namespace GameFacto.TestProject.Application.Builders.Concrete
{
    public class SingleRoleStatusBuilder : StatusBuilder
    {
        public override Status GenerateStatus(AppUser activeUser, string roles)
        {
            Status status = new Status();
            if (activeUser.Roles.Contains(roles))
            {
                status.AccessStatus = true;
            }

            return status;
        }
    }
}