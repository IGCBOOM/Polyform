using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polyform.Rendering;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace Polyform
{
    internal class Client
    {

        private IWindow _window;
        
        private Renderer _renderer;

        private void OnLoad()
        {

            _renderer = new Renderer(_window);

            IInputContext input = _window.CreateInput();

            input.Keyboards[0].IsKeyPressed();

        }

        private void OnResize(Vector2D<int> newSize)
        {

            _renderer.Resize(newSize);

        }

        private void OnUpdate(double dt)
        {

            _renderer.Update(dt);

        }

        private void OnRender(double dt)
        {

            _renderer.Render(dt);

        }

        internal Client()
        {

            var windowOptions = WindowOptions.Default;
            windowOptions.Size = new Vector2D<int>(1280, 720);
            windowOptions.Title = "Polyform";

            _window = Window.Create(windowOptions);

            _window.Load += OnLoad;
            _window.Resize += OnResize;
            _window.Update += OnUpdate;
            _window.Render += OnRender;

        }

        internal void Run()
        {
            _window.Run();
        }

    }
}
