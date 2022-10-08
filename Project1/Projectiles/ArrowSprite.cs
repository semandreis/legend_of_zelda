using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Projectiles
{
    class ArrowSprite : Interfaces.IDrawable
    {
        public Rectangle SourceRectangle { get; set; }
        private readonly Texture2D _texture;
        private readonly Rectangle[] _sourceRectangles =
            { ProjectileConstants.ArrowFront, ProjectileConstants.ArrowSide, ProjectileConstants.ArrowBoom };
        private static SpriteEffects _effects;
        private readonly float _lifespan;
        private float _timer;

        private void SetDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    SourceRectangle = _sourceRectangles[0];
                    _effects = SpriteEffects.FlipVertically;
                    break;
                case Direction.Left:
                    SourceRectangle = _sourceRectangles[1];
                    _effects = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.Right:
                    SourceRectangle = _sourceRectangles[1];
                    _effects = SpriteEffects.None;
                    break;
                case Direction.Up:
                    SourceRectangle = _sourceRectangles[0];
                    _effects = SpriteEffects.None;
                    break;
                default:
                    break;
            }
        }

        public ArrowSprite(Texture2D texture, Direction direction, float lifespan)
        {
            _texture = texture;
            _lifespan = lifespan;
            SetDirection(direction);
        }

        public void Draw(Vector2 position, int frameTime, GameTime gameTime, float scale, SpriteBatch sb)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= _lifespan)
            {
                SourceRectangle = _sourceRectangles[2];
            }

            sb.Draw(_texture, position, SourceRectangle, Color.White * Globals.Opacity, 0f, Vector2.Zero, scale, _effects, ProjectileConstants.ProjectileLayer);
        }
    }
}
