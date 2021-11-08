using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    public abstract class GD_TicTacToePaint : IPaintTicTacToe
    {
        public abstract string Name { get; }

        public abstract void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField);

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }
    }

    public abstract class GD_TicTacToeField : ITicTacToeField
    {
        public abstract int this[int r, int c] { get; set; }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }

    public abstract class GD_TicTacToeRules : ITicTacToeRules
    {
        public abstract ITicTacToeField TicTacToeField { get; }

        public abstract bool MovesPossible { get; }

        public abstract string Name { get; }

        public abstract int CheckIfPLayerWon();

        public abstract void ClearField();

        public abstract void DoTicTacToeMove(ITicTacToeMove move);

        public IGameField CurrentField { get { return TicTacToeField; } }

        public void DoMove(IPlayMove move)
        {
            if (move is ITicTacToeMove)
            {
                DoTicTacToeMove((ITicTacToeMove)move);
            }
        }
    }

    public abstract class GD_HumanTicTacToePlayer : IHumanTicTacToePlayer
    {
        public abstract string Name { get; }

        public abstract ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field);

        public abstract void SetPlayerNumber(int playerNumber);

        public abstract IGamePlayer Clone();

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove(selection, (ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }
    }

    public abstract class GD_ComputerTicTacToePlayer : IComputerTicTacToePlayer
    {
        public abstract string Name { get; }

        public abstract void SetPlayerNumber(int playerNumber);

        public abstract ITicTacToeMove GetMove(ITicTacToeField field);

        public abstract IGamePlayer Clone();

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules;
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove((ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }
    }
}
