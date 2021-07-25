using Core.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects
{
    public class TerrainBackground : BaseGameObject
    {
        private float SCROLLING_SPEED = 2f;

        public TerrainBackground(Texture2D texture)
        {
            _texture = texture;
            _position = new Vector2(0, 0);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var viewPort = spriteBatch.GraphicsDevice.Viewport;
            var sourceRectangle = new Rectangle(0, 0, _texture.Width, _texture.Height);
            for (int nbVertical = -1; nbVertical < viewPort.Height / _texture.Height + 1; nbVertical++)
            {
                var y = (int)_position.Y + nbVertical * _texture.Height;
                for (int nbHorizontal = 0; nbHorizontal < viewPort.Width / _texture.Width + 1; nbHorizontal++)
                {
                    var x = (int)_position.X + nbHorizontal * _texture.Width;
                    var destRectangle = new Rectangle(x, y, _texture.Width, _texture.Height);
                    spriteBatch.Draw(_texture, destRectangle, sourceRectangle, Color.White);
                }
            }
            _position.Y = (int)(_position.Y + SCROLLING_SPEED) % _texture.Height;
        }
    }
}