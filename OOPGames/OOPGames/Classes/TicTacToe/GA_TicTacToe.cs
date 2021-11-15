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
    public class BiemelPainter : BaseTicTacToePaint
    {
        public override string Name { get { return "BiemelPainter"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color shadowColor = Color.FromRgb(64, 64, 64);
            Brush shadowStroke = new SolidColorBrush(shadowColor);
            Color XColor = Color.FromRgb(0, 0, 255);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 0, 0);
            Brush OStroke = new SolidColorBrush(OColor);

            Line l1 = new Line() { X1 = 20, Y1 = 20, X2 = 20, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 320, Y1 = 20, X2 = 320, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 20, Y1 = 20, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 20, Y1 = 320, X2 = 320, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);

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

    public class BiemelPainterAlt1 : BaseTicTacToePaint
    {
        public override string Name { get { return "BiemelPainterAlt1"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Brush bgStroke = new SolidColorBrush(bgColor);
            Color boardColor = Color.FromRgb(0, 0, 0);
            Brush boardStroke = new SolidColorBrush(boardColor);
            Color fieldColor = Color.FromRgb(230, 230, 230);
            Brush fieldStroke = new SolidColorBrush(fieldColor);

            Color xColor = Color.FromRgb(0, 0, 255);
            Brush xStroke = new SolidColorBrush(xColor);
            Color xgColor = Color.FromRgb(100, 100, 255);
            Brush xgStroke = new SolidColorBrush(xgColor);
            Color xggColor = Color.FromRgb(200, 200, 255);
            Brush xggStroke = new SolidColorBrush(xggColor);

            Color oColor = Color.FromRgb(255, 0, 0);
            Brush oStroke = new SolidColorBrush(oColor);
            Color ogColor = Color.FromRgb(255, 100, 100);
            Brush ogStroke = new SolidColorBrush(ogColor);
            Color oggColor = Color.FromRgb(255, 200, 200);
            Brush oggStroke = new SolidColorBrush(oggColor);

            Rectangle Board = new Rectangle() { Margin = new Thickness(20, 20, 0, 0), Width = 300, Height = 300, Stroke = boardStroke, StrokeThickness = 3.0 };
            Board.Fill = boardStroke;
            canvas.Children.Add(Board);
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Ellipse El = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = boardStroke, StrokeThickness = 2.0 };
                    El.Fill = fieldStroke;
                    canvas.Children.Add(El);

                    if(currentField[i,j] == 1)
                    {
                        Line X11 = new Line() { X1 = 40 + (j * 100), Y1 = 40 + (i * 100), X2 = 100 + (j * 100), Y2 = 100 + (i * 100), Stroke = xggStroke, StrokeThickness = 10.0 };
                        canvas.Children.Add(X11);
                        Line X21 = new Line() { X1 = 40 + (j * 100), Y1 = 100 + (i * 100), X2 = 100 + (j * 100), Y2 = 40 + (i * 100), Stroke = xggStroke, StrokeThickness = 10.0 };
                        canvas.Children.Add(X21);
                        Line X12 = new Line() { X1 = 42 + (j * 100), Y1 = 42 + (i * 100), X2 = 98 + (j * 100), Y2 = 98 + (i * 100), Stroke = xgStroke, StrokeThickness = 6.0 };
                        canvas.Children.Add(X12);
                        Line X22 = new Line() { X1 = 42 + (j * 100), Y1 = 98 + (i * 100), X2 = 98 + (j * 100), Y2 = 42 + (i * 100), Stroke = xgStroke, StrokeThickness = 6.0 };
                        canvas.Children.Add(X22);
                        Line X13 = new Line() { X1 = 44 + (j * 100), Y1 = 44 + (i * 100), X2 = 96 + (j * 100), Y2 = 96 + (i * 100), Stroke = xStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X13);
                        Line X23 = new Line() { X1 = 44 + (j * 100), Y1 = 96 + (i * 100), X2 = 96 + (j * 100), Y2 = 44 + (i * 100), Stroke = xStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X23);
                        Line X14 = new Line() { X1 = 45 + (j * 100), Y1 = 45 + (i * 100), X2 = 95 + (j * 100), Y2 = 95 + (i * 100), Stroke = xggStroke, StrokeThickness = 1.0 };
                        canvas.Children.Add(X14);
                        Line X24 = new Line() { X1 = 45 + (j * 100), Y1 = 95 + (i * 100), X2 = 95 + (j * 100), Y2 = 45 + (i * 100), Stroke = xggStroke, StrokeThickness = 1.0 };
                        canvas.Children.Add(X24);
                    }
                    else if(currentField[i,j] == 2)
                    {
                        Ellipse OE11 = new Ellipse() { Margin = new Thickness(30 + (j * 100), 30 + (i * 100), 0, 0), Width = 80, Height = 80, Stroke = oggStroke, StrokeThickness = 10.0 };
                        canvas.Children.Add(OE11);
                        Ellipse OE12 = new Ellipse() { Margin = new Thickness(31 + (j * 100), 31 + (i * 100), 0, 0), Width = 78, Height = 78, Stroke = ogStroke, StrokeThickness = 6.0 };
                        canvas.Children.Add(OE12);
                        Ellipse OE13 = new Ellipse() { Margin = new Thickness(32 + (j * 100), 32 + (i * 100), 0, 0), Width = 76, Height = 76, Stroke = oStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE13);
                        Ellipse OE14 = new Ellipse() { Margin = new Thickness(33 + (j * 100), 33 + (i * 100), 0, 0), Width = 75, Height = 75, Stroke = oggStroke, StrokeThickness = 1.0 };
                        canvas.Children.Add(OE14);
                    }
                }
            }
        }
    }

    public class BiemelRules : BaseTicTacToeRules
    {
        TicTacToeField _Board = new TicTacToeField();

        public override ITicTacToeField TicTacToeField { get { return _Board; } }

        public override bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_Board[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
        public override string Name { get { return "BiemelRules"; } }

        public override int CheckIfPLayerWon()
        {
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Board[i, 0] == p && _Board[i, 1] == p && _Board[i, 2] == p)
                    {
                        return p;
                    }
                    else if (_Board[0, i] == p && _Board[1, i] == p && _Board[2, i] == p)
                    {
                        return p;
                    }
                }

                if (_Board[0, 0] == p && _Board[1, 1] == p && _Board[2, 2] == p ||
                    _Board[0, 2] == p && _Board[1, 1] == p && _Board[2, 0] == p)
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
                    _Board[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3 &&_Board[move.Row, move.Column] == 0)
            {
                _Board[move.Row, move.Column] = move.PlayerNumber;
            }
          
        }


    }
    public class GA_TicTacToeComputerPlayer : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GA_ComputerTicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            GA_TicTacToeComputerPlayer ttthp = new GA_TicTacToeComputerPlayer();
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