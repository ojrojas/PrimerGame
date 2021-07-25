using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects.Base
{
    public class BaseGameObject
    {
        protected Texture2D _texture;
        public int zIndex { get; set; }
        protected Vector2 _position = Vector2.One;

        public int Width => _texture.Width;
        public int Height => _texture.Height;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public virtual void OnNotify(Events eventTypes) { }
    }
}