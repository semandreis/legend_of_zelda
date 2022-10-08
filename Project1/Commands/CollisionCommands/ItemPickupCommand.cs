using Zelda.Interfaces;
using System;
using Zelda.General;
using Zelda.Items;
using Zelda.GameState;
using Zelda.Commands.ItemCommands;

namespace Zelda.Commands.CollisionCommands
{
    class ItemPickupCommand : ICommand
    {
        private readonly IGameObject item;

        public ItemPickupCommand(IGameObject _item)
        {
            item = _item;
            
            if (item.SoundProperty.Equals(SoundType.Rupee))
            {
                Globals.SoundManager.PlaySound("rupee");
            }
            else if (item.SoundProperty.Equals(SoundType.Heart)) 
            {
                Globals.SoundManager.PlaySound("heart");
            }
            else if (item.SoundProperty.Equals(SoundType.Triforce))
            {
                Globals.SoundManager.PlaySound("fanfare");
            }
            else
            {
                Globals.SoundManager.PlaySound("item");
            }
        }


        public void Execute()
        {
            
            item.Exists = false;
            
            //add item to inventory
            GameManager gm = GameManager.GetInstance();

            if (item.GetType() == typeof(BlueCandleItem))
            {
                gm.Player.PlayerInventory.PickupItem(Item.BluePotion);
            }else if (item.GetType() == typeof(BlueCandleItem))
            {
                gm.Player.PlayerInventory.PickUpProjectile(Projectile.Candle);
            }else if (item.GetType() == typeof(BombItem))
            {
                gm.Player.PlayerInventory.PickupItem(Item.Bomb);
            }else if (item.GetType() == typeof(BowItem))
            {
                gm.Player.PlayerInventory.PickUpHasable(Item.Bow);
            }else if (item.GetType() == typeof(WoodenBoomerangItem))
            {
                gm.Player.PlayerInventory.PickUpProjectile(Projectile.Boomerang);
            }else if (item.GetType() == typeof(ClockItem))
            {
                ICommand command = new ClockCommand();
                command.Execute();
            }else if (item.GetType() == typeof(CompassItem))
            {
                gm.Player.PlayerInventory.PickUpHasable(Item.Compass);
            }else if (item.GetType() == typeof(HeartContainerItem))
            {
                ICommand command = new HeartContainerCommand(gm.Player);
                command.Execute();
                gm.Player.PlayerInventory.PickupItem(Item.HeartContainer);
            }else if (item.GetType() == typeof(FairyItem))
            {
                ICommand command = new FairyCommand(gm.Player);
                command.Execute();
                gm.Player.PlayerInventory.PickupItem(Item.Fairy);
            }else if (item.GetType() == typeof(KeyItem))
            {
                gm.Player.PlayerInventory.PickupItem(Item.Key);
            }else if (item.GetType() == typeof(MapItem))
            {
                gm.Player.PlayerInventory.PickUpHasable(Item.Map);
            }else if (item.GetType() == typeof(RupeeItem))
            {
                gm.Player.PlayerInventory.PickupItem(Item.Rupee);
            }else if (item.GetType() == typeof(HeartItem))
            {
                ICommand command = new HeartCommand(gm.Player);
                command.Execute();
                gm.Player.PlayerInventory.PickupItem(Item.Heart);
            }else if (item.GetType() == typeof(ArrowItem))
            {
                gm.Player.PlayerInventory.PickupItem(Item.Arrow);
            }
            else if (item.GetType() == typeof(TriforcePieceItem))
            {
                GameManager.GetInstance().StateCommander.ChangeState(GameStateType.Completed);
            }
        }

    }
}
