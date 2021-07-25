using Core.Objects.Base;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects
{
    public class PlayerSprite : BaseGameObject
    {
        private float SPEED_FLY = 3f;
        public PlayerSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void MoveLeft()
        {
            Position = new Vector2(Position.X - SPEED_FLY, Position.Y);
        }

        public void MoveRight()
        {
            Position = new Vector2(Position.X + SPEED_FLY, Position.Y);
        }

        public void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - SPEED_FLY);
        }

        public void MoveDown()
        {
            Position = new Vector2(Position.X, Position.Y + SPEED_FLY);
        }
    }
}