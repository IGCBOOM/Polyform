using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace Polyform.Rendering
{
    internal class Renderer
    {

        private readonly IWindow _window;
        private readonly GL _gl;

        internal Renderer(IWindow window)
        {

            _window = window;

            _gl = GL.GetApi(_window);
            _gl.ClearColor(Color.AliceBlue);

        }

        internal void Resize(Vector2D<int> newSize)
        {

            _gl.Viewport(newSize);

        }

        internal void Update(double dt)
        {



        }

        internal void Render(double dt)
        {

            _gl.Clear(ClearBufferMask.ColorBufferBit);

        }

    }
}
