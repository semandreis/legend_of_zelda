using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Bosses
{
    class AquamentusObject : IGameObject
    {
        public Rectangle ObjectRectangle { get; set; }
        public Enemy EnemyProperty { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private Interfaces.IDrawable _sprite;
        private IMoveable _point;
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
        public AquamentusObject (Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateAquamentusSprite();
            _point = new AquamentusPoint(position);
            _npcStats = new NPCStats(NPCConstants.BossHealth);
            _initialPoint = position;
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.Enemy;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, 100, gameTime, NPCConstants.EnemyResize, sb);
        }

        public void Update(GameTime gameTime)
        {
            _point.Move(NPCConstants.KeeseVelocity, gameTime);
            SetRectangle();
        }

        public void UndoMovement()
        {
            _point.UndoMove();
        }

        public void ChangeStats(int change)
        {
            if(!_npcStats.ChangeStats(change))
            {
                _sprite = NPCSpriteFactory.Instance.CreateBossDeathState(this);
                _point = new StaticPoint(_point.ObjectPoint);
            }
        }

        public void Initial()
        {
            _point = new AquamentusPoint(_initialPoint);
            SetRectangle();
        }
    }
}
