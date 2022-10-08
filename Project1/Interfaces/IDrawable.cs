using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Interfaces
{
    public interface IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb);

    }
}
