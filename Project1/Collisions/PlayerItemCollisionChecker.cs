using System;
using System.Collections.Generic;
using System.Text;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class PlayerItemCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
            if (object1.ObjectProperty.Equals(ObjectType.Player) && object2.ObjectProperty.Equals(ObjectType.Item))
            {
                //Link Pick Item up + animation
                action = new PlayerItemCollisionHandler();
                action.Handle(object1, object2, direction);
            }
            else if (object1.ObjectProperty.Equals(ObjectType.Item) && object2.ObjectProperty.Equals(ObjectType.Player))
            {
                //Link Pick Item up + animation
                action = new PlayerItemCollisionHandler();
                action.Handle(object2, object1, direction);
            }
        }
    }
}
