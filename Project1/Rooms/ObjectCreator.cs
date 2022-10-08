using System;
using Microsoft.Xna.Framework;
using Zelda.Environment;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Items;
using Zelda.NPCs.Bosses;
using Zelda.NPCs.Enemies;
using Zelda.NPCs.Neutrals;

namespace Zelda.Rooms
{
    static class ObjectCreator
    {
        public static IGameObject CreateBoss(string entry, Vector2 position)
        {
            return entry switch
            {
                RoomConstants.Aquamentus => BossCreator.CreateBoss(Boss.Aquamentus, position),
                RoomConstants.Dodongo => BossCreator.CreateBoss(Boss.Dodongo, position),
                _ => throw new NotImplementedException("Can't create boss"),
            };
        }

        public static IGameObject CreateEnemy(string entry, Vector2 position)
        {
            return entry switch
            {

                RoomConstants.Stalfos => EnemyCreator.CreateEnemy(Enemy.Stalfos, position),
                RoomConstants.Goriya => EnemyCreator.CreateEnemy(Enemy.Goriya, position),
                RoomConstants.Keese => EnemyCreator.CreateEnemy(Enemy.Keese, position),
                RoomConstants.JellySmall => EnemyCreator.CreateEnemy(Enemy.JellySmall, position),
                RoomConstants.Wall => EnemyCreator.CreateEnemy(Enemy.WallMaster, position),
                RoomConstants.Trap1 => EnemyCreator.CreateEnemy(Enemy.Trap1, position),
                RoomConstants.Trap2 => EnemyCreator.CreateEnemy(Enemy.Trap2, position),
                RoomConstants.Trap3 => EnemyCreator.CreateEnemy(Enemy.Trap3, position),
                RoomConstants.Trap4 => EnemyCreator.CreateEnemy(Enemy.Trap4, position),
                RoomConstants.JellyBig => EnemyCreator.CreateEnemy(Enemy.JellyBig, position),
                RoomConstants.Rope => EnemyCreator.CreateEnemy(Enemy.Rope, position),
                RoomConstants.Gibdo => EnemyCreator.CreateEnemy(Enemy.Gibdo, position),
                RoomConstants.Darknut => EnemyCreator.CreateEnemy(Enemy.Darknut, position),

                _ => throw new NotImplementedException("Can't create enemy"),
            };
        }

        public static IGameObject CreateNPC(string entry, Vector2 position)
        {
            return entry switch
            {
                RoomConstants.OldMan => NeutralCreator.CreateNeutral(Neutral.OldMan, position),
                RoomConstants.Fire => NeutralCreator.CreateNeutral(Neutral.StaticFire, position),
                _ => throw new NotImplementedException("Can't create neutral"),
            };
        }

        public static IGameObject CreateItem(string entry, Vector2 position)
        {
            return entry switch
            {
                RoomConstants.Arrow => ItemCreator.CreateItem(Item.Arrow, position),
                RoomConstants.Candle => ItemCreator.CreateItem(Item.BlueCandle, position),
                RoomConstants.Potion => ItemCreator.CreateItem(Item.BluePotion, position),
                RoomConstants.Bomb => ItemCreator.CreateItem(Item.Bomb, position),
                RoomConstants.Bow => ItemCreator.CreateItem(Item.Bow, position),
                RoomConstants.Clock => ItemCreator.CreateItem(Item.Clock, position),
                RoomConstants.Compass => ItemCreator.CreateItem(Item.Compass, position),
                RoomConstants.Fairy => ItemCreator.CreateItem(Item.Fairy, position),
                RoomConstants.Heart => ItemCreator.CreateItem(Item.Heart, position),
                RoomConstants.HContainer => ItemCreator.CreateItem(Item.HeartContainer, position),
                RoomConstants.Key => ItemCreator.CreateItem(Item.Key, position),
                RoomConstants.Map => ItemCreator.CreateItem(Item.Map, position),
                RoomConstants.Rupee => ItemCreator.CreateItem(Item.Rupee, position),
                RoomConstants.Triforce => ItemCreator.CreateItem(Item.TriforcePieces, position),
                RoomConstants.Boomerang => ItemCreator.CreateItem(Item.WoodenBoomerang, position),
                _ => throw new NotImplementedException("Can't create item"),
            };
        }

        public static IGameObject CreateTile(string entry, Vector2 position)
        {
            return entry switch
            {
                RoomConstants.Immovable => TileCreator.CreateTile(Tiles.NonmovingTile, position),
                RoomConstants.Movable => TileCreator.CreateTile(Tiles.MovingTile, position),
                _ => throw new NotImplementedException("Can't create tile"),
            };
        }

        public static IGameObject CreateDoor(int type, IGameObject portal)
        {
           return DoorCreator.CreateDoor(type, portal);
        }
    }
}
