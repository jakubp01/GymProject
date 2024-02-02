namespace GymProject.Models
{
    public class SingleEntry
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public DateTime EntryDate { get; set; }

        public string Description { get; set; }

        public int EntryPrice { get; set; }
    }
}
