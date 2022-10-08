 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System.Collections.Generic;
using Zelda.GameState;
using Zelda.General;
using Zelda.HUD;
using Zelda.Interfaces;
using Zelda.Items;
using Zelda.Projectiles;

namespace Zelda.GameState
{
    public class ItemSelectionScreen
    {
        private static ItemSelectionScreen _instance;
        private static GameManager _gm;
        private static List<Projectile> _projectileInventory;
        private static List<Item> _countableInventory;
        private static List<ItemButton> _buttonList;
        private bool _mapBool;
        private bool _compassBool;

        private int mod = 7;

        private float _b1left = 560;
        private float _b1right = 1000;
        private float _b1top = 170;
        private float _b1bottom = 370;

        private float _b2left = 240;
        private float _b2right = 330;
        private float _b2top = 250;
        private float _b2bottom = 340;
        private ItemDisplay _currentItem;

        private ItemSelectionScreen() { }

        public static ItemSelectionScreen GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ItemSelectionScreen();
            }
            return _instance;
        }
       

        public void InitializeScreen()
        {
            _gm = GameManager.GetInstance();
            _buttonList = new List<ItemButton>();
            _projectileInventory = _gm.Player.PlayerInventory.GetProjectiles();


            for (int i = 0; i < _projectileInventory.Count; i++)
            {
                _buttonList.Add(new ItemButton(_projectileInventory[i], new Rectangle((int)(_b1left + ((i % 5) * 50)), (int)(_b1top + ((i / 5) * 50)), Constants.ImageButtonWidth, Constants.ImageButtonHeight)));
            }

            _mapBool = _gm.Player.PlayerInventory.HasItem(Item.Map);
            _compassBool = _gm.Player.PlayerInventory.HasItem(Item.Compass);
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.DrawString(Globals.Font, "Inventory", new Vector2(210, 170), Color.Red);
            sb.DrawString(Globals.Font, "Map", new Vector2(70, 450), Color.Red);
            sb.DrawString(Globals.Font, "Compass", new Vector2(70, 590), Color.Red);
            sb.DrawString(Globals.Font, "Selected", new Vector2(140, 345), Color.White);

            sb.DrawLine(_b1left, _b1top, _b1right, _b1top, Color.Yellow);
            sb.DrawLine(_b1left, _b1bottom, _b1right, _b1bottom, Color.Yellow);
            sb.DrawLine(_b1right, _b1top, _b1right, _b1bottom, Color.Yellow);
            sb.DrawLine(_b1left, _b1top, _b1left, _b1bottom, Color.Yellow);

            sb.DrawLine(_b2left, _b2top, _b2right, _b2top, Color.Yellow);
            sb.DrawLine(_b2left, _b2bottom, _b2right, _b2bottom, Color.Yellow);
            sb.DrawLine(_b2right, _b2top, _b2right, _b2bottom, Color.Yellow);
            sb.DrawLine(_b2left, _b2top, _b2left, _b2bottom, Color.Yellow);

            foreach (ItemButton i in _buttonList)
            {
                i.Draw(gameTime, sb);
            }

            _currentItem = new ItemDisplay();
            _currentItem.SetItemType(_gm.Player.PlayerStats.Proj1);
            _currentItem.Draw(sb, new Rectangle((int)_b2left + 40, (int)_b2top + 15, Constants.ImageButtonWidth, Constants.ImageButtonHeight));

            if (_mapBool == true)
            {
                IGameObject MapItem = ItemCreator.CreateItem(Item.Map, new Vector2(35 * mod, 60 * mod));
                MapItem.Draw(gameTime, sb);
            }

            if (_compassBool == true)
            {
                IGameObject Compass = ItemCreator.CreateItem(Item.Compass, new Vector2(35 * mod, 85 * mod));
                Compass.Draw(gameTime, sb);

            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (ItemButton b in _buttonList)
            {
                Projectile check = b.ButtonPressed();
                if (check != Projectile.Null)
                {
                    _gm.Player.PlayerStats.SetProj1(check);

                    if (Globals.IsRecording)
                    {
                        _gm.Recorder.RecordCommand("Item " + check.ToString());
                    }
                }
            }
        }
    }
}
