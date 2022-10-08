using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
namespace Zelda.Collisions
{
    class PlayerEnemyProjectileCollisionHandler : ICollisionSingle
    {

        public void Handle(IGameObject player, IGameObject enemyProjectile, Direction direction)
        {
            PlayerObject p2p = (PlayerObject)player;
            ICommand command = new PlayerHurtCommand(p2p.Player);

            command.Execute();

        }
    }
}
