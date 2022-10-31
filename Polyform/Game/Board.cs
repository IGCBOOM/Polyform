using Silk.NET.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyform.Game
{
    internal class Board
    {

        internal Vector4D<float> Transform;
        private Mino[,] _board;

        internal Board(Vector2D<int> size)
        {
            _board = new Mino[size.X, size.Y];
        }

    }
}
