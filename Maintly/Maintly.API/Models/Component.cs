namespace Maintly.API.Models
{
    public class Component
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public int ProcessId { get; private set; }
        public TypeOfComponent ComponentType { get; private set; }

        public Component(string name, TypeOfComponent componentType, int processId)
        {
            Name = name;
            ComponentType = componentType;
            ProcessId = processId;
        }

        public void Update(string name, TypeOfComponent componentType)
        {
            Name = name;
            ComponentType = componentType;
        }
    }

    public enum TypeOfComponent
    {
        Laser,
        BCR
    }
}
