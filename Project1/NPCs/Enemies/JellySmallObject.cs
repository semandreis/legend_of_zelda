﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class JellySmallObject : IGameObject
    {
        public Rectangle ObjectRectangle { get; set; }
        public Enemy EnemyProperty { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private Interfaces.IDrawable _sprite;
        private IMoveable _point;
        private Vector2 _previousPoint;
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }
        private readonly NPCStats _npcStats;
        private readonly Vector2 _initialPoint;

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * NPCConstants.EnemyResize),
                (int)(_sprite.SourceRectangle.Height * NPCConstants.EnemyResize));
        }
        public JellySmallObject (Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateJellySmallSprite();
            _point = new JellySmallPoint(position);
            _previousPoint = _point.ObjectPoint;
            _initialPoint = position;
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.Enemy;
            EnemyProperty = Enemy.JellySmall;
            if (Globals.HardMode)
            {
                _npcStats = new NPCStats(NPCConstants.HardModeEnemyHealthSmall);
            }
            else
            {
                _npcStats = new NPCStats(NPCConstants.SmallEnemyHealth);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, NPCConstants.KeeseFrameTime, gameTime, NPCConstants.EnemyResize, sb);
            _previousPoint = _point.ObjectPoint;
        }

        public void Update(GameTime gameTime)
        {
            _point.Move(NPCConstants.KeeseVelocity, gameTime);
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
            _point = new JellySmallPoint(_initialPoint);
            SetRectangle();
        }
    }
}
