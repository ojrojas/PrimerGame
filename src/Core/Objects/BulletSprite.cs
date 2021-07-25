using Core.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects
{
    public class BulletSprite : BaseGameObject
    {
        private const float SPEED_BULLET = 10f;
        public BulletSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - SPEED_BULLET);
        }
    }
}