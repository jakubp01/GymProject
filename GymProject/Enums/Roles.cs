using System.ComponentModel.DataAnnotations;

namespace GymProject.Enums
{
    public enum Roles
    {

        Admin,
        [Display(Name = "Pracownik")]
        Worker,
        [Display(Name = "Trener")]
        Trainer
    }
}
