using Silk.NET.Vulkan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyform.Game
{
    internal record Stats(
        float Attack,
        float PPS,
        int Finesse
    );

    internal abstract class Player
    {
        private Board _board;
        private Stats _stats; 
    }
}
