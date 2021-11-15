//Gruppe GI Stand: 15.11.2021, 10:06 Uhr

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
    public class GI_TicTacToePaint : BaseTicTacToePaint
    {
        public override string Name { get { return "GI_TicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            Line l1 = new Line() { X1 = 200, Y1 = 100, X2 = 200, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 300, Y1 = 100, X2 = 300, Y2 = 400, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 100, Y1 = 200, X2 = 400, Y2 = 200, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 100, Y1 = 300, X2 = 400, Y2 = 300, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 100 + (j * 100), Y1 = 100 + (i * 100), X2 = 200 + (j * 100), Y2 = 200 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 100 + (j * 100), Y1 = 200 + (i * 100), X2 = 200 + (j * 100), Y2 = 100 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(100 + (j * 100), 100 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }

    public class GI_TicTacToeRules : BaseTicTacToeRules
    {
        GI_TicTacToeField _Field = new GI_TicTacToeField();

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_Field[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public bool MovesPossiblefkt(int row, int column)
        {
            if (_Field[row, column] == 0)
            {
                return true;
            }
            
            return false;
        }

        public override string Name { get { return "GI_TicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Field[i, 0] == p && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                    {
                        return p;
                    }
                    else if (_Field[0, i] == p && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                    {
                        return p;
                    }
                }

                if ((_Field[0, 0] == p && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2]) ||
                    (_Field[0, 2] == p && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0]))
                {
                    return p;
                }
            }

            return -1;
        }

        public override void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3 && MovesPossiblefkt(move.Row, move.Column))
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }

    public class GI_TicTacToeField : BaseTicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public override int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Field[r, c];
                }
                else
                {
                    return -1;
                }
            }

            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    _Field[r, c] = value;
                }
            }
        }
    }

    public class GI_TicTacToeMove : ITicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public void TicTacToeMove (int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class GI_TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GI_HumanTicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            GI_TicTacToeHumanPlayer ttthp = new GI_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (selection.XClickPos > 100 + (j * 100) && selection.XClickPos < 200 + (j * 100) &&
                        selection.YClickPos > 100 + (i * 100) && selection.YClickPos < 200 + (i * 100))
                    {
                        return new TicTacToeMove(i, j, _PlayerNumber);
                    }
                }
            }

            return null;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    public class GI_TicTacToeComputerPlayer : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GI_TicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            TicTacToeComputerPlayer ttthp = new TicTacToeComputerPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(ITicTacToeField field)
        {
            Random rand = new Random();
            int f = rand.Next(0, 8);
            for (int i = 0; i < 9; i++)
            {
                int c = f % 3;
                int r = ((f - c) / 3) % 3;
                if (field[r, c] <= 0)
                {
                    return new TicTacToeMove(r, c, _PlayerNumber);
                }
                else
                {
                    f++;
                }
            }

            return null;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}
