using Core.Inputs.Base;
using Core.Mappers;
using Core.Objects;
using Core.State.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Core.State
{
    public class SplashGameState : BaseGameState
    {
        public override void HandleInput(GameTime gameTime)
        {
            var gamePadState = GamePad.GetState(PlayerIndex.One);
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Enter) || gamePadState.Buttons.Start == ButtonState.Pressed)
            {
                SwitchState(new GamePlayState());
            }
            if (keyboardState.IsKeyDown(Keys.Escape) || gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                NotifyEvent(Events.GAME_QUIT);
            }
        }

        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture(@"GameStates\SplashState\splash1")));
        }

        protected override void SetInputManager()
        {
          BaseInputManager = new BaseInputManager(new GamePlayInputMapper());
        }
    }
}