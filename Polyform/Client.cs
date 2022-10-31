using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Polyform
{
    internal class Client
    {

        private IWindow _window;

        internal Client()
        {

            var windowOptions = WindowOptions.Default;
            windowOptions.Size = new Vector2D<int>(1280, 720);
            windowOptions.Title = "Polyform";

            _window = Window.Create(windowOptions);

        }

        internal void Run()
        {
            _window.Run();
        }

    }
}
