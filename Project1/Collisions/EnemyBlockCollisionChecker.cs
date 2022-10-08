using System;
using System.Collections.Generic;
using System.Text;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class EnemyBlockCollisionChecker : ICollisionCheckerSingle
    {

        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
            if (object1.ObjectProperty.Equals(ObjectType.Enemy) && object2.ObjectProperty.Equals(ObjectType.Unmoveable))
            {
                //Enemy stops moving when approaching an unmovable block
                action = new EnemyBlockCollisionHandler();
                action.Handle(object1, object2, direction);
            }
            else if (object1.ObjectProperty.Equals(ObjectType.Unmoveable) && object2.ObjectProperty.Equals(ObjectType.Enemy))
            {
                //Enemy stops moving when approaching an unmovable block
                action = new EnemyBlockCollisionHandler();
                action.Handle(object2, object1, direction);
            }
        }
    }
}
