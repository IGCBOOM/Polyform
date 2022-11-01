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
        private static List<Dictionary<GameInput, Key>> _binds = new List<Dictionary<GameInput, Key>>();

        private static Dictionary<Key, bool> _pressedKeys = new Dictionary<Key, bool>();
        private static Dictionary<Key, bool> _oldKeys = new Dictionary<Key, bool>();

        private static List<Dictionary<GameInput, bool>> _pressedInputs = new List<Dictionary<GameInput, bool>>();
        private static List<Dictionary<GameInput, bool>> _oldInputs = new List<Dictionary<GameInput, bool>>();

        private static List<Key> _keys = new List<Key>();

        internal static void Init(IInputContext inputContext)
        {
            _inputContext = inputContext;

            // Creating a key list without the "Unknown" key, so we can iterate through the Key enumerator without errors.
            foreach (Key key in Enum.GetValues(typeof(Key)))
            {
                if (key == Key.Unknown) continue;
                _keys.Add(key);
            }


            // TODO: load binds from file...

            AddNewPlayerBind(new Dictionary<GameInput, Key> { 
                { GameInput.Harddrop, Key.Keypad5 }, 
                { GameInput.Softdrop, Key.Keypad2 }, 
                { GameInput.Left, Key.Keypad1 }, 
                { GameInput.Right, Key.Keypad3 },
                { GameInput.CW, Key.X },
                { GameInput.CCW, Key.Z },
                { GameInput.Flip, Key.D },
                { GameInput.Hold, Key.C }
            });

            AddNewPlayerBind(new Dictionary<GameInput, Key> {
                { GameInput.Harddrop, Key.Number8 },
                { GameInput.Softdrop, Key.I },
                { GameInput.Left, Key.U },
                { GameInput.Right, Key.O },
                { GameInput.CW, Key.W },
                { GameInput.CCW, Key.Q },
                { GameInput.Flip, Key.Number3 },
                { GameInput.Hold, Key.E }
            });

            // END TODO ......

            // init some default vals in here to prevent accessing bad stuff on the first frame...
            foreach (Key key in _keys)
            {
                _pressedKeys[key] = false;
                _oldKeys[key] = false;
            }

        }

        internal static void AddNewPlayerBind(Dictionary<GameInput, Key> binds)
        {
            _pressedInputs.Add(new Dictionary<GameInput, bool>());
            _oldInputs.Add(new Dictionary<GameInput, bool>());
            foreach (GameInput input in Enum.GetValues(typeof(GameInput)))
            {
                _pressedInputs[^1].Add(input, false);
                _oldInputs[^1].Add(input, false);
            }
            _binds.Add(binds);
        }

        internal static void Update()
        {

            // memory leak i hate it
            //_oldKeys = _pressedKeys.ToDictionary(e => e.Key, e => e.Value);

            // this is the alternative
            foreach (var pressedkey in _pressedKeys)
            {
                _oldKeys[pressedkey.Key] = pressedkey.Value;
            }

            _pressedKeys.Clear();

            foreach (var keyboard in _inputContext.Keyboards)
            {
                foreach (Key key in _keys)
                {
                    _pressedKeys[key] = keyboard.IsKeyPressed(key);
                }
            }

            for (int plyI = 0; plyI < _binds.Count; plyI++)
            {
                foreach (var pressedinput in _pressedInputs[plyI])
                {
                    _oldInputs[plyI][pressedinput.Key] = pressedinput.Value;
                }
                _pressedInputs[plyI].Clear();
                foreach (GameInput input in Enum.GetValues(typeof(GameInput)))
                {
                    _pressedInputs[plyI][input] = IsKeyDown(_binds[plyI][input]);
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

        internal static bool IsGameInputDown(GameInput input, int player)
        {
            return _pressedInputs[player][input];
        }

        internal static bool IsGameInputPressed(GameInput input, int player)
        {
            return _pressedInputs[player][input] && (_oldInputs[player][input] != _pressedInputs[player][input]);
        }

        internal static bool IsGameInputReleased(GameInput input, int player)
        {
            return (!_pressedInputs[player][input]) && (_oldInputs[player][input] != _pressedInputs[player][input]);
        }

    }
}
