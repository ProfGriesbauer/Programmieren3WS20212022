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
    public class TicTacToePaint : BaseTicTacToePaint
    {
        public override string Name { get { return "GriesbauerTicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 120 + (j * 100), Y2 = 120 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100), Y1 = 120 + (i * 100), X2 = 120 + (j * 100), Y2 = 20 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }

    public class TicTacToeRules : BaseTicTacToeRules
    {
        TicTacToeField _Field = new TicTacToeField();

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

        public override string Name { get { return "GriesbauerTicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Field[i, 0] == p && _Field[i, 1] == p && _Field[i, 2] == p)
                    {
                        return p;
                    }
                    else if (_Field[i, 0] == p && _Field[i, 1] == p && _Field[i, 2] == p)
                    {
                        return p;
                    }
                }

                if (_Field[0, 0] == p && _Field[1, 1] == p && _Field[2, 2] == p ||
                    _Field[0, 2] == p && _Field[1, 1] == p && _Field[2, 0] == p)
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
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }

    public class TicTacToeField : BaseTicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0 , 0}, { 0, 0, 0 }, { 0, 0, 0 } };

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

    public class TicTacToeMove : ITicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public TicTacToeMove (int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GriesbauerHumanTicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            TicTacToeHumanPlayer ttthp = new TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
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

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    public class TicTacToeComputerPlayer : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GriesbauerComputerTicTacToePlayer"; } }

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
