namespace Maintly.API.DTOs
{
    public class ProcessDto
    {
    }

    public class CreateProcessDto
    {
        public string Name { get; set; }
        public int MachineId { get; set; }
    }
    public class UpdateProcessDto
    {
        public string Name { get; set; }
    }
}
