using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Projectiles
{
    class BombObject : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }

        private readonly Interfaces.IDrawable _sprite;
        private readonly IMoveable _point;
        private readonly float _lifespan;
        private float _timer;
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * ProjectileConstants.ProjectileResize),
                (int)(_sprite.SourceRectangle.Height * ProjectileConstants.ProjectileResize));
        }

        public BombObject(Texture2D texture, Vector2 position, Direction direction)
        {
            _point = new BombPoint(position, direction);
            _lifespan = ProjectileConstants.BombLifespan;
            _timer = 0;
            _sprite = new BombSprite(texture, _lifespan);
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.FriendlyProjectile;
        }


        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
             _sprite.Draw(_point.ObjectPoint, ProjectileConstants.BombFrameTime, gameTime, ProjectileConstants.ProjectileResize, sb);
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
         
            if (_timer >= (_lifespan))
            {
                Exists = false;
            }

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
