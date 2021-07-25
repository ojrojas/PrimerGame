using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Core.State.Base
{
    public interface IBaseGameState
    {
        event EventHandler<BaseGameState> OnStateSwitched;
        event EventHandler<Events> OnEventNotification;

        void HandleInput(GameTime gameTime);
        void Initialize(ContentManager contentManager, int viewportWidth, int _viewportHeight);
        void LoadContent();
        void Render(SpriteBatch spriteBatch);
        void UnloadContent();
        void Update(GameTime gameTime);
    }
}