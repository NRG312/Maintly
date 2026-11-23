namespace Maintly.API.DTOs
{
    public class IncidentDto
    {
    }

    public class CreateIncidentDto
    {
        public string Description { get; private set; }
        public string ReportedBy { get; private set; }
    }

    public class UpdateIncidentDto
    {
        public string Description { get; private set; }
        public string ReportedBy { get; private set; }
    }
}
