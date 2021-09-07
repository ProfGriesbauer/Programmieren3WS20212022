using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public interface IGameRules
    {
        //Name of the Rules: possibly use a unique name
        string Name { get; }

        //Gets the current state of the game field; the class implementing
        //this interface should hold a game field corresponding to the rules
        //it implements
        IGameField CurrentField { get; }

        //Returns if there are any possible move available for the current game field
        bool MovesPossible { get; }

        //Adds the given move to the current game field if possible
        void DoMove(IPlayMove move);

        //Clears and resets the current game field
        void ClearField();

        //Returns the number of a player who won using the current field
        //RETURN -1 IF NO PLAYER WON
        int CheckIfPLayerWon();
    }

    public interface IGameField
    {
        //Returns true, if the given this game field can be painted by the given painter
        bool CanBePaintedBy(IPaintGame painter);
    }
}
