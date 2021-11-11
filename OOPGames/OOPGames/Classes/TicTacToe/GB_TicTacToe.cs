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
    public class GB_TicTacToePaint : BaseTicTacToePaint
    {
        //Dieser Painter ist variabel gemacht worden - F-Wurm
        //Dieser Painter hat seinen eigenen Stil gekriegt - F-Wurm

        public override string Name { get { return "Gruppe B TicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            //Hier kann man das richtige Unterprogramm wählen

            if (currentField is GB_TicTacToeField)
            {
                PaintTicTacToeField_B(canvas, (GB_TicTacToeField)currentField);
            }
            else
            {
                PaintTicTacToeField_A(canvas, currentField);
            }

        }

        public void PaintTicTacToeField_A(Canvas canvas, ITicTacToeField currentField)
        {
            //Abgekupfert von der Vorlage

            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(32, 32, 32);
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

        public void PaintTicTacToeField_B(Canvas canvas, GB_TicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(32, 32, 32);
            canvas.Background = new SolidColorBrush(bgColor);
            Color backColor = Color.FromRgb(64, 64, 64);
            Brush backStroke = new SolidColorBrush(backColor);
            Color XColor = Color.FromRgb(0, 0, 255);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 255, 0);
            Brush OStroke = new SolidColorBrush(OColor);

            for (int i = 0; i < currentField.Rows; i++)
            {
                for (int j = 0; j < currentField.Columns; j++)
                {
                    int x0 = (j * 100), y0 = (i * 100);

                    Rectangle rect = new Rectangle() { Width = 90, Height = 90, Stroke = backStroke };
                    Canvas.SetLeft(rect, x0 + 25); Canvas.SetTop(rect, y0 + 25);
                    canvas.Children.Add(rect);

                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 30 + x0, Y1 = 30 + y0, X2 = 110 + x0, Y2 = 110 + y0, Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 30 + x0, Y1 = 110 + y0, X2 = 110 + x0, Y2 = 30 + y0, Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(25 + x0, 25 + y0, 0, 0), Width = 90, Height = 90, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }

    public class GB_TicTacToeRules : BaseTicTacToeRules
    {
        //Diese Regeln sind auf ein Variables Feld angepasst worden - F-Wurm

        bool _Won = false;

        GB_TicTacToeField _Field = new GB_TicTacToeField(4, 4);

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override string Name { get { return "Gruppe B TicTacToeRules"; } }

        public override bool MovesPossible
        {
            get
            {
                if (_Won) return false;

                for (int i = 0; i < _Field.Rows; i++)
                {
                    for (int j = 0; j < _Field.Columns; j++)
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

        public override int CheckIfPLayerWon()
        {
            return CheckIfPlayerWon_B();
        }

        public int CheckIfPlayerWon_A()
        {
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Field[i, 0] == p && _Field[i, 1] == p && _Field[i, 2] == p)
                    {
                        return p;
                    }
                    else if (_Field[0, i] == p && _Field[1, i] == p && _Field[2, i] == p)
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

        public int CheckIfPlayerWon_B()
        {

            for (int p = 1; p < 3; p++)
            {
                for (int r = 0; r < _Field.Rows; r++)
                {
                    for (int c = 0; c < _Field.Columns; c++)
                    {
                        bool rv = !(r < 3 - 1), cv = !(c < 3 - 1);

                        if (rv && _Field[r - 2, c] == p && _Field[r - 1, c] == p && _Field[r, c] == p)
                        {
                            _Won = true;
                            return p;
                        }
                        if (cv && _Field[r, c - 2] == p && _Field[r, c - 1] == p && _Field[r, c] == p)
                        {
                            _Won = true;
                            return p;
                        }
                        if (rv && cv && _Field[r - 2, c - 2] == p && _Field[r - 1, c - 1] == p && _Field[r, c] == p)
                        {
                            _Won = true;
                            return p;
                        }
                        if (rv && cv && _Field[r, c - 2] == p && _Field[r - 1, c - 1] == p && _Field[r - 2, c] == p)
                        {
                            _Won = true;
                            return p;
                        }
                    }
                }
            }

            return -1;
        }

        public override void ClearField()
        {
            _Won = false;

            for (int i = 0; i < _Field.Rows; i++)
            {
                for (int j = 0; j < _Field.Columns; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < _Field.Rows && move.Column >= 0 && move.Column < _Field.Columns)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }

    public class GB_TicTacToeField : BaseTicTacToeField
    {
        //Dieses Feld wurde variabel gemacht - F-Wurm

        int _Rows, _Colums;
        int[,] _Field;

        public GB_TicTacToeField()
        {
            _Rows = 3; _Colums = 3;
            _Field = new int[3, 3]; // { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public GB_TicTacToeField(int r, int c)
        {
            _Rows = r; _Colums = c;
            _Field = new int[r, c];

        }

        public int Columns { get { return _Colums; } }

        public int Rows { get { return _Rows; } }

        public override int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < _Rows && c >= 0 && c < _Colums)
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
                if (r >= 0 && r < _Rows && c >= 0 && c < _Colums)
                {
                    _Field[r, c] = value;
                }
            }
        }
    }

    /*//
    //Braucht vorerst nicht neu zu implementiert werden

    public class GB_TicTacToeMove : ITicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public GB_TicTacToeMove (int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }
    //*/

    public class GB_TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
    {
        //Diesem menschlichen Spieler soll die Tastatureingabe ermöglicht werden
        //Dieser menschliche Spieler kann beliebige Felder besetzen - F-Wurm

        int _PlayerNumber = 0;

        public override string Name { get { return "Gruppe B HumanTicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            GB_TicTacToeHumanPlayer ttthp = new GB_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            return GetMove_B(selection, field);
        }

        public ITicTacToeMove GetMove_A(IMoveSelection selection, ITicTacToeField field)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (selection.XClickPos > 20 + (j * 100) && selection.XClickPos < 120 + (j * 100) &&
                        selection.YClickPos > 20 + (i * 100) && selection.YClickPos < 120 + (i * 100))
                    {
                        return new TicTacToeMove(i, j, _PlayerNumber);
                    }
                }
            }

            return null;
        }

        public ITicTacToeMove GetMove_B(IMoveSelection selection, ITicTacToeField field)
        {
            int x = (selection.XClickPos - 20) / 100, y = (selection.YClickPos - 20) / 100;
            return new TicTacToeMove(y, x, _PlayerNumber);
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    /*//
    //Den Computerspieler wollten wir noch nicht implementieren

    public class GB_TicTacToeComputerPlayer : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "Gruppe B ComputerTicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            GB_TicTacToeComputerPlayer ttthp = new GB_TicTacToeComputerPlayer();
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
    //*/
}
