using System;
using System.Collections.Generic;
using System.Text;
using Zelda.Environment;
using Zelda.GameState;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.Collisions
{
    class PlayerUnLockedDoorCollisionChecker : ICollisionCheckerSingle
    {
        public void CheckCollisionSingle(IGameObject object1, IGameObject object2, Direction direction, ICollisionSingle action)
        {
            if (object1.ObjectProperty.Equals(ObjectType.Player) && object2.ObjectProperty.Equals(ObjectType.Portal))
            {
                GameManager gm = GameManager.GetInstance();
                switch (object2.SubProperty)
                {
                    case SubType.None:
                        action = new PlayerUnLockedDoorCollisionHandler();
                        action.Handle(object1, object2, direction);
                        break;

                    case SubType.DoorLocked:
                        if (((DoorWithKeyObject)object2).IsLocked)
                        {
                            if (gm.Player.PlayerInventory.ItemCount(Item.Key) > 0)
                            {
                                gm.Player.PlayerInventory.UseItem(Item.Key);
                                ((DoorWithKeyObject)object2).UnLockDoor();
                                action = new PlayerUnLockedDoorCollisionHandler();
                                action.Handle(object1, object2, direction);
                            }
                            else
                            {
                                action = new PlayerBlockCollisionHandler();
                                action.Handle(object1, object2, direction);
                            }

                        }
                        else
                        {
                            action = new PlayerUnLockedDoorCollisionHandler();
                            action.Handle(object1, object2, direction);
                        }

                        break;

                    case SubType.ClosedDoorEnemy:
                        if (((ClosedDoorObject)object2).IsLocked)
                        {
                            if (gm.CurrentRoom.EnemyNumber == 0)
                            {
                                ((ClosedDoorObject)object2).UnLockDoor();
                                action = new PlayerUnLockedDoorCollisionHandler();
                                action.Handle(object1, object2, direction);
                            }
                            else
                            {
                                action = new PlayerBlockCollisionHandler();
                                action.Handle(object1, object2, direction);
                            }
                        }
                        else
                        {
                            action = new PlayerBlockCollisionHandler();
                            action.Handle(object1, object2, direction);
                        }
                        break;
                    case SubType.ClosedDoorBlock:
                        if (((ClosedDoorObject)object2).IsLocked)
                        {
                            if (Globals.SpecialBlockMoved == true)
                            {
                                ((ClosedDoorObject)object1).UnLockDoor();
                                action = new PlayerUnLockedDoorCollisionHandler();
                                action.Handle(object1, object2, direction);
                            }
                            else
                            {
                                action = new PlayerBlockCollisionHandler();
                                action.Handle(object1, object2, direction);
                            }
                        }
                        else
                        {
                            action = new PlayerBlockCollisionHandler();
                            action.Handle(object1, object2, direction);
                        }
                        break;
                }
            }
            else if (object1.ObjectProperty.Equals(ObjectType.Portal) && object2.ObjectProperty.Equals(ObjectType.Player))
            {
                GameManager gm = GameManager.GetInstance();
                switch (object1.SubProperty)
                {
                    case SubType.None:
                        action = new PlayerUnLockedDoorCollisionHandler();
                        action.Handle(object2, object1, direction);
                        break;

                    case SubType.DoorLocked:
                        if (((DoorWithKeyObject)object1).IsLocked)
                        {
                            if (gm.Player.PlayerInventory.ItemCount(Item.Key) > 0)
                            {
                                gm.Player.PlayerInventory.UseItem(Item.Key);
                                ((DoorWithKeyObject)object1).UnLockDoor();
                                action = new PlayerUnLockedDoorCollisionHandler();
                                action.Handle(object2, object1, direction);
                            }
                            else
                            {
                                action = new PlayerBlockCollisionHandler();
                                action.Handle(object2, object1, direction);
                            }

                        }
                        else
                        {
                            action = new PlayerUnLockedDoorCollisionHandler();
                            action.Handle(object2, object1, direction);
                        }

                        break;

                    case SubType.ClosedDoorEnemy:
                        if (((ClosedDoorObject)object1).IsLocked)
                        {
                            if (gm.CurrentRoom.EnemyNumber == 0)
                            {
                                ((ClosedDoorObject)object1).UnLockDoor();
                                action = new PlayerUnLockedDoorCollisionHandler();
                                action.Handle(object2, object1, direction);
                            }
                            else
                            {
                                action = new PlayerBlockCollisionHandler();
                                action.Handle(object2, object1, direction);
                            }
                        }
                        else
                        {
                            action = new PlayerUnLockedDoorCollisionHandler();
                            action.Handle(object2, object1, direction);
                        }
                        break;

                    case SubType.ClosedDoorBlock:
                        if (((ClosedDoorObject)object1).IsLocked)
                        {
                            if (Globals.SpecialBlockMoved == true)
                            {
                                ((ClosedDoorObject)object1).UnLockDoor();
                                action = new PlayerUnLockedDoorCollisionHandler();
                                action.Handle(object2, object1, direction);
                            }
                            else
                            {
                                action = new PlayerBlockCollisionHandler();
                                action.Handle(object2, object1, direction);
                            }
                        }
                        else
                        {
                            action = new PlayerUnLockedDoorCollisionHandler();
                            action.Handle(object2, object1, direction);
                        }
                        break;

                    case SubType.BombDoor1:
                        if (!((BombDoorObject1)object1).IsLocked)
                        {
                            action = new PlayerUnLockedDoorCollisionHandler();
                            action.Handle(object2, object1, direction);
                        }
                        break;
                    case SubType.BombDoor2:
                        if (!((BombDoorObject2)object1).IsLocked)
                        {
                            action = new PlayerUnLockedDoorCollisionHandler();
                            action.Handle(object2, object1, direction);
                        }
                        break;
                }

            }
        }
    }
}
