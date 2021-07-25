using System.Collections.Generic;
using Core.Commands.Base;
using Microsoft.Xna.Framework.Input;

namespace Core.Mappers.Base
{
    public interface IBaseInputMapper
    {
        IEnumerable<IBaseInputCommand> GetGamePadState(GamePadState gamePadState);
        IEnumerable<IBaseInputCommand> GetKeyboardState(KeyboardState keyboardState);
        IEnumerable<IBaseInputCommand> GetMouseState(MouseState mouseState);
    }

    public class BaseInputMapper : IBaseInputMapper
    {
        public virtual IEnumerable<IBaseInputCommand> GetKeyboardState(KeyboardState keyboardState)
        {
            return new List<IBaseInputCommand>();
        }
        public virtual IEnumerable<IBaseInputCommand> GetMouseState(MouseState mouseState)
        {
            return new List<IBaseInputCommand>();
        }
        public virtual IEnumerable<IBaseInputCommand> GetGamePadState(GamePadState gamePadState)
        {
            return new List<IBaseInputCommand>();
        }
    }
}