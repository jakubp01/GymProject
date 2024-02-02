namespace GymProject.Models
{
    public class Carnet
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime DueDate { get; set; }

        public int CarnetType { get; set; }

        public int Price { get; set; }
    }
}
