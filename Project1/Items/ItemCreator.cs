using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;

namespace Zelda.Items
{
    static class ItemCreator
    {
        private static Texture2D _texture;

        public static void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public static Interfaces.IGameObject CreateItem(Item item, Vector2 position)
        {
            return item switch
            {
                Item.Arrow => new ArrowItem(_texture, position),
                Item.BlueCandle => new BlueCandleItem(_texture, position),
                Item.BluePotion => new BluePotionItem(_texture, position),
                Item.Bomb => new BombItem(_texture, position),
                Item.Bow => new BowItem(_texture, position),
                Item.Clock => new ClockItem(_texture, position),
                Item.Compass => new CompassItem(_texture, position),
                Item.Fairy => new FairyItem(_texture, position),
                Item.Heart => new HeartItem(_texture, position),
                Item.HeartContainer => new HeartContainerItem(_texture, position),
                Item.Key => new KeyItem(_texture, position),
                Item.Map => new MapItem(_texture, position),
                Item.Rupee => new RupeeItem(_texture, position),
                Item.TriforcePieces => new TriforcePieceItem(_texture, position),
                Item.WoodenBoomerang => new WoodenBoomerangItem(_texture, position),
                Item.Null => new NullItem(_texture, position),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
