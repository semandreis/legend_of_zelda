using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Zelda.General;
using Zelda.Interfaces;

namespace Zelda.GameState
{
    class ClockPausedState : IGameState
    {
        // get running state, and don't update
        private static GameManager _gameManager;
        private static ClockPausedState _instance;
        private const float _resizeFactor = 3.5f;
        private static int _timer = 300;
        private static SpriteFont _font;

        private ClockPausedState() { }

        public static ClockPausedState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ClockPausedState();
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

        private bool ObjectGone(IGameObject element)
        {
            return !element.Exists;
        }

        public void Update(GameTime gameTime)
        {
            _gameManager.PlayerObject.Update(gameTime);
            _gameManager.ProjectileController.Update(gameTime);
            _gameManager.ActiveObjects.RemoveAll(ObjectGone);
            _gameManager.HUD.Update(gameTime);

            List<Tuple<IGameObject, IGameObject, Direction>> collisions = _gameManager.CollisionDetector.FindCollisions(_gameManager.ActiveObjects, _gameManager.ProjectileObjects);


            while (collisions.Count > 0)
            {
                _gameManager.CollisionHandler.CheckCollision(collisions[0]);
                collisions.RemoveAt(0);
            }

            if (_timer > 0)
            {
                _timer--;
            }
            else
            {
                _timer = 300;
                _gameManager.StateCommander.ChangeState(GameStateType.Running);
               
            }
        }
    }
}
