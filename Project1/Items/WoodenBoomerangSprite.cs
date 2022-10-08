using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Items
{
    class WoodenBoomerangSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;

        public WoodenBoomerangSprite(Texture2D texture)
        {
            _texture = texture;
            SourceRectangle = ItemConstants.WoodenBoomerangRectangle;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
