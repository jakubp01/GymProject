using System.ComponentModel.DataAnnotations;

namespace GymProject.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Imie I Naziwsko")]
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Opis Klienta")]
        public string Description { get; set; }


    }
}
