using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Enemies
{
    class TrapObject3 : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private readonly Interfaces.IDrawable _sprite;
        private IMoveable _point;
        private Vector2 _previousPoint;
        private readonly Vector2 _initialPoint;
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }
        private readonly NPCStats _npcStats;

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * NPCConstants.EnemyResize),
                (int)(_sprite.SourceRectangle.Height * NPCConstants.EnemyResize));
        }
        public TrapObject3(Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateTrapSprite();
            _point = new TrapPoint3(position);
            _previousPoint = _point.ObjectPoint;
            _initialPoint = position;
            _npcStats = new NPCStats(NPCConstants.InvincibleEnemyHealth);
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.Enemy;
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
                Exists = false;
            }
        }

        public void Initial()
        {
            _point = new TrapPoint3(_initialPoint);
            SetRectangle();
        }
    }
}
