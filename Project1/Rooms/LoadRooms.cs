using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Zelda.Environment;
using Zelda.GameState;
using Zelda.Interfaces;

namespace Zelda.Rooms
{
    // https://stackoverflow.com/questions/5282999/reading-csv-file-and-storing-values-into-an-array csv parsing reference
    public class LoadRooms
    {
        private readonly string _file;
        private readonly GameManager _gm;
        private int _blockOffset;
        private int _roomRows;
        private int _roomColumns;
        private int _numRooms;
        private Rectangle _frame;
        private int _roomID;
        private readonly Dictionary<int, IRoom> _roomDict;
        private readonly List<string> _validObjectStrings = new List<string>() { RoomConstants.Tile, RoomConstants.Boss, RoomConstants.Enemy, RoomConstants.NPC, RoomConstants.Item };

        public LoadRooms (string lf, GameManager gm)
        {
            _file = lf;
            _gm = gm;
            _roomDict = new Dictionary<int, IRoom>();
        }

        private void ReadRoomFrameAndID(TextReader reader)
        {
            var header = reader.ReadLine();
            var headerTokens = header.Split(',');

            if (!int.TryParse(headerTokens[0], out int RoomID))
            {
                throw new InvalidOperationException("Invalid room ID");
            }
            _roomID = RoomID;

            if (!int.TryParse(headerTokens[1], out int RoomX))
            {
                throw new InvalidOperationException("Invalid room leftmost point");
            }
            if (!int.TryParse(headerTokens[2], out int RoomY))
            {
                throw new InvalidOperationException("Invalid room topmost point");
            }
            if (!int.TryParse(headerTokens[3], out int RoomW))
            {
                throw new InvalidOperationException("Invalid room width");
            }
            if (!int.TryParse(headerTokens[4], out int RoomH))
            {
                throw new InvalidOperationException("Invalid room height");
            }
            _frame = new Rectangle(RoomX, RoomY, RoomW, RoomH);
        }

        private IGameObject ReadPortal(string tokenString)
        {
            var tokens = tokenString.Split(' ');
            if (!int.TryParse(tokens[0], out int ID))
            {
                throw new InvalidOperationException("Invalid room ID");
            }

            if (!int.TryParse(tokens[1], out int vectorX))
            {
                throw new InvalidOperationException("Invalid vector");
            }

            if (!int.TryParse(tokens[2], out int vectorY))
            {
                throw new InvalidOperationException("Invalid vector");
            }

            if (!int.TryParse(tokens[3], out int positionX))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (!int.TryParse(tokens[4], out int positionY))
            {
                throw new InvalidOperationException("Invalid position");
            }

            if (!int.TryParse(tokens[5], out int doorType))
            {
                throw new InvalidOperationException("Invalid Doortype");
            }

            IGameObject portal = new InvisiblePortal(new Vector2(vectorX, vectorY));
            ((InvisiblePortal)portal).NextRoomID = ID;
            ((InvisiblePortal)portal).DoorType = doorType;
            ((InvisiblePortal)portal).NextPosition = new Vector2(positionX, positionY);

            return portal;
        }

        private void ReadDoorsAndStairs(TextReader reader, Dictionary<IGameObject, int> portalObjects)
        {
            var subheader = reader.ReadLine();
            var subheaderTokens = subheader.Split(',');

            var portalNorth = subheaderTokens[0].Split(' ');
            if (!int.TryParse(portalNorth[0], out int North))
            {
                throw new InvalidOperationException("Invalid room portal north");
            }

            if (North > 0)
            {
                IGameObject portal = ReadPortal(subheaderTokens[0]);
                portalObjects.Add(portal, ((InvisiblePortal)portal).DoorType);
            }

            var portalEast = subheaderTokens[1].Split(' ');
            if (!int.TryParse(portalEast[0], out int East))
            {
                throw new InvalidOperationException("Invalid room portal east");
            }

            if (East > 0)
            {
                IGameObject portal = ReadPortal(subheaderTokens[1]);
                portalObjects.Add(portal, ((InvisiblePortal)portal).DoorType);
            }

            var portalSouth = subheaderTokens[2].Split(' ');
            if (!int.TryParse(portalSouth[0], out int South))
            {
                throw new InvalidOperationException("Invalid room portal south");
            }

            if (South > 0)
            {
                IGameObject portal = ReadPortal(subheaderTokens[2]);
                portalObjects.Add(portal, ((InvisiblePortal)portal).DoorType);
            }

            var portalWest = subheaderTokens[3].Split(' ');
            if (!int.TryParse(portalWest[0], out int West))
            {
                throw new InvalidOperationException("Invalid room portal west");
            }

            if (West > 0)
            {
                IGameObject portal = ReadPortal(subheaderTokens[3]);
                portalObjects.Add(portal, ((InvisiblePortal)portal).DoorType);
            }

            var portalStair = subheaderTokens[4].Split(' ');
            if (!int.TryParse(portalStair[0], out int Stair))
            {
                throw new InvalidOperationException("Invalid room portal stairs");
            }

            if (Stair > 0)
            {
                IGameObject portal = ReadPortal(subheaderTokens[4]);
                portalObjects.Add(portal, ((InvisiblePortal)portal).DoorType);
            }
        }

