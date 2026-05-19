using HRMS.Domain.Common;


namespace HRMS.Domain.Entities.Recruitment
{
    public class InterviewRound : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public int RoundNumber { get; set; }
        public string RoundType { get; set; } = string.Empty; // e.g., HR, Technical, Managerial
        public DateTime ScheduledAt { get; set; }
        public Guid InterviewerId { get; set; }
        public string? Mode { get; set; } // e.g., In-person, Video Call
        public string? MeetingLink { get; set; }
        public string Status { get; set; } = "Scheduled"; // e.g., Scheduled, Completed, Cancelled
        public string? Feedback { get; set; }
        public int? Rating { get; set; } // e.g., 1 to 5
        public string? Result { get; set; } // e.g., Pass, Fail, Hold

        public JobApplication JobApplication { get; set; } = null!;
        public HRMS.Domain.Entities.Employee.Employee Interviewer { get; set; } = null!;
    }
}
