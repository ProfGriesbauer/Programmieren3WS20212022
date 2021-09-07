using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames
{
    //Any game painting on the canvas needs to implement this interface
    public interface IPaintGame
    {
        //Name of the Game Painter: possibly use a unique name
        string Name { get; }

        //Paints the given game field on the given canvas
        //NOTE: Clearing the canvas, etc. has to be done within this function
        void PaintGameField(Canvas canvas, IGameField currentField);
    }

    //Any game requesting mouse click positions from the canvas get the latter
    //via this interface
    public interface IMoveSelection
    {
        //X position of the mouse click
        int XClickPos { get; }

        //Y Position of the mouse click
        int YClickPos { get; }
    }
}
