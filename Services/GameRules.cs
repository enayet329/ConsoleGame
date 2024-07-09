
using test.IGameRepo;

namespace test.Services
{
    public class GameRules : IGameRules
    {
       private readonly List<string> _moves = new List<string>();
        public GameRules(List<string> moves)
        {
            this._moves = moves;
        }

        public string GetWinner(string userMove, string computerMove)
        {
            int userIndex = _moves.IndexOf(userMove);
            int computerIndex = _moves.IndexOf(computerMove);

            if(userIndex == computerIndex)
            {
                return "Drow";
            }
            else if ((userIndex - computerIndex + _moves.Count) % _moves.Count < _moves.Count)
            {
                return "User wins";
            }
            else
            {
                return "Computer wins";
            }
        }
    }
}