using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zelda.General;
using Zelda.Interfaces;
using Zelda.Link;

namespace Zelda.GameState
{
    class RunningState : IGameState
    {
        private static GameManager _gameManager;
        private static RunningState _instance;
        private const float _resizeFactor = 3.5f;
        private static SpriteFont _font;

        private RunningState() { }

        public static RunningState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RunningState();
            }
            return _instance;
        }

        public void InitializeState()
        {
            _gameManager = GameManager.GetInstance();
            _gameManager.CurrentRoom = _gameManager.RoomDict[_gameManager.CurrentRoomID];
            _gameManager.ActiveObjects = _gameManager.CurrentRoom.ActiveObjects;
            _gameManager.EnemyNumber = _gameManager.CurrentRoom.EnemyNumber;
            _gameManager.ActiveObjects.Add(_gameManager.PlayerObject);
            _gameManager.CurrentRoom.Accessed = true;
            _gameManager.HUD.MapDestination = new Rectangle(154, 22, 174, 85);
            _font = _gameManager.Content.Load<SpriteFont>("Ubuntu32");
            Globals.IsStarting = false;
            Globals.IsMouseDebugging = true;
            Globals.IsChangingRoom = false;
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(_gameManager.DungeonTexture, new Rectangle((int)_gameManager.RoomFramePoint.X, (int)_gameManager.RoomFramePoint.Y, 
                (int)(_gameManager.CurrentRoom.Frame.Width * _resizeFactor), (int)(_gameManager.CurrentRoom.Frame.Height * _resizeFactor)),
                _gameManager.CurrentRoom.Frame, Color.White);
            _gameManager.ProjectileController.Draw(gameTime, sb);
            _gameManager.HUD.Draw(new Vector2(20, 20) ,sb, _font);
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
            _gameManager.ProjectileController.Update(gameTime);
            _gameManager.ActiveObjects.RemoveAll(ObjectGone);
            _gameManager.HUD.Update(gameTime);
            foreach (IGameObject element in _gameManager.ActiveObjects)
            {
                element.Update(gameTime);
            }

            List<Tuple<IGameObject, IGameObject, Direction>> collisions = _gameManager.CollisionDetector.FindCollisions(_gameManager.ActiveObjects, _gameManager.ProjectileObjects);


            while (collisions.Count > 0)
            {
                _gameManager.CollisionHandler.CheckCollision(collisions[0]);
                collisions.RemoveAt(0);
            }
        }
    }
}
