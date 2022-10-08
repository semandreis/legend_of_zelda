using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zelda.NPCs.Bosses
{
    class DodongoSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private int _frame;
        private readonly int _initialFrame;
        private readonly int _maxFrame;
        public readonly int _height;
        public readonly int _width;
        private static SpriteEffects _effects;
        private int _timeSinceLastFrame = 0;
        private readonly Texture2D _texture;
        private float _timer;

        public DodongoSprite(Texture2D texture, int height, int width, int frame)
        {
            _initialFrame = frame;
            _effects = SpriteEffects.FlipHorizontally;
            _frame = _initialFrame;
            _maxFrame = frame + 34 * 2;
            _texture = texture;
            _height = height;
            _width = width;
            _timer = 0;
        }

        private void SetNextFrame(int frameTime)
        {
            _timeSinceLastFrame -= frameTime;
            _frame += 34;
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

        private static void FlipSprite()
        {
            if (_effects == SpriteEffects.None)
            {
                _effects = SpriteEffects.FlipHorizontally;
                Globals.SoundManager.PlaySound("boss2");
            }
            else
            {
                _effects = SpriteEffects.None;
            }
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= NPCConstants.DodongoMovementTime)
            {
                FlipSprite();
                _timer = 0;

            }

            UpdateFrame(frameTime, gameTime);
            SourceRectangle = new Rectangle(_frame, 56, _width, _height);
            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, NPCConstants.EnemyLayer);
        }
        public void Update()
        {

        }
    }
}
