using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class DarknutObject : IGameObject
    {
        public Rectangle ObjectRectangle { get; set; }
        public Enemy EnemyProperty { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private Interfaces.IDrawable _sprite;
        private IMoveable _point;
        private Vector2 _previousPoint;
        private readonly Random _random;
        private int _timeSinceMovement = 0;
        private int _num;
        private bool _moving;
        private readonly NPCStats _npcStats;
        private readonly Vector2 _initialPoint;

        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * NPCConstants.EnemyResize),
                (int)(_sprite.SourceRectangle.Height * NPCConstants.EnemyResize));
        }

        public DarknutObject(Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateDarknutRightSprite();
            _point = new DarknutPoint(position);
            _initialPoint = position;
            _npcStats = new NPCStats(NPCConstants.HardModeEnemyHealthNormal);

            _previousPoint = _point.ObjectPoint;
            ((DarknutPoint)_point).DarknutDirection = Direction.Right;
            Exists = true;
            ObjectProperty = ObjectType.Enemy;
            _random = new Random();
            _num = _random.Next(3);
            _moving = true;
            SetRectangle();
            EnemyProperty = Enemy.Darknut;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, NPCConstants.DarknutFrameTime, gameTime, NPCConstants.EnemyResize, sb);
            _previousPoint = _point.ObjectPoint;
        }

        private void CreateSpriteDirection()
        {
            if (_num == 0)
            {
                _sprite = NPCSpriteFactory.Instance.CreateDarknutRightSprite();
                ((DarknutPoint)_point).DarknutDirection = Direction.Right;
            }
            else if (_num == 1)
            {
                _sprite = NPCSpriteFactory.Instance.CreateDarknutLeftSprite();
                ((DarknutPoint)_point).DarknutDirection = Direction.Left;
            }
            else
            {
                ((DarknutPoint)_point).DarknutDirection = Direction.None;
            }
        }

        private void ChangeDirection(GameTime gameTime)
        {
            _timeSinceMovement += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeSinceMovement > NPCConstants.DarknutMovementTime)
            {
                _num = _random.Next(5);
                _moving = false;
                CreateSpriteDirection();
                _timeSinceMovement -= NPCConstants.DarknutMovementTime;
            }
            else
            {
                _moving = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            ChangeDirection(gameTime);
            if (_moving)
            {
                _point.Move(NPCConstants.DarknutVelocity, gameTime);
            }
            SetRectangle();
        }

        public void UndoMovement()
        {
            _point.ObjectPoint = _previousPoint;
        }

        public void ChangeStats(int change)
        {
            if (!_npcStats.ChangeStats(change))
            {
                _sprite = NPCSpriteFactory.Instance.CreateEnemyDeathState(this);
                _point = new StaticPoint(_point.ObjectPoint);
            }
            _point.TakeDamage();
        }

        public void Initial()
        {
            _point = new DarknutPoint(_initialPoint);
            SetRectangle();
        }
    }
}
