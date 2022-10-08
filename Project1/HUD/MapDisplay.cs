using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.GameState;
using Zelda.Interfaces;

namespace Zelda.HUD
{
    public class MapDisplay
    {
        private Dictionary<IRoom, Vector2> _roomOffsets { get; set; }
        private Dictionary<IRoom, Rectangle> _roomTiles { get; set; }
        private readonly GameManager _gameManager;
        private int _roomHorizontalCount;
        private int _roomVerticalCount;
        private readonly Rectangle _sourceRectangle;

        public MapDisplay ()
        {
            _gameManager = GameManager.GetInstance();
            _sourceRectangle = HUDConstants.MapTileRectangle;
        }

        public void SetRooms(Dictionary<IRoom, Vector2> roomOffsets, int roomHorizontalCount, int roomVerticalCount)
        {
            _roomOffsets = roomOffsets;
            _roomHorizontalCount = roomHorizontalCount;
            _roomVerticalCount = roomVerticalCount;
        }

        public void CalculateRoomTiles(Rectangle destinationRectangle)
        {
            int width = destinationRectangle.Width / (_roomHorizontalCount + 3);
            int height = destinationRectangle.Height / (_roomVerticalCount + 3);
            int offsetW = width / _roomHorizontalCount;
            int offsetH = width / _roomVerticalCount;

            _roomTiles = new Dictionary<IRoom, Rectangle>();

            foreach (KeyValuePair<IRoom, Vector2> entry in _roomOffsets)
            {
                int leftPoint = destinationRectangle.X + (int)entry.Value.X * (width + offsetW);
                int topPoint = destinationRectangle.Y + (int)entry.Value.Y * (height + offsetH);
                _roomTiles.Add(entry.Key, new Rectangle(leftPoint, topPoint, width, height));
            }            
        }

        private void DrawRooms(SpriteBatch sb)
        {
            foreach (KeyValuePair<IRoom, Rectangle> entry in _roomTiles)
            {
                sb.Draw(_gameManager.HUDTexture, entry.Value, _sourceRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.None, HUDConstants.MapTileDepth);
            }
        }

        private void DrawPosition(SpriteBatch sb)
        {
            Rectangle currentRectangle = _roomTiles[_gameManager.RoomDict[_gameManager.CurrentRoomID]];
            int positionWidth = currentRectangle.Width / 2;
            int positionLeft = currentRectangle.X + positionWidth / 2;
            Rectangle positionRectangle = new Rectangle(positionLeft, currentRectangle.Y, positionWidth, currentRectangle.Height);
            sb.Draw(_gameManager.HUDTexture, positionRectangle, _sourceRectangle, Color.Green, 0f, Vector2.Zero, SpriteEffects.None, HUDConstants.PositionTileDepth);
        }

        public void Draw(SpriteBatch sb)
        {
            if (_gameManager.Player.PlayerInventory.HasItem(General.Item.Map))
            {
                DrawRooms(sb);
            }
            DrawPosition(sb);
        }
    }
}
