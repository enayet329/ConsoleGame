
using test.IGameRepo;

namespace test.Services
{
    public class GameRules : IGameRules
    {
        private readonly List<string> moves;

        public GameRules(List<string> moves)
        {
            this.moves = moves;
        }

        public string GetWinner(string userMove, string computerMove)
        {
            int userIndex = moves.IndexOf(userMove);
            int computerIndex = moves.IndexOf(computerMove);

            if (userIndex == computerIndex)
            {
                return "Draw";
            }
            else if ((userIndex - computerIndex + moves.Count) % moves.Count == 1)
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
