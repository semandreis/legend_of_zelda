using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Bosses
{
    class DodongoObject : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
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
        public DodongoObject (Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateDodongoSprite();
            _point = new DodongoPoint(position);
            _initialPoint = position;
            _npcStats = new NPCStats(NPCConstants.BossHealth);
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.Enemy;
        }


        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, NPCConstants.KeeseFrameTime, gameTime, NPCConstants.EnemyResize, sb);
        }

        public void Update(GameTime gameTime)
        {
            _point.Move(NPCConstants.DodongoVelocity, gameTime);
            SetRectangle();
        }

        public void UndoMovement()
        {
            _point.UndoMove();
        }

        public void ChangeStats(int change)
        {
            if (!_npcStats.ChangeStats(change))
            {
                _sprite = NPCSpriteFactory.Instance.CreateBossDeathState(this);
                _point = new StaticPoint(_point.ObjectPoint);
            }
        }

        public void Initial()
        {
            _point = new DodongoPoint(_initialPoint);
            SetRectangle();
        }
    }
}
