using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HexLib;
using UnitLib;

namespace TGWv2.ViewModel
{
    public static class ViewModel
    {
        private static HexBoard _board;
        private static Config _config = Config.Instance;
        private static List<Unit> _units = new List<Unit>();
        private static List<List<Overlay>> _overLayTiles = new List<List<Overlay>>();
        private static List<HexField> _potentialMoves = null;
        private static List<HexField> _potentialTargets = new List<HexField>();
        private static Unit SelectedUnit;
        private static List<Player> _players = new List<Player>();
        private static Player _currentPlayer;
        public static void CreateBoard()
        {
            _board = new HexBoard(_config.BoardHeight, _config.BoardWidth);
            for (int x = 0; x < _config.BoardHeight; x++)
            {
                _overLayTiles.Add(new List<Overlay>());
                foreach (HexField tile in _board.GetRow(x))
                {
                    if (tile == null)
                        _overLayTiles[x].Add(null);
                    else
                    {
                        Overlay overlayTile = new Overlay();
                        overlayTile.Center = tile.Center;
                        overlayTile.Radius = tile.Radius;
                        overlayTile.State = OverlayStates.normal;
                        overlayTile.MapTile = tile;
                        _overLayTiles[x].Add(overlayTile);
                    }
                }
            }
            
        }

        internal static void StartGame()
        {
            _currentPlayer = _players[0];
        }

        public static List<Unit> Units
        {
            get { return _units; }
            set
            {
                _units = value;
            }
        }

        public static HexBoard Board
        {
            get { return _board; }
            set
            {
                _board = value;
            }
        }

        public static List<List<Overlay>> OverlayTiles
        {
            get { return _overLayTiles; }
        }

