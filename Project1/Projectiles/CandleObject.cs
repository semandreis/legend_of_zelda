using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class CandleObject : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private readonly Interfaces.IDrawable _sprite;
        private readonly IMoveable _point;
        private readonly float _lifespan;
        private float _timer;
        private Vector2 _velocity;
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * ProjectileConstants.ProjectileResize),
                (int)(_sprite.SourceRectangle.Height * ProjectileConstants.ProjectileResize));
        }

        public CandleObject(Texture2D texture, Vector2 position, Direction direction)
        {
            _point = new CandlePoint(position, direction);
            _lifespan = ProjectileConstants.CandleLifespan;
            _timer = 0;
            _velocity = ProjectileConstants.CandleVelocity;
            _sprite = new CandleSprite(texture);
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.FriendlyProjectile;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, 0, gameTime, ProjectileConstants.ProjectileResize, sb);
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= (_lifespan))
            {
                _velocity = Vector2.Zero;
                if(_timer >= _lifespan + ProjectileConstants.CandleDelay)
                    Exists = false;
            }
            _point.Move(_velocity, gameTime);
            SetRectangle();
        }

        public void UndoMovement()
        {

        }

        public void ChangeStats(int change)
        {

        }

        public void Initial()
        {

        }
    }
}
