using System;
using System.Collections.Generic;
using Zelda.General;
using Zelda.Interfaces;
using System.Text;

namespace Zelda.Collisions
{
    class WallCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
                        if (object1.ObjectProperty.Equals(ObjectType.Wall) || object2.ObjectProperty.Equals(ObjectType.Wall))
            {
                action = new WallCollisionHandler();
                action.Handle(object2, object1, direction);
            }
        }
    }
}
