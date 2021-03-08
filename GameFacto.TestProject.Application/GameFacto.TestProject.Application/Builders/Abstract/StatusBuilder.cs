using GameFacto.TestProject.Application.Models;
using GameFacto.TestProject.Application.Builders.Concrete;

namespace GameFacto.TestProject.Application.Builders.Abstract{
    public abstract class StatusBuilder{
        public abstract Status GenerateStatus(AppUser activeUser, string roles); 
    }
}