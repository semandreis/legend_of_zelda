using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
using Zelda.GameState;

namespace Zelda.Collisions
{
    class PlayerEnemyCollisionHandler : ICollisionSingle
    {
        private void FixPlayerDirection(PlayerObject player, Direction direction)
        {
            player.Player.ChangeDirection(direction);
        }

        public void Handle(IGameObject player, IGameObject enemy, Direction direction)
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
