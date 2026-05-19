using HRMS.Domain.Common;

namespace HRMS.Domain.Entities.Recruitment
{
    public class OfferLetter : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public decimal OfferedSalary { get; set; }
        public DateTime JoinngDate { get; set; }
        public DateTime OfferDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public string Status { get; set; } = "Sent"; // e.g., Pending, Accepted, Rejected
        public string? DocumentUrl { get; set; } // URL to the offer letter document
        public JobApplication Application { get; set; } = null!;
    }
}
