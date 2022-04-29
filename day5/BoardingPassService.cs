using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5
{
    public class BoardingPass
    {
        public BoardingPass(int row, int col)
        {
            Row = row;
            Column = col;
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public int SeatId => Row * 8 + Column;
    }

    public class BoardingPassService
    {
        public BoardingPass ParseBoardingPass(string rawBoardingPass)
        {
            var rows = Enumerable.Range(0, 128);
            var columns = Enumerable.Range(0, 8);
            for (int i = 0; i < 7; i++)
            {
                if(rawBoardingPass[i] == 'F')
                    rows = rows.Take((rows.Count() + 1 ) / 2);

                if(rawBoardingPass[i] == 'B')
                    rows = rows.Skip((rows.Count() + 1) / 2);
            }

            for (int i = 7; i < rawBoardingPass.Length; i++)
            {
                if (rawBoardingPass[i] == 'L')
                    columns = columns.Take((columns.Count() + 1) / 2);

                if (rawBoardingPass[i] == 'R')
                    columns = columns.Skip((columns.Count() + 1) / 2);
            }


            var boardingPass = new BoardingPass(rows.First(), columns.First());

            return boardingPass;

        }
    }
}
