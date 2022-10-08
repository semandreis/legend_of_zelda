using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Zelda.Environment;
using Zelda.Interfaces;

namespace Zelda.Rooms
{
    class Room : IRoom
    {
        public int ID { get; set; }
        public List<IGameObject> ActiveObjects { get; set; }     
        public Rectangle Frame { get; set; }
        public bool Accessed { get; set; }
        public int EnemyNumber { get; set; }

        private readonly Dictionary<Vector2, string> _initialRoomContent;
        public Dictionary<IGameObject, int> PortalBoundaryObjects { get; set; }


        private void CreateObjects()
        {
            ActiveObjects = new List<IGameObject>();
            EnemyNumber = 0;
            foreach (KeyValuePair<Vector2, string> entry in _initialRoomContent)
            {
                if (entry.Value.StartsWith(RoomConstants.Boss))
                {
                    ActiveObjects.Add(ObjectCreator.CreateBoss(entry.Value, entry.Key));
                    EnemyNumber++;
                }
                else if (entry.Value.StartsWith(RoomConstants.Tile))
                {
                    ActiveObjects.Add(ObjectCreator.CreateTile(entry.Value, entry.Key));
                }
                else if (entry.Value.StartsWith(RoomConstants.Enemy))
                {
                    ActiveObjects.Add(ObjectCreator.CreateEnemy(entry.Value, entry.Key));
                    EnemyNumber++;
                }
                else if (entry.Value.StartsWith(RoomConstants.Item))
                {
                    ActiveObjects.Add(ObjectCreator.CreateItem(entry.Value, entry.Key));
                }
                else if (entry.Value.StartsWith(RoomConstants.NPC))
                {
                    ActiveObjects.Add(ObjectCreator.CreateNPC(entry.Value, entry.Key));
                }
                else
                {
                    throw new InvalidOperationException("Invalid object string");
                }
            }

            foreach (KeyValuePair<IGameObject, int> entry in PortalBoundaryObjects)
            {
                if (entry.Value > 0)
                {
                    ActiveObjects.Add(ObjectCreator.CreateDoor(entry.Value, entry.Key));
                }
                else if (entry.Value == -1)
                {
                    ActiveObjects.Add(entry.Key);
                }

            }
        }

        public Room(Dictionary<Vector2, string> roomObjects, Dictionary<IGameObject, int> portalBoundaryObjects)
        {
            PortalBoundaryObjects = portalBoundaryObjects;
            _initialRoomContent = roomObjects;
            Accessed = false;
        }

        public void InitializeRoom()
        {
            foreach (IGameObject element in ActiveObjects)
            {
                element.Initial();
            }
        }

        public void ResetRoom()
        {
            CreateObjects();
        }
    }
}
