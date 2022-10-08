using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.NPCs.Enemies
{
    class GoriyaSpriteLeft : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private int _frame;
        private readonly int _initialFrame;
        private readonly int _maxFrame;
        public readonly int _height;
        public readonly int _width;
        private int _timeSinceLastFrame = 0;
        private readonly Texture2D _texture;
        private readonly SpriteEffects _effects;

        public GoriyaSpriteLeft (Texture2D texture, int height, int width, int frame)
        {
            _initialFrame = frame;
            _frame = _initialFrame;
            _maxFrame = frame + 16;
            _texture = texture;
            _height = height;
            _width = width;
            _effects = SpriteEffects.FlipHorizontally;
        }

        private void SetNextFrame(int frameTime)
        {
            _timeSinceLastFrame -= frameTime;
            _frame += 16;
        }

        private void SetInitialFrame()
        {
            _frame = _initialFrame;
        }

        private void UpdateFrame(int frameTime, GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (_timeSinceLastFrame > frameTime)
            {
                SetNextFrame(frameTime);
            }

            if (_frame > _maxFrame)
            {
                SetInitialFrame();
            }
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            UpdateFrame(frameTime, gameTime);
            SourceRectangle = new Rectangle(_frame, 0, _width, _height);
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, NPCConstants.EnemyLayer);
        }
        public void Update()
        {

        }
    }
}
