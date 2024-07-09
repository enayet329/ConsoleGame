

using Spectre.Console;
using test.IGameRepo;

namespace test.Services
{
    internal class HelpTable : IHelpTable
    {
        private readonly List<string> moves = new List<string>();

        public HelpTable(List<string> moves)
        {
            this.moves = moves;
        }
        public void DisplayHelpTable()
        {
            var table = new Table();

            // Add columns
            table.AddColumn("v PC\\User >");
            foreach (var move in moves)
            {
                table.AddColumn(move);
            }

            // Add rows
            for (int i = 0; i < moves.Count; i++)
            {
                var row = new List<string> { moves[i] };
                for (int j = 0; j < moves.Count; j++)
                {
                    if (i == j)
                    {
                        row.Add("Draw");
                    }
                    else if ((i - j + moves.Count) % moves.Count <= moves.Count / 2 && (i - j + moves.Count) % moves.Count != 0)
                    {
                        row.Add("Win");
                    }
                    else
                    {
                        row.Add("Lose");
                    }
                }
                table.AddRow(row.ToArray());
            }

            // Render the table to the console
            AnsiConsole.Render(table);
        }
    }
}