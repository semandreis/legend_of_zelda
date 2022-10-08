using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Interfaces
{
    public interface IGameObject
    {
        public ObjectType ObjectProperty { get; set; }
        public Enemy EnemyProperty { get; set; }
        public SubType SubProperty { get; set; }
        public SoundType SoundProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public bool Exists { get; set; }
        void Update(GameTime gameTime);
        void UndoMovement();
        void Initial();
        void ChangeStats(int change);
        void Draw(GameTime gameTime, SpriteBatch sb);
    }
}
