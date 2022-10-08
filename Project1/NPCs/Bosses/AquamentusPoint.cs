using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Zelda.Interfaces;

namespace Zelda.NPCs.Bosses
{
    class AquamentusPoint : IMoveable
    {
        public Vector2 ObjectPoint { get; set; }
        private Vector2 _lastMove;
        private readonly Vector2 _initialPoint;
        private Vector2 _velocity;
        private int _movingScale;
        private bool _forward;
        private readonly Random _rnd;
        private int _rndNum;

        public AquamentusPoint(Vector2 point)
        {
            _initialPoint = new Vector2(point.X, point.Y);
            ObjectPoint = new Vector2(point.X, point.Y);
            _velocity = new Vector2(0, 0);
            _movingScale = 0;
            _forward = true;
            _rnd = new Random();
            _rndNum = 0;
        }

        private void PickDirection()
        {
            _rndNum = _rnd.Next(0, 1500);
            if (_movingScale < 100 && _forward)
            {
                
                _movingScale++;
                if (_rndNum % 41 == 0)
                    _forward = false;
            }
            else
            {
                _forward = false;

                _movingScale--;
                if (_rndNum % 37 == 0)
                    _forward = true;

                if (_movingScale == 0)
                {
                    _forward = true;
                    Globals.SoundManager.PlaySound("boss1");
                }
            }

            _velocity.X = _movingScale * 5;
        }

        public void Move(Vector2 velocity, GameTime gameTime)
        {
            PickDirection();
            Vector2 EarlyVelocity = new Vector2(_velocity.X, _velocity.Y);
            ObjectPoint = Vector2.Add(_initialPoint, _velocity);
            _lastMove = Vector2.Subtract(EarlyVelocity, _velocity);
        }

        public void UndoMove()
        {
            ObjectPoint = Vector2.Subtract(ObjectPoint, _lastMove);
        }
        public void TakeDamage()
        {

        }
    }
}
