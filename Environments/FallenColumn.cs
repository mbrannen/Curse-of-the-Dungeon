using GameJam2024.RuneTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2024.Environments
{
    public class FallenColumn : IEnvironmentObject
    {
        private EnvironmentObjectStatus status;
        private EnvironmentObjectType objectType;

        public override EnvironmentObjectStatus envObjectStatus { get; } = EnvironmentObjectStatus.Normal;

        public EnvironmentObjectStatus EnvironmentObjectStatus => throw new NotImplementedException();

        public EnvironmentObjectType EnvironmentObjectType => throw new NotImplementedException();

        public bool envObjectType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IEnvironmentObject.envObjectStatus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
