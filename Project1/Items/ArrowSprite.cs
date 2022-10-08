using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.Interfaces;

namespace Zelda.Items
{
    class ArrowSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;

        public ArrowSprite(Texture2D texture)
        {
            _texture = texture;
            SourceRectangle = ItemConstants.ArrowRectangle;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
