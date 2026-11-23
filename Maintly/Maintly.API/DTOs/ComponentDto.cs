using Maintly.API.Models;

namespace Maintly.API.DTOs
{
    public class ComponentDto
    {
    }

    public class CreateComponentDto
    {
        public string Name { get; set; }
        public TypeOfComponent ComponentType { get; set; }
        public int ProcessId { get; set; }
    }
    public class UpdateComponentDto
    {
        public string Name { get; set; }
        public TypeOfComponent ComponentType { get; set; }
    }
}
