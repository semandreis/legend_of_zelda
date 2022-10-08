using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.NPCs.Enemies
{
    class GoriyaSpriteUpDown : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly int _frame;
        public readonly int _height;
        public readonly int _width;
        private int _timeSinceLastFrame = 0;
        private readonly Texture2D _texture;
        private SpriteEffects _effects;

        public GoriyaSpriteUpDown (Texture2D texture, int height, int width, int frame)
        {
            _frame = frame;
            _texture = texture;
            _height = height;
            _width = width;
            _effects = SpriteEffects.None;
        }

        private void FlipSprite()
        {
            if (_effects == SpriteEffects.None)
            {
                _effects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                _effects = SpriteEffects.None;
            }
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeSinceLastFrame > frameTime)
            {
                _timeSinceLastFrame = 0;
                FlipSprite();
            }
            SourceRectangle = new Rectangle(_frame, 0, _width, _height);
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, NPCConstants.EnemyLayer);
        }
        public void Update()
        {

        }
    }
}
