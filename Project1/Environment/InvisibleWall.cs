using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Environment
{
    class InvisibleWall : IGameObject
    {
        public Enemy EnemyProperty { get; set; }
        public Rectangle ObjectRectangle { get; set; }
        public SubType SubProperty { get; set; }
        public bool Exists { get; set; }
        public SoundType SoundProperty { get; set; }
        public ObjectType ObjectProperty { get; set; }


        public InvisibleWall()
        {
            Exists = true;
            ObjectProperty = ObjectType.Wall;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {

        }

        public void Update(GameTime gameTime)
        {

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
