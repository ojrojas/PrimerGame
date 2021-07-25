using System;
using System.Collections.Generic;
using System.Linq;
using Core.Inputs.Base;
using Core.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Core.State.Base
{
    public abstract class BaseGameState : IBaseGameState
    {
        private readonly IList<BaseGameObject> _gameObjects = new List<BaseGameObject>();
        private const string FallbackTexture = "Empty";
        private ContentManager _contentManager;
        protected int _viewportHeight;
        protected int _viewportWidth;

        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<Events> OnEventNotification;

        protected BaseInputManager BaseInputManager { get; set; }

        protected abstract void SetInputManager();

        public abstract void HandleInput(GameTime gameTime);

        public abstract void LoadContent();

        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        protected void NotifyEvent(Events eventType, object argument = null)
        {
            OnEventNotification?.Invoke(this, eventType);
            foreach (var gameObject in _gameObjects)
            {
                gameObject.OnNotify(eventType);
            }
        }

        protected void SwitchState(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.OrderBy(g => g.zIndex))
            {
                gameObject.Render(spriteBatch);
            }
        }

        public void Initialize(ContentManager contentManager, int viewPortWidth, int viewPortHeight)
        {
            _contentManager = contentManager;
            _viewportWidth = viewPortWidth;
            _viewportHeight = viewPortHeight;
            SetInputManager();
        }

        protected Texture2D LoadTexture(string textureName)
        {
            var texture = _contentManager.Load<Texture2D>(textureName);
            return texture ?? _contentManager.Load<Texture2D>(FallbackTexture);
        }

        public virtual void Update(GameTime gameTime) { }

        protected void RemoveGameObject(BaseGameObject baseGameObject)
        {
            _gameObjects.Remove(baseGameObject);
        }
    }
}