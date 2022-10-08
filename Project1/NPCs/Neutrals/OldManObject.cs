using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Neutrals
{
    class OldManObject : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private readonly Interfaces.IDrawable _sprite;
        private readonly IMoveable _point;
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        private void SetRectangle()
        {
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y,
                (int)(_sprite.SourceRectangle.Width * NPCConstants.EnemyResize),
                (int)(_sprite.SourceRectangle.Height * NPCConstants.EnemyResize));
        }
        public OldManObject (Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateOldManSprite();
            _point = new OldManPoint(position);
            Exists = true;
            SetRectangle();
            ObjectProperty = ObjectType.Unmoveable;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, NPCConstants.KeeseFrameTime, gameTime, NPCConstants.EnemyResize, sb);
        }

        public void Update(GameTime gameTime)
        {
            _point.Move(Vector2.Zero, gameTime);
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
