using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Environment;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class DoorProjectileCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
                        if (object1.ObjectProperty.Equals(ObjectType.Portal) || object2.SubProperty.Equals(SubType.Bomb))
            {
                switch (object1.SubProperty)
                {
                    case SubType.BombDoor1:
                        if (((BombDoorObject1)object1).IsLocked)
                        {
                            Globals.SoundManager.PlaySound("door");

                            ((BombDoorObject1)object1).UnLockDoor();
                            action = new DoorProjectileCollisionHandler();
                        }
                        break;

                    case SubType.BombDoor2:
                        if (((BombDoorObject2)object1).IsLocked)
                        {

                            ((BombDoorObject2)object1).UnLockDoor();
                            action = new DoorProjectileCollisionHandler();
                        }
                        break;
                }
            }
        }
    }
}
