using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
using Zelda.GameState;
using Zelda.Environment;
using Zelda.Achievements;

namespace Zelda.Collisions
{
    class PlayerUnLockedDoorCollisionHandler : ICollisionSingle
    {

        public void Handle(IGameObject player, IGameObject portal, Direction direction)
        {
            GameManager gm = GameManager.GetInstance();
            gm.CurrentRoom.ActiveObjects.Remove(gm.PlayerObject);

            switch (portal.SubProperty) {
                case SubType.None:
                    gm.NextRoomID = ((InvisiblePortal)portal).NextRoomID;
                    gm.Player.Point.ObjectPoint = ((InvisiblePortal)portal).NextPosition;
                    gm.Player.AchievementsStats.DoorwaysTraveled++;
                    break;

                case SubType.DoorLocked:
                    gm.NextRoomID = ((DoorWithKeyObject)portal).NextRoomID;
                    gm.Player.Point.ObjectPoint = ((DoorWithKeyObject)portal).NextPosition;
                    Console.WriteLine("UnlockDoor");
                    break;
                case SubType.ClosedDoorBlock:
                case SubType.ClosedDoorEnemy:
                    gm.NextRoomID = ((ClosedDoorObject)portal).NextRoomID;
                    gm.Player.Point.ObjectPoint = ((ClosedDoorObject)portal).NextPosition;
                    Console.WriteLine("UnlockDoor");

                    break;
        }
            gm.CurrentState = TransitioningState.GetInstance();
            gm.CurrentState.InitializeState();
        }

    }
}
