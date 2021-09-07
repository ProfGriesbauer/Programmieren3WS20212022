using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    //Any play move has to implement this interface
    public interface IPlayMove
    {
        //Number of the player doing the move.
        int PlayerNumber { get; }
    }

    //A move including the selection of a row
    public interface IRowMove : IPlayMove
    {
        //Row of the move
        int Row { get; }
    }

    //A move including the selection of a column
    public interface IColumnMove : IPlayMove
    {
        //Column of the move
        int Column { get; }
    }
}
