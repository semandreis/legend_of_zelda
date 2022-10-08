using System;
using Zelda.Interfaces;
using Zelda.General;
using Zelda.Commands.CollisionCommands;
using Zelda.Link;
using Zelda.Environment;
using Zelda.GameState;
using System.Collections.Generic;

namespace Zelda.Collisions
{
    class AllCollisionChecker : ICollisionChecker
    {
        private IGameObject object1;
        private IGameObject object2;
        private Direction direction;
        private ICollisionSingle action;
        private List<ICollisionCheckerSingle> PossibleCollisions;

        private readonly ICollisionCheckerSingle DoorProjectile = new DoorProjectileCollisionChecker();
        private readonly ICollisionCheckerSingle EnemyBlock = new EnemyBlockCollisionChecker();
        private readonly ICollisionCheckerSingle EnemyProjectile = new EnemyProjectileCollisionChecker();
        private readonly ICollisionCheckerSingle PlayerAndEnemy = new PlayerAndEnemyCollisionChecker();
        private readonly ICollisionCheckerSingle PlayerBlock = new PlayerBlockCollisionChecker();
        private readonly ICollisionCheckerSingle PlayerEnemyProjectile = new PlayerEnemyProjectileCollisionChecker();
        private readonly ICollisionCheckerSingle PlayerItem = new PlayerItemCollisionChecker();
        private readonly ICollisionCheckerSingle PlayerMovableBlock = new PlayerMovableBlockCollisionChecker();
        private readonly ICollisionCheckerSingle PlayerUnLockedDoor = new PlayerUnLockedDoorCollisionChecker();
        private readonly ICollisionCheckerSingle Wall = new WallCollisionChecker();

        public void CheckCollision(Tuple<IGameObject, IGameObject, Direction> collision)
        {
            object1 = collision.Item1;
            object2 = collision.Item2;
            direction = collision.Item3;

            PossibleCollisions = new List<ICollisionCheckerSingle>
            {
                DoorProjectile,
                EnemyBlock,
                EnemyProjectile,
                PlayerAndEnemy,
                PlayerBlock,
                PlayerEnemyProjectile,
                PlayerItem,
                PlayerMovableBlock,
                PlayerUnLockedDoor,
                Wall
            };
            
        foreach (ICollisionCheckerSingle check in PossibleCollisions)
            {
                check.CheckCollisionSingle(object1, object2, direction, action);

            }
            

        }

    }
}