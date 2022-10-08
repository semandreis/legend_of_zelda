using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.NPCs.Enemies
{
    class TrapSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly int _frame;
        public readonly int _height;
        public readonly int _width;
        private readonly Texture2D _texture;

        public TrapSprite (Texture2D texture, int height, int width, int frame)
        {
            _frame = frame;
            _texture = texture;
            _height = height;
            _width = width;
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            Rectangle SourceRectangle = new Rectangle(_frame, 0, _width, _height);
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, NPCConstants.EnemyLayer);
        }
        public void Update()
        {

        }
    }
}