        private void ReadRoomObjects(TextReader reader, Dictionary<Vector2, string> parsedDict)
        {
            Vector2 CurrentPosition = new Vector2(_gm.RoomFloorPoint.X, _gm.RoomFloorPoint.Y);
            for (int i = 0; i < _roomRows; i++)
            {
                var line = reader.ReadLine();
                var tokens = line.Split(',');

                for (int j = 0; j < _roomColumns; j++)
                {
                    if (tokens[j] != RoomConstants.Empty && _validObjectStrings.Contains(tokens[j].Substring(0, 2)))
                    {
                        Vector2 ObjectPosition = new Vector2(CurrentPosition.X, CurrentPosition.Y);
                        parsedDict.Add(ObjectPosition, tokens[j]);
                    }
                    CurrentPosition.X += _blockOffset;
                }

                CurrentPosition.Y += _blockOffset;
                CurrentPosition.X = _gm.RoomFloorPoint.X;
            }
        }

        private void ConsumeEmptyLine(TextReader reader)
        {
            reader.ReadLine();
        }

        private void ParseRoom(TextReader reader)
        {
            Dictionary<Vector2, string> ParsedDict = new Dictionary<Vector2, string>();
            Dictionary<IGameObject, int> PortalObjects = new Dictionary<IGameObject, int>();

            ReadRoomFrameAndID(reader);
            ReadDoorsAndStairs(reader, PortalObjects);
            ReadRoomObjects(reader, ParsedDict);

            Room ParsedRoom = new Room(ParsedDict, PortalObjects);
            ParsedRoom.PortalBoundaryObjects = PortalObjects;
            ParsedRoom.Frame = _frame;
            _roomDict.Add(_roomID, ParsedRoom);
            ConsumeEmptyLine(reader);
        }

        private void ReadRoomNum(string roomNum)
        {
            if (!int.TryParse(roomNum, out int NumRooms))
            {
                throw new InvalidOperationException("Invalid number of room");
            }
            _gm.MaxRoomID = NumRooms;
            _numRooms = NumRooms;
        }

        private void ReadInitialRoom(string roomNum)
        {
            if (!int.TryParse(roomNum, out int InitialRoom))
            {
                throw new InvalidOperationException("Invalid starting room number");
            }
            _gm.StartingRoomID = InitialRoom;
            _gm.CurrentRoomID = InitialRoom;
        }

        private void ReadRoomCorner(string left, string top)
        {
            if (!int.TryParse(left, out int Left))
            {
                throw new InvalidOperationException("Invalid leftmost point");
            }
            if (!int.TryParse(top, out int Top))
            {
                throw new InvalidOperationException("Invalid topmost point");
            }
            _gm.RoomFramePoint = new Vector2(Left, Top);
        }

        private void ReadFloorCorner(string left, string top)
        {
            if (!int.TryParse(left, out int LeftF))
            {
                throw new InvalidOperationException("Invalid leftmost point");
            }
            if (!int.TryParse(top, out int TopF))
            {
                throw new InvalidOperationException("Invalid topmost point");
            }
            _gm.RoomFloorPoint = new Vector2(LeftF, TopF);
        }

        private void ReadBlockOffset(string offset)
        {
            if (!int.TryParse(offset, out int Offset))
            {
                throw new InvalidOperationException("Invalid block offset");
            }
            _blockOffset = Offset;
        }

        private void ReadRowsAndColumns(string rows, string columns)
        {
            if (!int.TryParse(rows, out int Rows))
            {
                throw new InvalidOperationException("Invalid number of rows");
            }
            _roomRows = Rows;
            if (!int.TryParse(columns, out int Columns))
            {
                throw new InvalidOperationException("Invalid number of columns");
            }
            _roomColumns = Columns;
        }

