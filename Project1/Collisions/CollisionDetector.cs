using System.Collections.Generic;
using System;
using Zelda.Interfaces;
using Zelda.General;
using Microsoft.Xna.Framework;

namespace Zelda.Collisions
{        
    // chose to use insertion sort to sort objects by leftmost point and then search for collisions to reduce the amount of checking and handling
    class CollisionDetector : ICollisionDetector
    {
        private List<IGameObject> _sortedList;
        private List<Tuple<IGameObject, IGameObject, Direction>> _collisionList;

        private void Insert(IGameObject element)
        {
            if (_sortedList.Count == 0)
            {
                _sortedList.Add(element);
                return;
            }

            int position = 0;

            while (position < _sortedList.Count && _sortedList[position].ObjectRectangle.X < element.ObjectRectangle.X)
            {
                position++;
            }

            _sortedList.Insert(position, element);
        }

        private void InsertionSortList(List<IGameObject> objects, List<IGameObject> projectiles)
        {
            _sortedList = new List<IGameObject>();
            for (int i = 0; i < objects.Count; i++)
            {
                Insert(objects[i]);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                Insert(projectiles[i]);
            }
        }

        // does not check for right since left object is guranteed to be left with sorting
        private static Direction CheckDirection(Rectangle rectangle1, Rectangle rectangle2)
        {
            int Left1 = rectangle1.X;
            int Left2 = rectangle2.X;
            int Up1 = rectangle1.Y;
            int Up2 = rectangle2.Y;
            int Down1 = rectangle1.Y + rectangle1.Height;
            int Down2 = rectangle2.Y + rectangle2.Height;

            Direction direction = Direction.Left;
            int minDist = Left2 - Left1;

            if (Up2 - Up1 < minDist)
            {
                direction = Direction.Up;
                minDist = Up2 - Up1;
            }

            if (Down2 - Down1 < minDist)
            {
                direction = Direction.Down;
            }

            return direction;
        }

        private bool CheckRectangle(Rectangle rectangle1, Rectangle rectangle2)
        {
            Rectangle Intersection = Rectangle.Intersect(rectangle1, rectangle2);
            return !Intersection.IsEmpty;
        }

        private void FindIntersections(int i)
        {
            for (int j = i + 1; j < _sortedList.Count; j++)
            {
                if (CheckRectangle(_sortedList[i].ObjectRectangle, _sortedList[j].ObjectRectangle))
                {
                    Direction direction = CheckDirection(_sortedList[i].ObjectRectangle, _sortedList[j].ObjectRectangle);
                    _collisionList.Add(new Tuple<IGameObject, IGameObject, Direction>(_sortedList[i], _sortedList[j], direction));

                    if (_sortedList[j].ObjectRectangle.X > _sortedList[i].ObjectRectangle.X + _sortedList[i].ObjectRectangle.Width)
                    {
                        break;
                    }
                }
            }
        }

        public List<Tuple<IGameObject, IGameObject, Direction>> FindCollisions(List<IGameObject> objects, List<IGameObject> projectiles)
        {
            _collisionList = new List<Tuple<IGameObject, IGameObject, Direction>>();
            InsertionSortList(objects, projectiles);

            for (int i = 0; i < _sortedList.Count; i++)
            {
                FindIntersections(i);
            }

            return _collisionList;
        }
    }
}
