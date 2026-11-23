namespace Maintly.API.Models
{
    public class Machine
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Process> Processes { get; set; } = new();

        public Machine(string name)
        {
            Name = name;
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}
