using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

//ToDo:
/*
 Am montag den Griesbauer Fragen: 
-Warum gehts nicht?
-
Bisschen einlesen
 */

namespace OOPGames
{
    public class GE_TicTacToePaint : BaseTicTacToePaint
    {
        public override string Name { get { return "GE_TicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 255, 0);
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


<<<<<<< HEAD

=======
    
    public class GE_TicTacToeRules : BaseTicTacToeRules_GE
    {
        GE_TicTacToeField _Field = new GE_TicTacToeField(5);

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

        public override string Name { get { return "GE_TicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                    {
                        return p;
                    }
                    else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                    {
                        return p;
                    }
                }

                if ((_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2]) ||
                    (_Field[0, 2] > 0 && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0]))
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

        public override void AskForGameSize()
        {
            throw new NotImplementedException();

            public static class Prompt
        {
            public static int ShowDialog(string text, string caption)
            {
                Form prompt = new Form();
                prompt.Width = 500;
                prompt.Height = 100;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.ShowDialog();
                return (int)inputBox.Value;
            }

        }

        //int promptValue = Prompt.ShowDialog("Test", "123");

    }
    }

    /*
>>>>>>> 83146a63dd45b199b6ce2dac75c5ecf52d45cb81
    public class GE_TicTacToeRules : BaseTicTacToeRules
    {

        int fieldSize;// = [[3,3], [6,6], [9,9]]; //Besser implementieren: WO soll die Variable hin? GB
        int auswahl = 0;
        TicTacToeField _Field;// = new GE_TicTacToeField();

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible //muss auf die spielfeldgröße angepasst werden
        { 
            get 
            {
                /*
                for (int i = 0; i < fieldSize[auswahl][0]; i++)
                {
                    for (int j = 0; j < fieldSize[auswahl][1]; j++)
                    {
                        if (_Field[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }
                */
                return false; 
            } 
        }

        public override string Name { get { return "GriesbauerTicTacToeRules"; } }

        public override int CheckIfPLayerWon()//anpassen auf spielfeld größe; (vlt anpassen ab wie viel man gewinnt)
        {
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                    {
                        return p;
                    }
                    else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                    {
                        return p;
                    }
                }

                if ((_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2]) ||
                    (_Field[0, 2] > 0 && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0]))
                {
                    return p;
                }
            }

            return -1;
        }

        public override void ClearField()//anpassen
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)//anpassen
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }
<<<<<<< HEAD
=======
    */

    public abstract class BaseTicTacToeRules_GE : ITicTacToeRules_GE
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

        public abstract void AskForGameSize();
    }
>>>>>>> 83146a63dd45b199b6ce2dac75c5ecf52d45cb81

    public class GE_TicTacToeField : BaseTicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };//anpassen

        public override int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)//anpassen
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
                if (r >= 0 && r < 3 && c >= 0 && c < 3)//anpassen
                {
                    _Field[r, c] = value;
                }
            }
        }

        public void AskForGameSize()
        {
            throw new NotImplementedException();
        }

    }

    public class GE_TicTacToeMove : ITicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public GE_TicTacToeMove (int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class GE_TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GE_HumanTicTacToePlayer"; } }

        public override IGamePlayer Clone()
        {
            GE_TicTacToeHumanPlayer ttthp = new GE_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)//support für tasten und hidden modus
        {
            for (int i = 0; i < 3; i++)//anpassen
            {
                for (int j = 0; j < 3; j++)//anpassen
                {
                    if (selection.XClickPos > 20 + (j*100) && selection.XClickPos < 120 + (j*100) &&
                        selection.YClickPos > 20 + (i*100) && selection.YClickPos < 120 + (i*100))
                    {
                        return new GE_TicTacToeMove(i, j, _PlayerNumber);
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

   /* public class TicTacToeComputerPlayer : BaseComputerTicTacToePlayer
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
    }*/
}

/*
 Beispiele DialogWindow:


    using System;
using System.Windows;

namespace WpfTutorialSamples.Dialogs
{
	public partial class InputDialogSample : Window
	{
		public InputDialogSample(string question, string defaultAnswer = "")
		{
			InitializeComponent();
			lblQuestion.Content = question;
			txtAnswer.Text = defaultAnswer;
		}

		private void btnDialogOk_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			txtAnswer.SelectAll();
			txtAnswer.Focus();
		}

		public string Answer
		{
			get { return txtAnswer.Text; }
		}
	}
}

using System.Windows.Forms;
using System.Drawing;

public static DialogResult InputBox(string title, string promptText, ref string value)
{
  Form form = new Form();
  Label label = new Label();
  TextBox textBox = new TextBox();
  Button buttonOk = new Button();
  Button buttonCancel = new Button();

  form.Text = title;
  label.Text = promptText;
  textBox.Text = value;

  buttonOk.Text = "OK";
  buttonCancel.Text = "Cancel";
  buttonOk.DialogResult = DialogResult.OK;
  buttonCancel.DialogResult = DialogResult.Cancel;

  label.SetBounds(9, 20, 372, 13);
  textBox.SetBounds(12, 36, 372, 20);
  buttonOk.SetBounds(228, 72, 75, 23);
  buttonCancel.SetBounds(309, 72, 75, 23);

  label.AutoSize = true;
  textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
  buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
  buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

  form.ClientSize = new Size(396, 107);
  form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
  form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
  form.FormBorderStyle = FormBorderStyle.FixedDialog;
  form.StartPosition = FormStartPosition.CenterScreen;
  form.MinimizeBox = false;
  form.MaximizeBox = false;
  form.AcceptButton = buttonOk;
  form.CancelButton = buttonCancel;

  DialogResult dialogResult = form.ShowDialog();
  value = textBox.Text;
  return dialogResult;
}
*/
