using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    //Erbreihenfolge: BaseTicTactoe(abstrakte Klasse) : ITickTacToe : I
    class GGHumanTicTacToePlayer : BaseHumanTicTacToePlayer
    {
        //CanBeRuled und GetMove sind bereits in abstrakter Klasse implementiert

        int _PlayerNumber = 0;
        //Name of the Game Player: possibly use a unique name
        public override string Name { get { return "GGHumanTicTacToePlayer"; }  }

        //Returns new object being a clone of the current player
        public override IGamePlayer Clone()
        {
            TicTacToeHumanPlayer ttthpg = new TicTacToeHumanPlayer();
            ttthpg.SetPlayerNumber(_PlayerNumber);
            return ttthpg;
        }
        //GetMove in Abstrakter Klasse prüft nur, ob field== TicTacToeField
        //Warum wird dann die Methode dieser Subklasse aufgerufen?
        //Methode werden zwei Koordinaten übergeben, prüft, welches Feld aus 3x3 Matrix betroffen, gibt TTTMove zurück
        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            for (int i = 0; i<3; i++)
            {
                for (int j = 0; j<3; j++)
                {
                    if (selection.XClickPos > 20 + (j*100) && selection.XClickPos < 120 + (j*100) &&
                        selection.YClickPos > 20 + (i*100) && selection.YClickPos < 120 + (i*100))
                    {
                        return new TicTacToeMove(i, j, _PlayerNumber);
                    }
                }
            }

            return null;
            
        }
        //Sets the player number of this player; this number should be
        //stored by the implementing class and should be used for any
        //given play move
        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}
