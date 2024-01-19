using GameJam2024.Environments;
using GameJam2024.RuneTree;

namespace GameJam2024
{
    public interface  IEnvironmentObject
    {
        public EnvironmentObjectStatus EnvironmentObjectStatus { get; }
        public EnvironmentObjectType EnvironmentObjectType { get; }
        public bool envObjectStatus { get; set; }
        public bool envObjectType { get; set; }

    }
}