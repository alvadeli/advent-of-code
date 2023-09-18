namespace day11
{
    public static class KeepAway
    {
        public static long Play(string input, int rounds,bool decreaseWorryLevel)
        {
            string gameInput = File.ReadAllText(input);

            string[] playerData = gameInput.Split("\r\n\r\n");

            var players = new List<Player>();

            foreach (var player in playerData) 
            {
                players.Add(PlayerParser.CreateFromText(player));
            }

            long commonDivisor = players.Aggregate(1, (acc, x) => acc * x.Divisor);


            for (int i = 0; i < rounds; i++)
            {
                foreach (var player in players)
                {
                    player.ThrowItems(players, decreaseWorryLevel, commonDivisor);
                }
            }

            players = players.OrderByDescending(p => p.ItemInspections).ToList();

            return players[0].ItemInspections * players[1].ItemInspections;
        }
    }
}
