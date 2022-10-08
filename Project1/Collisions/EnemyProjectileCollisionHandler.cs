using Zelda.General;
using Zelda.Interfaces;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using System;
using Zelda.GameState;

namespace Zelda.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionSingle
    {

        public void Handle(IGameObject enemy, IGameObject projectile, Direction direction)
        {
            enemy.ChangeStats(-1);
            projectile.Exists = false;
            Globals.SoundManager.PlaySound("enemy_hit");
        }
}
}