        private void ReadRooms(TextReader reader)
        {
            for (int i = 0; i < _numRooms; i++)
            {
                ParseRoom(reader);
            }
        }

        private void ReadInitialPosition(string position)
        {
            var positions = position.Split(' ');

            if (!int.TryParse(positions[0], out int positionX))
            {
                throw new InvalidOperationException("Invalid x position");
            }
            if (!int.TryParse(positions[1], out int positionY))
            {
                throw new InvalidOperationException("Invalid y position");
            }
            _gm.Player.Point.ObjectPoint = new Vector2(positionX, positionY);
        }

        private void ReadWall(string wallString)
        {
            var tokens = wallString.Split(' ');

            if (!int.TryParse(tokens[0], out int wallX))
            {
                throw new InvalidOperationException("Invalid boundary x");
            }

            if (!int.TryParse(tokens[1], out int wallY))
            {
                throw new InvalidOperationException("Invalid boundary y");
            }

            if (!int.TryParse(tokens[2], out int wallWidth))
            {
                throw new InvalidOperationException("Invalid boundary width");
            }

            if (!int.TryParse(tokens[3], out int wallHeight))
            {
                throw new InvalidOperationException("Invalid boundary height");
            }

            IGameObject wallObject = new InvisibleWall();
            ((InvisibleWall)wallObject).ObjectRectangle = new Rectangle(wallX, wallY, wallWidth, wallHeight);

            foreach (KeyValuePair<int, IRoom> entry in _roomDict)
            {
                entry.Value.PortalBoundaryObjects.Add(wallObject, -1);
            }
        }

        private void ReadBoundaries(TextReader reader)
        {
            var boundary = reader.ReadLine();
            var boundaryTokens = boundary.Split(',');
            string front = boundaryTokens[0];
            int i = 0;
            while (front != "")
            {
                ReadWall(front);
                i += 1;
                front = boundaryTokens[i];
            }
        }

        private void ReadMap(TextReader reader)
        {
            /* read width + height */
            var header = reader.ReadLine();
            var headerTokens = header.Split(',');

            if (!int.TryParse(headerTokens[0], out int roomHorizontalCount))
            {
                throw new InvalidOperationException("Invalid room horizontal count");
            }

            if (!int.TryParse(headerTokens[1], out int roomVerticalCount))
            {
                throw new InvalidOperationException("Invalid room vertical count");
            }

            Dictionary<IRoom, Vector2> roomOffsets = new Dictionary<IRoom, Vector2>();

            for (int i = 0; i < roomHorizontalCount; i++)
            {
                var line = reader.ReadLine();
                var lineTokens = line.Split(',');

                for (int j = 0; j < roomVerticalCount; j++)
                {
                    Vector2 offset = new Vector2(j, i);

                    if (!int.TryParse(lineTokens[j], out int roomID))
                    {
                        throw new InvalidOperationException("Invalid room ID");
                    }

                    if (roomID > 0)
                    {
                        roomOffsets.Add(_roomDict[roomID], offset);
                    }
                }
            }
            /* read rooms + calc offset vectors */
            /* set map object value */
            _gm.HUD.Map.SetRooms(roomOffsets, roomHorizontalCount, roomVerticalCount);
        }
        
        private void ResetRooms()
        {
            foreach (KeyValuePair<int, IRoom> entry in _roomDict)
            {
                entry.Value.ResetRoom();
            }
        }

        private void ParseDungeon()
        {
            using (var reader = new StreamReader(_file))
            {
                var line = reader.ReadLine();
                var tokens = line.Split(',');

                ReadRoomNum(tokens[0]);
                ReadInitialRoom(tokens[1]);
                ReadRoomCorner(tokens[2], tokens[3]);
                ReadFloorCorner(tokens[4], tokens[5]);
                ReadBlockOffset(tokens[6]);
                ReadRowsAndColumns(tokens[7], tokens[8]);
                ReadInitialPosition(tokens[9]);
                ConsumeEmptyLine(reader);
                ReadRooms(reader);
                ReadBoundaries(reader);
                ResetRooms();
                ConsumeEmptyLine(reader);
                ReadMap(reader);
            }
        }

        public void Load()
        {
            ParseDungeon();
            _gm.RoomDict = _roomDict;
        }
    }
}