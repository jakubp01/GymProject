using System.ComponentModel.DataAnnotations;

namespace GymProject.Enums
{
    public enum CarnetType
    {
        [Display(Name = "Ulgowy")]
        reduced,
        [Display(Name = "Normalny")]
        normal
    }
}
