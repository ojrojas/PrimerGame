using Core.Objects.Base;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Objects
{
    public class SplashImage : BaseGameObject
    {
        public SplashImage(Texture2D texture)
        {
            _texture = texture;
        }
    }
}