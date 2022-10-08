using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.Environment
{
    class BarrierTileSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private readonly int _rows;
        private readonly int _columns;
        private readonly int _frame;
        private readonly int _width;
        private readonly int _height;

        public BarrierTileSprite(Texture2D texture)
        {
            _texture = texture;
            _rows = 3;
            _columns = 4;
            _frame = 1;
            _width = texture.Width / _columns;
            _height = texture.Height / _rows;
            SourceRectangle = new Rectangle(_width * (_frame % _columns), _height * (_frame / _columns), _width, _height);
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, EnvironmentConstants.TileDepth);
        }

    }
}
