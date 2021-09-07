using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    //Any player of any game has to implement this interface
    public interface IGamePlayer
    {
        //Name of the Game Player: possibly use a unique name
        string Name { get; }

        //Sets the player number of this player; this number should be
        //stored by the implementing class and should be used for any
        //given play move
        void SetPlayerNumber(int playerNumber);

        //Returns true, if the given rules can be used together with the implemented player
        bool CanBeRuledBy(IGameRules rules);

        //Returns new object being a clone of the current player
        IGamePlayer Clone();
    }

    //A humman player: the painter produces a selection which has to be validated
    public interface IHumanGamePlayer : IGamePlayer
    {
        //Returns a valid move if possible for the given selection and 
        //the given state of the play field.
        //IF THE GIVEN SELECTION IS NO VALID MOVE, NULL HAS TO BE RETURNED.
        IPlayMove GetMove(IMoveSelection selection, IGameField field);
    }

    //A computer player: when asked for a move, a valid move is produced by a computer
    public interface IComputerGamePlayer : IGamePlayer
    {
        //Returns a valid move for the given state of the play field.
        //IF NO VALID MOVE IS POSSIBLE, NULL HAS TO BE RETURNED.
        IPlayMove GetMove(IGameField field);
    }
}
