using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.GameState
{
    class PausedState : IGameState
    {
        private static GameManager _gameManager;
        private static PausedState _instance;
        private const float _resizeFactor = 3.5f;
        private static SpriteFont _font;

        private PausedState() { }

        public static PausedState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PausedState();
            }
            return _instance;
        }

        public void InitializeState()
        {
            _gameManager = GameManager.GetInstance();
            _font = _gameManager.Content.Load<SpriteFont>("Ubuntu32");
            Globals.IsMouseDebugging = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_gameManager.DungeonTexture, new Rectangle((int)_gameManager.RoomFramePoint.X, (int)_gameManager.RoomFramePoint.Y,
                (int)(_gameManager.CurrentRoom.Frame.Width * _resizeFactor), (int)(_gameManager.CurrentRoom.Frame.Height * _resizeFactor)),
                _gameManager.CurrentRoom.Frame, Color.White);
            _gameManager.ProjectileController.Draw(gameTime, sb);
            _gameManager.HUD.Draw(new Vector2(20, 20), sb, _font);
            for (int i = 0; i < _gameManager.ActiveObjects.Count; i++)
            {
                _gameManager.ActiveObjects[i].Draw(gameTime, sb);
            }
        }

        public void Update(GameTime gameTime)
        {
            // no update function
        }
    }
}
