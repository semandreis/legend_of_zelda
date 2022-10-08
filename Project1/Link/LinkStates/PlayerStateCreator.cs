using System;
using Zelda.General;
using Zelda.Projectiles;

namespace Zelda.Link.LinkStates
{
    class PlayerStateCreator
    {
        public static IPlayerState CreateNormalDirectionState(Direction direction, IPlayer player, IProjectileController projectiles)
        {
            return direction switch
            {
                Direction.Down => new NormalForwardPlayerState(player, projectiles),
                Direction.Left => new NormalLeftPlayerState(player, projectiles),
                Direction.Right => new NormalRightPlayerState(player, projectiles),
                Direction.Up => new NormalBackwardPlayerState(player, projectiles),
                _ => throw new InvalidOperationException("Can't create state"),
            };
        }

        public static IPlayerState CreateItemDirectionState(Direction direction, IPlayer player, IProjectileController projectiles)
        {
            return direction switch
            {
                Direction.Down => new ItemForwardPlayerState(player, projectiles),
                Direction.Left => new ItemLeftPlayerState(player, projectiles),
                Direction.Right => new ItemRightPlayerState(player, projectiles),
                Direction.Up => new ItemBackwardPlayerState(player, projectiles),
                _ => throw new InvalidOperationException("Can't create state"),
            };
        }

        public static IPlayerState CreateShieldDirectionState(Direction direction, IPlayer player, IProjectileController projectiles)
        {
            return direction switch
            {
                Direction.Down => new ShieldNormalForwardPlayerState(player, projectiles),
                Direction.Left => new ShieldNormalLeftPlayerState(player, projectiles),
                Direction.Right => new ShieldNormalRightPlayerState(player, projectiles),
                Direction.Up => new ShieldNormalBackwardPlayerState(player, projectiles),
                _ => throw new InvalidOperationException("Can't create state"),
            };
        }

        public static IPlayerState CreateShieldItemDirectionState(Direction direction, IPlayer player, IProjectileController projectiles)
        {
            return direction switch
            {
                Direction.Down => new ShieldItemForwardPlayerState(player, projectiles),
                Direction.Left => new ShieldItemLeftPlayerState(player, projectiles),
                Direction.Right => new ShieldItemRightPlayerState(player, projectiles),
                Direction.Up => new ShieldItemBackwardPlayerState(player, projectiles),
                _ => throw new InvalidOperationException("Can't create state"),
            };
        }

        public static IPlayerState CreatePickItemPlayerState(IPlayer player, IProjectileController projectiles)
        {
            return new PickItemPlayerState(player, projectiles);
        }
    }
}