        public static List<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
            }
        }

        internal static void CreateUnits()
        {
            int Upperbound = 3;
            int Lowerbound = 0;
            Random rnd = new Random();

            for (int x = 0; x<2; x++)
            {
                _players.Add(new Player("Player" + (x+1)));
            }
            List<HexField> usedTiles = new List<HexField>();
            foreach (Player player in _players)
            {
                player.Units.Clear();
                if (player == _players[0])
                {
                    Upperbound = 3;
                    Lowerbound = 0;
                }
                else if (player == _players[1])
                {
                    Upperbound = Board.BoardHeight - 1;
                    Lowerbound = Board.BoardHeight - 4;
                }
                else
                { break; }
                if (_config.UseInfantry)
                {
                    //List<HexField> usedTiles = new List<HexField>();
                    for (int unitnum = 0; unitnum < _config.NumberOfInfantry; unitnum++)
                    {

                        bool placed = false;
                        Unit unit = new InfantryUnit(player);

                        while (!placed)
                        {
                            HexField selectedTile = null;
                            int x = 0;
                            int y = 0;
                            while (selectedTile == null || selectedTile.TerrainType == TerrainTypes.Mountain || usedTiles.Contains(selectedTile))
                            {
                                x = rnd.Next(Lowerbound, Upperbound);
                                y = rnd.Next(_board.getFirstTile(x), _board.GetRowSize(x) - 1);
                                selectedTile = _board.getTile(x, y);

                            }
                            unit.Center = selectedTile.Center;
                            _overLayTiles[x][y].Unit = unit;
                            usedTiles.Add(selectedTile);
                            player.Units.Add(unit);
                        }


                    }
                }

                if (_config.UseArmoredCar)
                {
                    
                    for (int unitnum = 0; unitnum < _config.NumberOfArmoredCar; unitnum++)
                    {
                        bool placed = false;
                        Unit unit = new ArmoredCarUnit(player);
                        int x = 0;
                        int y = 0;
                        while (!placed)
                        {
                            HexField selectedTile = null;
                            while (selectedTile == null || selectedTile.TerrainType == TerrainTypes.Mountain || usedTiles.Contains(selectedTile))
                            {
                                x = rnd.Next(Lowerbound, Upperbound);
                                y = rnd.Next(_board.getFirstTile(x), _board.GetRowSize(x) - 1);
                                selectedTile = _board.getTile(x, y);
                            }
                            unit.Center = selectedTile.Center;
                            unit.Tile = selectedTile;
                            selectedTile.Unit = unit;
                            selectedTile.IsOccupied = true;
                            _overLayTiles[x][y].Unit = unit;
                            player.Units.Add(unit);
                            usedTiles.Add(selectedTile);
                            placed = true;
                        }
                    }

                }
                if (_config.UseArtillery)
                {
                    for (int unitnum = 0; unitnum < _config.NumberOfArtillery; unitnum++)
                    {
                        throw (new NotImplementedException());
                        /*
                        bool placed = false;
                        Unit unit = new ArtileryUnit();

                        while (!placed)
                        {
                            HexField selectedTile = null;
                            while (selectedTile == null || selectedTile.TerrainType == TerrainTypes.Mountain || selectedTile.CurrentUnit != null)
                            {
                                int x = rnd.Next(player1Lowerbound, player1Upperbound);
                                int y = rnd.Next(_board.getFirstTile(x), _board.GetRowSize(x) - 1);
                                selectedTile = _board.getTile(x, y);
                            }
                            unit.Center = selectedTile.Center;
                            selectedTile.CurrentUnit = unit;
                            _units.Add(unit);
                        }*/
                    }
                }
                //player.Units = _units;
                _units.Clear();
            }
        }

        internal static void endTurn()
        {
            int x;

            foreach (Unit unit in _currentPlayer.Units)
            {
                unit.HasMoved = false;
            }

            for (x = 0; x< _players.Count(); x++)
            {
                if (_currentPlayer == _players[x])
                    break;
            }
            if (x == _players.Count() - 1)
                x = 0;
            else
                x += 1;

            _currentPlayer = _players[x];
        }

        public static void FieldClicked(HexField clickedTile)
        {
            if (clickedTile.IsOccupied)
            {
                if (SelectedUnit == null)
                {
                    if ((clickedTile.Unit as Unit).Owner as Player == _currentPlayer && !(clickedTile.Unit as Unit).HasMoved)
                    {
                        SelectedUnit = clickedTile.Unit as Unit;
                        List<HexField> tmp = new List<HexField>();

                        _potentialMoves = Board.getPossibleMoves(clickedTile, SelectedUnit.MovementSpeed);

                        for (var x = 0; x < _potentialMoves.Count(); x++)
                        {
                            if (_potentialMoves[x].IsOccupied)
                            {
                                tmp.Add(_potentialMoves[x]);
                            }

                        }
                        foreach(HexField hex in tmp)
                        {
                            _potentialMoves.Remove(hex);
                        }

                        tmp.Clear();
                        tmp = Board.markPotential(clickedTile, SelectedUnit.AttackRange);
                        foreach(HexField inRange in tmp)
                        {
                            if (inRange.IsOccupied)
                            {
                                _potentialTargets.Add(inRange);
                                
                            }
                        }
                        foreach (HexField tile in _potentialMoves)
                        {
                            _overLayTiles[tile.XCoord][tile.YCoord].State = OverlayStates.possible;
                        }
                        foreach(HexField tile in _potentialTargets)
                        {
                            _overLayTiles[tile.XCoord][tile.YCoord].State = OverlayStates.possible;
                        }
                        _overLayTiles[clickedTile.XCoord][clickedTile.YCoord].State = OverlayStates.selected;
                    } 
                }
                else
                {
                    if ((clickedTile.Unit as Unit).Owner as Player != _currentPlayer)
                    {
                        //Perform attack
                        throw (new NotImplementedException("To be made"));
                    }
                    else if (SelectedUnit == clickedTile.Unit as Unit)
                    {
                        SelectedUnit = null;
                        //clickedTile.State = TileState.Potential;
                        _overLayTiles[clickedTile.XCoord][clickedTile.YCoord].State = OverlayStates.normal;
                        foreach (HexField tile in _potentialMoves)
                        {
                            _overLayTiles[tile.XCoord][tile.YCoord].State = OverlayStates.normal;
                        }
                        foreach (HexField tile in _potentialTargets)
                        {
                            _overLayTiles[tile.XCoord][tile.YCoord].State = OverlayStates.normal;
                        }
                        _potentialTargets.Clear();
                        _potentialMoves.Clear();
                    }
                }
            }
            else
            {
                if (SelectedUnit != null)
                {
                    if (_potentialMoves.Contains(clickedTile))
                    {
                        //perform move
                        HexField oldTile = SelectedUnit.Tile as HexField;
                        oldTile.IsOccupied = false;
                        clickedTile.IsOccupied = true;
                        oldTile.Unit = null;
                        clickedTile.Unit = SelectedUnit;
                        SelectedUnit.Center = clickedTile.Center;
                        SelectedUnit.Tile = clickedTile;
                        _overLayTiles[oldTile.XCoord][oldTile.YCoord].State = OverlayStates.normal;
                        SelectedUnit.HasMoved = true;
                        SelectedUnit = null;
                        foreach (HexField tile in _potentialMoves)
                        {
                            _overLayTiles[tile.XCoord][tile.YCoord].State = OverlayStates.normal;
                        }
                        foreach (HexField tile in _potentialTargets)
                        {
                            _overLayTiles[tile.XCoord][tile.YCoord].State = OverlayStates.normal;
                        }
                        _potentialTargets.Clear();
                        _potentialMoves.Clear();
                    }
                }
            }
        }
    }
}
