using System.Collections.Generic;
using Core.Commands;
using Core.Commands.Base;
using Core.Mappers.Base;
using Microsoft.Xna.Framework.Input;

namespace Core.Mappers
{
    public class GamePlayInputMapper : IBaseInputMapper
    {
        public  IEnumerable<IBaseInputCommand> GetGamePadState(GamePadState gamePadState)
        {
            var commands = new List<IBaseInputCommand>();
            if (gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.GameExit());
            }

            if (gamePadState.Buttons.Start == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.GamePause());
            }

            if (gamePadState.DPad.Right == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveRight());
            }

            if (gamePadState.DPad.Left == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveLeft());
            }

            if (gamePadState.DPad.Up == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveUp());
            }

            if (gamePadState.DPad.Down == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveDown());
            }


            if (gamePadState.Buttons.A == ButtonState.Pressed)
            {
                commands.Add(new GamePlayInputCommand.PlayerShoots());
            }

            return commands;
        }

        public IEnumerable<IBaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<GamePlayInputCommand>();
            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new GamePlayInputCommand.GameExit());
            }

            if (state.IsKeyDown(Keys.Right))
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveRight());
            }

            if (state.IsKeyDown(Keys.Left))
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveLeft());
            }

            if (state.IsKeyDown(Keys.Up))
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveUp());
            }

            if (state.IsKeyDown(Keys.Down))
            {
                commands.Add(new GamePlayInputCommand.PlayerMoveDown());
            }

            if (state.IsKeyDown(Keys.Space))
            {
                commands.Add(new GamePlayInputCommand.PlayerShoots());
            }

            return commands;
        }

        public IEnumerable<IBaseInputCommand> GetMouseState(MouseState mouseState)
        {
            var commands = new List<GamePlayInputCommand>();

            // if (mouseState.X(Keys.Right))
            // {
            //     commands.Add(new GamePlayInputCommand.PlayerMoveRight());
            // }

            // if (mouseState.IsKeyDown(Keys.Left))
            // {
            //     commands.Add(new GamePlayInputCommand.PlayerMoveLeft());
            // }

            // if (mouseState.IsKeyDown(Keys.Space))
            // {
            //     commands.Add(new GamePlayInputCommand.PlayerShoots());
            // }

            return commands;
        }
    }
}