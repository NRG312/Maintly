namespace Maintly.API.Models
{
    public class Incident
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string ReportedBy { get; private set; }

        public Incident(string description, string reportedBy)
        {
            Description = description;
            ReportedBy = reportedBy;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
