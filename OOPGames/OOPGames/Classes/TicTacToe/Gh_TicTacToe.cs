/*
Gruppe H

AUfteilung:
    -Human Player: Fabian & Julian
    -Rules: Michael
    -Computer Player: ___
    -Painter: Dominic
    ...
*/

/**
 * Change-Log:
 *  Rules: - Das Überschreiben anderer Züge ist nicht mehr möglich
 *         - Mittels DoTicTacToeMove(x,y) kann auch vor Ausführung eines Zuges geprüft
 *           werden, ob dieser gültig ist.
 *         - Rules für variable Spielfeldgröße und variable Spielerzahl vorbereitet
 */

/**
 * To-Dos:
 * Human-Player: Verwendung von DoTicTacToeMove(x,y) VOR der Erstellung eines moves.
 */

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
    class Gh_TicTacToe
    {
        //printf("Hello WOrld\n");
    }

    public class Gh_TicTacToePainter : BaseTicTacToePaint
    {
        public override String Name {  get { "TicTacToePaint Gruppe H";  } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();                                    
            Color bgColor = ConsoleColor.FromRgb(255, 255, 255);        //Backgroundcolor Weiß
            canvas.Background = new SolidColorBrush(bgColor);           
            Color lineColor = color.FromRgb(0, 0, 0);                 //Linienfarbe schwarz Spielfeld
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = bgColor.FromRgb(0, 255, 0);                  //LInienfarbe Grün Kreuz
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 0, 0);                    //Linienfarbe Rot Ellipse
            Brush OStroke = new SolidColorBrush(OColor);

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 }; //Linien für das Spielfeld
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 0; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 120 + (j * 100), Y2 = 120 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 }; //Kreuz
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100), Y1 = 120 + (i * 100), X2 = 120 + (j * 100), Y2 = 20 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 }; //Ellipse
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }

    public class Gh_TicTacToeField : BaseTicTacToeField
    {

        static int _Rows = 3;
        static int _Cols = 3;

        int[,] _Field = new int[_Rows, _Cols];

        public override int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < _Rows && c >= 0 && c < _Cols)
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
                if (r >= 0 && r < _Rows && c >= 0 && c <  _Cols)
                {
                    _Field[r, c] = value;
                }
            }
        }


    }





        public class Gh_TicTacToeRules : BaseTicTacToeRules
    {
        TicTacToeField _Field = new TicTacToeField();

        public override ITicTacToeField TicTacToeField { get { return _Field; } }
        private int spieleranzahl=2;
        private int breite=3;
        private int hoehe=3;
        private int gewinngrenze=3;
        
        /**
         * Überprüft, ob min. 1 Feld gleich 0 ist.
         * [Zeile,Spalte]
         */
        public override bool MovesPossible
        {
            get
            {
                for (int z = 0; z < hoehe; z++)
                {
                    for (int s = 0; s < breite; s++)
                    {
                        if (_Field[z, s] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public override string Name { get { return "Gh_TicTacToeRules"; } }

        /**
         * Überprüft, ob Spieler1 oder Spieler2 in einer der 3 Spalten, der 3 Zeilen,
         * oder schräg gewonnen hat.
         * Gibt ggf. die Nummer des jeweiligen Spielers zurück, ansonsten -1.
         */
        public override int CheckIfPLayerWon()
        {
            for (int p = 1; p < spieleranzahl+1; p++) //Durchgehen aller Spieler (ab 1!)
            {       
                for (int z = 0; z < hoehe; z++) //Druchgehen aller Zeilen
                {
                    int count=0;                 //Zählvariable fuer gwinnende Symbole
                    for(int s=0; s<gewinngrenze; s++) //Durchgehen aller Spalten
                    {
                        if(_Field[z,s]==p)  //Feld ist von gewähltem Spieler belegt
                        {
                            count++;
                        } else
                        {
                            count=0;        //Feld ist leer oder von einem anderen Spieler belegt
                        }
                        if(count==gewinngrenze) //Genug Symbole des Spielers in dieser Zeile
                        {
                            return p;      //Ausgabe Gewinner und Abbruch der Methode
                        }
                    }
                }
                for (int s=0; s<breite; s++) {      //Durchgehen aller Spalten 
                    int count=0;                    //Zählvariable fuer gwinnende Symbole
                    for(int z=0; z<gewinngrenze; z++) //Durchgehen aller Zeilen
                    {
                        if(_Field[z,s]==p)  //Feld ist von gewähltem Spieler belegt
                        {
                            count++;
                        } else
                        {
                            count=0;    //Feld ist leer oder von einem anderen Spieler belegt.
                        }
                        if(count==gewinngrenze) //Genug Symbole des Spielers in dieser Spalte
                        {
                            return p;  //Ausgabe Gewinner und Abbruch der Methode
                        }
                    }
                }
                for(int a=0; a<breite; a++)   //Wert der für die Spalte zur Zeile addiert/subtrahiert werden muss.
                {
                    int count=0;              //Zählvariable fuer gwinnende Symbole
                    for(int z=0; z<hoehe; z++) //Durchgehen aller Zeilen (von denen die Diagonale nach RECHTS UNTEN ausgeht)
                    {
                        if(_Field[z,z-a]==p)  //Feld ist von gewähltem Spieler belegt
                        {
                            count++;
                        } else
                        {
                            count=0;    //Feld ist leer oder von einem anderen Spieler belegt.
                        }
                        if(count==gewinngrenze) //Genug Symbole des Spielers in dieser Diagonale
                        {
                            return p;  //Ausgabe Gewinner und Abbruch der Methode
                        }
                    }
                }

                for(int a=breite-1; a>=0; a--)   //Wert der für die Spalte zur Zeile addiert/subtrahiert werden muss.
                {
                    int count=0;                //Zählvariable fuer gwinnende Symbole
                    for(int z=hoehe-1; z>=0; z--) //Durchgehen aller Zeilen (von denen die Diagonale nach RECHTS OBEN ausgeht)
                    {
                        if(_Field[z,-z+a]==p)  //Feld ist von gewähltem Spieler belegt
                        {
                            count++;
                        } else
                        {
                            count=0;    //Feld ist leer oder von einem anderen Spieler belegt.
                        }
                        if(count==gewinngrenze) //Genug Symbole des Spielers in dieser Diagonale
                        {
                            return p;  //Ausgabe Gewinner und Abbruch der Methode
                        }
                    }
                }

                for(int a=breite-1; a>=0; a--)   //Wert der für die Spalte zur Zeile addiert/subtrahiert werden muss.
                {
                    int count=0;                //Zählvariable fuer gwinnende Symbole
                    for(int z=0; z>hoehe; z++) //Durchgehen aller Zeilen (von denen die Diagonale nach LINKS UNTEN ausgeht)
                    {
                        if(_Field[z,-z-a]==p)  //Feld ist von gewähltem Spieler belegt
                        {
                            count++;
                        } else
                        {
                            count=0;    //Feld ist leer oder von einem anderen Spieler belegt.
                        }
                        if(count==gewinngrenze) //Genug Symbole des Spielers in dieser Diagonale
                        {
                           return p;  //Ausgabe Gewinner und Abbruch der Methode
                        }
                    }
                }

                for(int a=0; a<breite; a++)   //Wert der für die Spalte zur Zeile addiert/subtrahiert werden muss.
                {
                    int count=0;              //Zählvariable fuer gwinnende Symbole
                    for(int z=hoehe-1; z>=0; z--) //Durchgehen aller Zeilen (von denen die Diagonale nach LINKS OBEN ausgeht)
                    {
                        if(_Field[z,z-a]==p)  //Feld ist von gewähltem Spieler belegt
                        {
                            count++;
                        } else
                        {
                            count=0;    //Feld ist leer oder von einem anderen Spieler belegt.
                        }
                        if(count==gewinngrenze) //Genug Symbole des Spielers in dieser Diagonale
                        {
                            return p;  //Ausgabe Gewinner und Abbruch der Methode
                        }
                    }
                }
            }
            return -1; //Kein Gewinner
        }

        /**
         * Setzt alle Felder auf 0.
         */
        public override void ClearField()
        {
            for (int x = 0; x < hoehe; x++)
            {
                for (int y = 0; y < breite; y++)
                {
                    _Field[x, y] = 0;
                }
            }
        }

        /**
         * Prüft, ob der gewünschte Zug möglich ist und sich im Spielfeld befinden würde.
         * Schreibt die Spielernummer in das jeweilige Feld wenn gültig.
         */
        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < hoehe && move.Column >= 0 && move.Column < breite && givenMovePossible(move))
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }

        /**
         * Prüft, ob das gegebene Feld frei ist.
         */
        public bool givenMovePossible(ITicTacToeMove move)
        {
            if (_Field[move.Row, move.Column] == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }


        /**
         * Prüft ANHAND DER KOORDINATEN, ob der gewünschte Zug möglich ist und sich im Spielfeld befinden würde.
         * Schreibt die Spielernummer in das jeweilige Feld wenn gültig.
         */
        public bool DoTicTacToeMove(int x, int y)
        {
            if (x >= 0 && x < hoehe && y >= 0 && y < breite && givenMovePossible(x,y))
            {
                return true;
            } else {
            return false;
            }
        }

        /**
         * Prüft ANHAND DER KOORDINATEN, ob das gegebene Feld frei ist.
         */
        public bool givenMovePossible(int x, int y)
        {
            if (_Field[x, y] == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
