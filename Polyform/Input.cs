using Silk.NET.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyform
{
    internal static class Input
    {

        private static IInputContext _inputContext;
        private static List<Dictionary<GameInput, Key>> _binds;

        private static Dictionary<Key, bool> _pressedKeys;
        private static Dictionary<Key, bool> _oldKeys;

        internal static void Init(IInputContext inputContext)
        {
            _inputContext = inputContext;
        }

        internal static void Update()
        {

            _oldKeys = _pressedKeys;
            _pressedKeys.Clear();

            foreach (var keyboard in _inputContext.Keyboards)
            {
                foreach (Key key in Enum.GetValues(typeof(Key)))
                {
                    _pressedKeys[key] = keyboard.IsKeyPressed(key);
                }
            }
            
        }

        internal static bool IsKeyDown(Key key)
        {
            return _pressedKeys[key];
        }

        internal static bool IsKeyPressed(Key key)
        {
            return _pressedKeys[key] && (_oldKeys[key] != _pressedKeys[key]);
        }

        internal static bool IsKeyReleased(Key key)
        {
            return (!_pressedKeys[key]) && (_oldKeys[key] != _pressedKeys[key]);
        }

        internal static List<bool> IsGameInputDown(GameInput input)
        {
            List<bool> plys = new List<bool>();
            foreach (var ply in _binds)
            {
                 plys.Add(IsKeyDown(ply[input]));
            }
            return plys;
        }

    }
}
