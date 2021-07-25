using System;
using Core.Commands.Base;
using Core.Mappers.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Core.Inputs.Base
{
    public class BaseInputManager
    {
        private readonly IBaseInputMapper _baseInputMapper;

        public BaseInputManager(IBaseInputMapper baseInputMapper)
        {
            _baseInputMapper = baseInputMapper;
        }

        public void GetCommands(Action<IBaseInputCommand> actOnState)
        {
            var keyboardState = Keyboard.GetState();
             foreach(var state in _baseInputMapper.GetKeyboardState(keyboardState))
            {
                actOnState(state);
            }

            var mouseState = Mouse.GetState();
             foreach(var state in _baseInputMapper.GetMouseState(mouseState))
            {
                actOnState(state);
            }

            var gamePadState = GamePad.GetState(PlayerIndex.One);
            foreach (var state in _baseInputMapper.GetGamePadState(gamePadState))
            {
                actOnState(state);
            }
        }
    }
}