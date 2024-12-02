using System;

namespace ConsoleAppCricketPlayers
{
    // Custom type for Joining Date
    public class MidDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public MidDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }

    // Base class for Cricket Player
    public class CricketPlayer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public MidDate JoiningDate { get; set; }
        public int MatchesPlayed { get; set; }
        public int TotalRuns { get; set; }

        public CricketPlayer(string id, string name, string position, MidDate joiningDate, int matchesPlayed, int totalRuns)
        {
            Id = id;
            Name = name;
            Position = position;
            JoiningDate = joiningDate;
            MatchesPlayed = matchesPlayed;
            TotalRuns = totalRuns;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Cricket Player:\nID: {Id}\nName: {Name}\nPosition: {Position}\nJoining Date: {JoiningDate}");
        }

        public virtual decimal AverageRuns()
        {
            if (MatchesPlayed == 0) return 0;
            return (decimal)TotalRuns / MatchesPlayed;
        }
    }

    // Batsman class
    public class Batsman : CricketPlayer
    {
        public Batsman(string id, string name, string position, MidDate joiningDate, int matchesPlayed, int totalRuns)
            : base(id, name, position, joiningDate, matchesPlayed, totalRuns)
        {
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Matches Played: {MatchesPlayed}\nTotal Runs: {TotalRuns}");
        }

        public override decimal AverageRuns()
        {
            decimal average = base.AverageRuns();
            Console.WriteLine($"Average Runs (Batsman): {average:F2}");
            return average;
        }
    }

    // Bowler class
    public class Bowler : CricketPlayer
    {
        public int WicketsTaken { get; set; }

        public Bowler(string id, string name, string position, MidDate joiningDate, int matchesPlayed, int totalRuns, int wicketsTaken)
            : base(id, name, position, joiningDate, matchesPlayed, totalRuns)
        {
            WicketsTaken = wicketsTaken;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Matches Played: {MatchesPlayed}\nTotal Runs: {TotalRuns}\nWickets Taken: {WicketsTaken}");
        }

        public override decimal AverageRuns()
        {
            decimal average = base.AverageRuns();
            Console.WriteLine($"Average Runs (Bowler): {average:F2}");
            return average;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CricketPlayer[] players = new CricketPlayer[2];

            players[0] = new Batsman("P-001", "Virat Kohli", "Batsman", new MidDate(15, 8, 2008), 265, 12300);
            players[1] = new Bowler("P-002", "Jasprit Bumrah", "Bowler", new MidDate(23, 1, 2016), 100, 500, 190);

            foreach (CricketPlayer player in players)
            {
                player.ShowInfo();
                player.AverageRuns();
                Console.WriteLine();
            }
        }
    }
}
