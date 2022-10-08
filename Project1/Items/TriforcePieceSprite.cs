using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Items
{
    class TriforcePieceSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private int _frame;
        private readonly Rectangle[] _frames;
        private int _ms;

        public TriforcePieceSprite(Texture2D texture)
        {
            _texture = texture;

            _ms = 0;
            _frame = 0;
            _frames = ItemConstants.TriforcePieceFrames;
            SourceRectangle = _frames[_frame];
        }

        private void UpdateFrame()
        {
            _ms++;
            if (_ms > 10)
            {
                _frame = (_frame + 1) % 2;
                _ms = 0;
            }
            SourceRectangle = _frames[_frame];
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            UpdateFrame();
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
