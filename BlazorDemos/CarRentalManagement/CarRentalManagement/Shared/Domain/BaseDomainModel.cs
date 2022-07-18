namespace CarRentalManagement.Shared.Domain
{

    public class BaseDomainModel
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; } = "Unknown";

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string UpdatedBy { get; set; } = "Unknown";
    }

}
