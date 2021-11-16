using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class OOPGamesManager
    {
        private static OOPGamesManager _OOPGames;
        IList<IPaintGame> _Painters;
        IList<IGamePlayer> _Players;
        IList<IGameRules> _Rules;

        public OOPGamesManager ()
        {
            _Painters = new List<IPaintGame>();
            _Players = new List<IGamePlayer>();
            _Rules = new List<IGameRules>();
        }

        public void RegisterPainter (IPaintGame painter)
        {
            _Painters.Add(painter);
        }

        public void UnregisterPainter(IPaintGame painter)
        {
            _Painters.Remove(painter);
        }

        public void RegisterPlayer(IGamePlayer player)
        {
            _Players.Add(player);
        }

        public void UnregisterPlayer(IGamePlayer player)
        {
            _Players.Remove(player);
        }

        public void RegisterRules(IGameRules rules)
        {
            _Rules.Add(rules);
        }

        public void unregisterRules(IGameRules rules)
        {
            _Rules.Remove(rules);
        }

        public IEnumerable<IPaintGame> Painters { get { return _Painters; } }

        public IEnumerable<IGamePlayer> Players {  get { return _Players; } }

        public IEnumerable<IGameRules> Rules { get { return _Rules; } }

        public static OOPGamesManager Singleton
        {
            get
            {
                if (_OOPGames == null)
                {
                    _OOPGames = new OOPGamesManager();
                }
                return _OOPGames;
            }
        }

    }

    public class MoveSelection : IMoveSelection
    {
        int _ClickX;
        int _ClickY;

        public MoveSelection (int clickX, int clickY)
        {
            _ClickX = clickX;
            _ClickY = clickY;
        }

        public int XClickPos { get { return _ClickX; } }

        public int YClickPos { get { return _ClickY; } }
    }
}
