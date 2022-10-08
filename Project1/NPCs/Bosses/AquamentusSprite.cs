using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.NPCs.Bosses
{
    class AquamentusSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private int _frame;
        private int _deadFrame;
        private readonly int _initialFrame;
        private readonly int _maxFrame;
        private readonly int _maxDeadFrame;
        public readonly int _height;
        public readonly int _width;
        private int _timeSinceLastFrame = 600;
        private readonly Texture2D _texture;

        public AquamentusSprite (Texture2D texture, int height, int width, int frame)
        {
            _initialFrame = frame;
            _frame = _initialFrame;
            _deadFrame = 261;
            _maxFrame = _frame + 25 * 3;
            _maxDeadFrame = _deadFrame + 31 * 3;
            _texture = texture;
            _height = height;
            _width = width;
            
        }

        private void SetNextFrame(int frameTime)
        {
            _timeSinceLastFrame -= frameTime;
            _frame += 25;
            _deadFrame += 31;
        }

        private void SetInitialFrame()
        {
            _frame = _initialFrame;
            _deadFrame = 261;
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
            SourceRectangle = new Rectangle(_frame, 11, _width, _height);
            //SourceRectangle = new Rectangle(_deadFrame, 226, 25, 35);
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, SpriteEffects.None, NPCConstants.EnemyLayer);
        }

        public void Draw(Vector2 position, GameTime gameTime, float scale, SpriteBatch sb)
        {
            int frameTime = 100;
            UpdateFrame(frameTime, gameTime);
            //SourceRectangle = new Rectangle(_frame, 11, _width, _height);
            SourceRectangle = new Rectangle(_deadFrame, 226, 25, 35);
            sb.Draw(_texture, position, SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, NPCConstants.EnemyLayer);
        }
        public void Update()
        {

        }
    }
}
