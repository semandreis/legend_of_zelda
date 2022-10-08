using Zelda.General;
using Zelda.Interfaces;
using System;

namespace Zelda.Collisions
{
    class EnemyBlockCollisionHandler : ICollisionSingle
    {
        public void Handle(IGameObject enemy, IGameObject block, Direction direction)
        {
            enemy.UndoMovement();
        }
    }
}
