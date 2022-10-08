using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace Zelda.HUD
{
    public class HUDDisplay
    {
        private readonly Texture2D _texture;
        private readonly GameManager _manager;

        private bool _drawFlag;

        public Rectangle FrameSourceRectangle { get; set; }
        public Rectangle FrameDestinationRectangle { get; set; }
        public Rectangle Item0Destination { get; set; }
        public Rectangle Item1Destination { get; set; }
        public Rectangle MapDestination { get; set; }
        public Rectangle HeartDestination { get; set; }
        public MapDisplay Map { get; set; }
        public HeartDisplay Health { get; set; }
        public ItemDisplay Item0 { get; set; }
        public ItemDisplay Item1 { get; set; }
        public NumbersDisplay Numbers { get; set; }

        public HUDCaveat Caveat { get; set; }

        public HUDDisplay(Texture2D texture)
        {
            _texture = texture;
            _manager = GameManager.GetInstance();

            Map = new MapDisplay();
            Health = new HeartDisplay();
            Item0 = new ItemDisplay();
            Item1 = new ItemDisplay();
            Numbers = new NumbersDisplay();

            FrameDestinationRectangle = new Rectangle(HUDConstants.Frame1, HUDConstants.Frame2, HUDConstants.Frame3, HUDConstants.Frame4);
            FrameSourceRectangle = new Rectangle(HUDConstants.Frame5, HUDConstants.Frame6, HUDConstants.Frame7, HUDConstants.Frame8);
            Item0Destination = new Rectangle(HUDConstants.item1, HUDConstants.item2, HUDConstants.item3, HUDConstants.item4);
            Item1Destination = new Rectangle(HUDConstants.item5, HUDConstants.item2, HUDConstants.item6, HUDConstants.item7);
            MapDestination = new Rectangle(HUDConstants.map1, HUDConstants.map2, HUDConstants.map3, HUDConstants.map4);
            HeartDestination = new Rectangle(HUDConstants.health1, HUDConstants.health2, HUDConstants.health3, HUDConstants.health3);
            Caveat = new HUDCaveat();
            _drawFlag = false;
        }        

        public void Update(GameTime gameTime)
        {
            Item0.SetItemType(_manager.Player.PlayerStats.Proj0);
            Item1.SetItemType(_manager.Player.PlayerStats.Proj1);

            if (!_manager.Player.PlayerStats.IsHealthy())
            {
                _drawFlag = false;
            }
            else
            {
                _drawFlag = true;
            }
        }

        public void Draw(Vector2 position, SpriteBatch sb, SpriteFont font)
        {
            sb.Draw(_texture, FrameDestinationRectangle, FrameSourceRectangle, Color.White);

            Map.CalculateRoomTiles(MapDestination);
            Map.Draw(sb);

            Health.Draw(sb, HeartDestination);

            Item0.Draw(sb, Item0Destination);
            Item1.Draw(sb, Item1Destination);

            Numbers.DrawHealth(sb, font);
            Numbers.DrawBombNum(sb, font);
            Numbers.DrawKeyNum(sb, font);
            Numbers.DrawGemNum(sb, font);

            if (!_drawFlag)
            {
                Caveat.DrawHeartCaveat(sb, font);
            }
        }
    }
}
