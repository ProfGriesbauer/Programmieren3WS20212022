using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OOPGames
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGamePlayer _CurrentPlayer = null;
        IPaintGame _CurrentPainter = null;
        IGameRules _CurrentRules = null;
        IGamePlayer _CurrentPlayer1 = null;
        IGamePlayer _CurrentPlayer2 = null;

        DispatcherTimer _PaintTimer = null;

        public MainWindow()
        {
            //Beipiele
            Haus meinHaus = new Haus();
            Verbraucher verb = new Verbraucher(1000);
            verb.Spannung = 100;

            string stGesetz = Verbraucher.OhmschesGesetz();

            //REGISTER YOUR CLASSES HERE
            //Painters
            OOPGamesManager.Singleton.RegisterPainter(new TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new GE_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new BiemelPainter());
            OOPGamesManager.Singleton.RegisterPainter(new BiemelPainterAlt1());
            //Rules
            OOPGamesManager.Singleton.RegisterRules(new TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new GE_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterPainter(new GB_TicTacToePaint());
            //Rules
            OOPGamesManager.Singleton.RegisterRules(new TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new GB_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new BiemelRules());
            //Players
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new GB_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new GE_TicTacToeHumanPlayer());
            //OOPGamesManager.Singleton.RegisterPlayer(new GB_TicTacToeComputerPlayer());

            InitializeComponent();
            PaintList.ItemsSource = OOPGamesManager.Singleton.Painters;
            Player1List.ItemsSource = OOPGamesManager.Singleton.Players;
            Player2List.ItemsSource = OOPGamesManager.Singleton.Players;
            RulesList.ItemsSource = OOPGamesManager.Singleton.Rules;

            _PaintTimer = new DispatcherTimer();
            _PaintTimer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            _PaintTimer.Tick += _PaintTimer_Tick;
            _PaintTimer.Start();
        }

        private void _PaintTimer_Tick(object sender, EventArgs e)
        {
            if (_CurrentPainter != null &&
                   _CurrentRules != null && _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
            {
                _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            _CurrentPlayer1 = null;
            if (Player1List.SelectedItem is IGamePlayer)
            {
                _CurrentPlayer1 = ((IGamePlayer)Player1List.SelectedItem).Clone();
                _CurrentPlayer1.SetPlayerNumber(1);
            }
            _CurrentPlayer2 = null;
            if (Player2List.SelectedItem is IGamePlayer)
            {
                _CurrentPlayer2 = ((IGamePlayer)Player2List.SelectedItem).Clone();
                _CurrentPlayer2.SetPlayerNumber(2);
            }

            _CurrentPlayer = _CurrentPlayer1;
            _CurrentPainter = PaintList.SelectedItem as IPaintGame;
            _CurrentRules = RulesList.SelectedItem as IGameRules;

            if (_CurrentRules is ITicTacToeRules_GE)
            {
                ((ITicTacToeRules_GE)_CurrentRules).AskForGameSize();
            }

            if (_CurrentPainter != null && 
                _CurrentRules != null && _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
            {
                Status.Text = "Game startet!";
                _CurrentRules.ClearField();
                DoComputerMoves();
            }
        }

        private void DoComputerMoves()
        {
            int winner = _CurrentRules.CheckIfPLayerWon();
            if (winner > 0)
            {
                Status.Text = "Player" + winner + " Won!";
            }
            else
            {
                while (_CurrentRules.MovesPossible &&
                       winner <= 0 &&
                       _CurrentPlayer is IComputerGamePlayer)
                {
                    IPlayMove pm = ((IComputerGamePlayer)_CurrentPlayer).GetMove(_CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                    }

                    winner = _CurrentRules.CheckIfPLayerWon();
                    if (winner > 0)
                    {
                        Status.Text = "Player" + winner + " Won!";
                    }

                    _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                    //Tenärer Operator("if-else-Block verkürzt") (if CP == CP1){CP=CP2}else{CP=CP1}
                }
            }
        }

        private void PaintCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int winner = _CurrentRules.CheckIfPLayerWon();
            if (winner > 0)
            {
                Status.Text = "Player" + winner + " Won!";
            }
            else
            {
                if (_CurrentRules.MovesPossible &&
                    _CurrentPlayer is IHumanGamePlayer)
                {
                    IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new MoveSelection((int)e.GetPosition(PaintCanvas).X, (int)e.GetPosition(PaintCanvas).Y), _CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                    }

                    _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;

                    DoComputerMoves();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _PaintTimer.Stop();
            _PaintTimer = null;
        }
    }
}
