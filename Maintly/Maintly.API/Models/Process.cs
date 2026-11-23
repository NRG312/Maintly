namespace Maintly.API.Models
{
    public class Process
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MachineId { get; private set; }
        public List<Component> Components { get; set; } = new();

        public Process(string name, int machineId)
        {
            Name = name;
            MachineId = machineId;
        }
        public void Update(string name)
        {
            Name = name;
        }
    }
}
