using GameFacto.TestProject.Application.Builders.Abstract;
using GameFacto.TestProject.Application.Models;

namespace GameFacto.TestProject.Application.Builders.Concrete
{
    public class MultiRoleStatusBuilder : StatusBuilder
    {
        public override Status GenerateStatus(AppUser activeUser, string roles)
        {
            Status status = new Status();
            var acceptedRoles = roles.Split(',');
            foreach (var role in acceptedRoles)
            {
                if (activeUser.Roles.Contains(role))
                {
                    status.AccessStatus = true;
                    break;
                }
            }

            return status;
        }
    }
}