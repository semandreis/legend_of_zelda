using System;
using System.Collections.Generic;
using System.Text;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class PlayerAndEnemyCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
            if ((object1.ObjectProperty.Equals(ObjectType.Player) && object2.ObjectProperty.Equals(ObjectType.Enemy))
                || object1.ObjectProperty.Equals(ObjectType.Enemy) && object2.ObjectProperty.Equals(ObjectType.Player))
            {
                //Link gets hurt
                if (object1.ObjectProperty.Equals(ObjectType.Player))
                {
                    action = new PlayerEnemyCollisionHandler();
                }
                else
                {
                    action = new EnemyPlayerCollisionHandler();
                }
                action.Handle(object1, object2, direction);

            }
            
        }

    }
}
