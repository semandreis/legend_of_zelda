using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
using Zelda.GameState;

namespace Zelda.Collisions
{
    class EnemyPlayerCollisionHandler : ICollisionSingle
    {

        private void FixPlayerDirection (PlayerObject player, Direction direction)
        {
            Direction postDirection = Direction.Down;

            if (direction == Direction.Down)
            {
                postDirection = Direction.Up;
            }
            else if (direction == Direction.Right)
            {
                postDirection = Direction.Left;
            }
            else if (direction == Direction.Left)
            {
                postDirection = Direction.Right;
            }

            player.Player.ChangeDirection(postDirection);
        }

        public void Handle(IGameObject enemy, IGameObject player, Direction direction)
        {
            PlayerObject playerObject = (PlayerObject)player;


            if (!playerObject.Player.PlayerStats.IsBerserk())
            {
                FixPlayerDirection(playerObject, direction);
                ICommand command = new PlayerHurtCommand(playerObject.Player);
                command.Execute();
                if (playerObject.Player.PlayerStats.IsAlive())
                {
                    playerObject.ChangeStats(-1);
                }
            }
            else
            {
                ICommand command = new PlayerBerserkCommand(playerObject.Player);
                command.Execute();
            }
        }
    }
}
