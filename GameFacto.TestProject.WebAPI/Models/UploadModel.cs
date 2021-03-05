using GameFacto.TestProject.WebAPI.Enums;

namespace GameFacto.TestProject.WebAPI.Models
{
    public class UploadModel
    {
        public string NewName { get; set; }
        public UploadState UploadState { get; set; }
        public string ErrorMessage { get; set; }
    }
}
