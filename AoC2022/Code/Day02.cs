using System.Collections.Generic;
using System.Linq;

namespace AoC2022.Code
{
    public class Day02
    {
        public int Solve(List<string> input)
        {
            return input.Select(Score).Sum();
        }

        public int Solve2(List<string> input)
        {
            return input.Select(Score2).Sum();
        }

        private static int Score(string round)
        {
            var theirs = Convert[round[0]];
            var mine = Convert[round[2]];
            var moveScore = MoveScores[mine];
            var outcome = Outcomes[mine][theirs];
            var outcomeScore = OutcomeScores[outcome];
            return moveScore + outcomeScore;
        }

        private static int Score2(string round)
        {
            var theirs = Convert[round[0]];
            var outcome = ConvertOutcome[round[2]];
            var mine = Outcomes.Single(o => o.Value[theirs] == outcome).Key;
            var moveScore = MoveScores[mine];
            var outcomeScore = OutcomeScores[outcome];
            return moveScore + outcomeScore;
        }

        private static readonly Dictionary<Move, int> MoveScores = new()
        {
            { Move.Rock, 1 },
            { Move.Paper, 2 },
            { Move.Scissors, 3 },
        };

        private static readonly Dictionary<Outcome, int> OutcomeScores = new()
        {
            { Outcome.Win, 6 },
            { Outcome.Draw, 3 },
            { Outcome.Lose, 0 },
        };

        private static readonly Dictionary<Move, Dictionary<Move, Outcome>> Outcomes =
            new()
            {
                {
                    Move.Rock, new Dictionary<Move, Outcome>
                    {
                        { Move.Rock, Outcome.Draw },
                        { Move.Paper, Outcome.Lose },
                        { Move.Scissors, Outcome.Win },
                    }
                },
                {
                    Move.Paper, new Dictionary<Move, Outcome>
                    {
                        { Move.Rock, Outcome.Win },
                        { Move.Paper, Outcome.Draw },
                        { Move.Scissors, Outcome.Lose },
                    }
                },
                {
                    Move.Scissors, new Dictionary<Move, Outcome>
                    {
                        { Move.Rock, Outcome.Lose },
                        { Move.Paper, Outcome.Win },
                        { Move.Scissors, Outcome.Draw },
                    }
                }
            };

        private static readonly Dictionary<char, Move> Convert = new()
        {
            { 'A', Move.Rock }, 
            { 'B', Move.Paper }, 
            { 'C', Move.Scissors }, 
            { 'X', Move.Rock },
            { 'Y', Move.Paper },
            { 'Z', Move.Scissors }
        };

        private static readonly Dictionary<char, Outcome> ConvertOutcome = new()
        {
            { 'X', Outcome.Lose },
            { 'Y', Outcome.Draw }, 
            { 'Z', Outcome.Win }
        };

        private enum Move
        {
            Rock,
            Paper,
            Scissors
        }

        private enum Outcome
        {
            Win,
            Lose,
            Draw
        }
    }
}