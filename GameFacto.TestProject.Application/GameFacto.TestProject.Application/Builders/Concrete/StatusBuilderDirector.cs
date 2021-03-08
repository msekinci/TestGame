using GameFacto.TestProject.Application.Builders.Abstract;
using GameFacto.TestProject.Application.Models;

namespace GameFacto.TestProject.Application.Builders.Concrete{
    public class StatusBuilderDirector{
        private StatusBuilder builder;
        public StatusBuilderDirector(StatusBuilder builder)
        {
            this.builder=builder;
        }

        public Status GenerateStatus(AppUser activeUser, string roles){
            return builder.GenerateStatus(activeUser,roles);
        }


    }
}