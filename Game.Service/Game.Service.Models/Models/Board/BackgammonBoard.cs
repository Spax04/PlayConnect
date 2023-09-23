using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Service.Models.Models.Board
{
    public class BackgammonBoard
    {
        public Solider[] Soliders { get; set; }
        public BoardSpike[] boardSpikes { get; set; }
        public int soliders = 15;

        public BackgammonBoard()
        {
            GenerateStartingBoard();
            InitialSoliders();
        }
        public Solider[] InitialSoliders()
        {

            for (int i = 0; i < 14; i++)
            {
                Soliders[i] = new Solider();
            }
            return Soliders; 
        }
        public BoardSpike[] InitialBoard()
        {
            for (int i = 0; i < 24; i++)
            {
                boardSpikes[i] = new BoardSpike(i);
            }
            return boardSpikes;
        }
        public BoardSpike[] GenerateStartingBoard()
        {
            for (int i = 0; i < boardSpikes.Length; i++)
            {
                if (boardSpikes[i] == boardSpikes[0])
                {
                    for (int j = 0; j < 2; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() {Color = PlayerColor.White });
                    boardSpikes[i].AvailableSpike = false;
                }
                if (boardSpikes[i] == boardSpikes[11])
                {
                    for (int j = 0; j < 5; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.White });
                    boardSpikes[i].AvailableSpike = false;
                }

                if (boardSpikes[i] == boardSpikes[16])
                {
                    for (int j = 0; j < 3; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.White });
                    boardSpikes[i].AvailableSpike = false;
                }

                if (boardSpikes[i] == boardSpikes[18])
                {
                    for (int j = 0; j < 5; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.White });
                    boardSpikes[i].AvailableSpike = false;
                }
                // Opponnent
                if (boardSpikes[i] == boardSpikes[5])
                {
                    for (int j = 0; j < 5; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.Black });
                    boardSpikes[i].AvailableSpike = false;
                }
                if (boardSpikes[i] == boardSpikes[7])
                {
                    for (int j = 0; j < 3; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.Black });
                    boardSpikes[i].AvailableSpike = false;
                }
                if (boardSpikes[i] == boardSpikes[12])
                {
                    for (int j = 0; j < 5; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.Black });
                    boardSpikes[i].AvailableSpike = false;
                }
                if (boardSpikes[i] == boardSpikes[23])
                {
                    for (int j = 0; j < 2; j++)
                        boardSpikes[i].SolidersQuantity.Add(new Solider() { Color = PlayerColor.Black });
                    boardSpikes[i].AvailableSpike = false;
                }
            }
            return boardSpikes;
        }
    }
}
