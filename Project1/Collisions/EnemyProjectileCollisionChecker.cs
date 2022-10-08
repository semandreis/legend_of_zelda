using System;
using System.Collections.Generic;
using System.Text;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class EnemyProjectileCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {


            if (object1.ObjectProperty.Equals(ObjectType.Enemy) && object2.ObjectProperty.Equals(ObjectType.FriendlyProjectile))
            {
                //Enemy gets hurt
                action = new EnemyProjectileCollisionHandler();
                action.Handle(object1, object2, direction);
            }
            else if (object1.ObjectProperty.Equals(ObjectType.FriendlyProjectile) && object2.ObjectProperty.Equals(ObjectType.Enemy))
            {
                //Enemy gets hurt
                action = new EnemyProjectileCollisionHandler();
                action.Handle(object2, object1, direction);
            }
        }
    }
}
