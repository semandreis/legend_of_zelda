using System;
using System.Collections.Generic;
using System.Text;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class PlayerMovableBlockCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
                        if (object1.ObjectProperty.Equals(ObjectType.Player) && object2.ObjectProperty.Equals(ObjectType.Moveable))
            {
                //Movable block moves to direction
                GameManager gm = GameManager.GetInstance();
                if (gm.CurrentRoomID == 9)
                {
                    Globals.SpecialBlockMoved = true;
                }
                Console.WriteLine("detected");
                action = new PlayerMovableBlockCollisionHandler();
                action.Handle(object1, object2, direction);
            }
            else if (object1.ObjectProperty.Equals(ObjectType.Moveable) && object2.ObjectProperty.Equals(ObjectType.Player))
            {
                //Movable block moves to direction
                GameManager gm = GameManager.GetInstance();
                if (gm.CurrentRoomID == 9)
                {
                    Globals.SpecialBlockMoved = true;
                }
                Console.WriteLine("detected");
                action = new PlayerMovableBlockCollisionHandler();
                action.Handle(object2, object1, direction);
            }
        }
    }
}
