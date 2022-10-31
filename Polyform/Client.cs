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

        private void OnLoad()
        {



        }

        private void OnRender(double dt)
        {



        }

        private void OnUpdate(double dt)
        {



        }

        internal Client()
        {

            var windowOptions = WindowOptions.Default;
            windowOptions.Size = new Vector2D<int>(1280, 720);
            windowOptions.Title = "Polyform";

            _window = Window.Create(windowOptions);

            _window.Load += OnLoad;
            _window.Render += OnRender;
            _window.Update += OnUpdate;

        }

        internal void Run()
        {
            _window.Run();
        }

    }
}
