using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.NPCs.Bosses
{
    class AquamentusFireballObject : IGameObject
    {
        public Rectangle ObjectRectangle { get; set; }
        public Enemy EnemyProperty { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        private readonly Interfaces.IDrawable _sprite;
        private readonly IMoveable _point;
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }

        public AquamentusFireballObject(Vector2 position)
        {
            _sprite = NPCSpriteFactory.Instance.CreateAquamentusSprite();
            _point = new AquamentusPoint(position);
            Exists = true;
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y, ((AquamentusSprite)_sprite)._width,
                ((AquamentusSprite)_sprite)._height);
            ObjectProperty = ObjectType.Enemy;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            _sprite.Draw(_point.ObjectPoint, NPCConstants.KeeseFrameTime, gameTime, NPCConstants.EnemyResize, sb);
        }

        public void Update(GameTime gameTime)
        {
            _point.Move(NPCConstants.KeeseVelocity, gameTime);
            ObjectRectangle = new Rectangle((int)_point.ObjectPoint.X, (int)_point.ObjectPoint.Y, ((AquamentusSprite)_sprite)._width,
                ((AquamentusSprite)_sprite)._height);
        }

        public void UndoMovement()
        {

        }

        public void ChangeStats(int damage)
        {
            Exists = false;

        }

        public void Initial()
        {

        }
    }
}
