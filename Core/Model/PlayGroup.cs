using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Core.Model
{
    public class PlayGroup
    {
        public String Name { get; private set; }

        public List<Player> Players { get; private set; }
        public List<Game> Games { get; private set; }

        public int Round { get; private set; }

        public static PlayGroup CreateGroup(String name, List<Player> players) // Create a group of players that will be played in ladder
        {
            PlayGroup group = new PlayGroup();
            group.Name = name;
            group.Players = new List<Player>();
            group.Players.InsertRange(0, players);

            group.GenerateGames();
            return group;
        }

        public void AddPlayer(Player player) //adds a player into the player group
        {
            this.Players.Add(player);
        }

        public void RemovePlayer(Player player) // removes a player
        {
            for (int i = 0; i < this.Players.Count-1; i++)
            {
                if (Players[i] == player) 
                {
                    Players.RemoveAt(i);
                }
            }
        }

        public void AddGame(Game game) //adds a game into the games group
        {
            this.Games.Add(game);
        }

        public void RemoveGame(Game game) // remove a game
        {
            for (int i = 0; i < this.Games.Count-1; i++)
            {
                if (Games[i] == game)
                {
                    Players.RemoveAt(i);
                }
            }
        }
        public void Finalize() // Activates GenerateGames, which is a private method
        {
            GenerateGamesList();
        }

        /*private void GenerateGames()
        {
            this.Round = this.Players.Count - 1;
            for (int i = 0; i < Round; i++) 
            {
                
            }
            // Generate Games
        }*/
        public List<Game> GenerateGamesList(List<Player> PlayerList)
        {

            List<Player> firstPart = PlayerList.GetRange(0, PlayerList.Count / 2);
            List<Player> secondPart = PlayerList.GetRange(PlayerList.Count / 2+1, PlayerList.Count-1);
            List<Game> GamesList = new List<Game>();
            Boolean isNull = false;
            if (firstPart.Count != secondPart.Count) 
            {
                secondPart.Add(null);
                isNull = true;
            }
            GenerateDoublesGame(firstPart, false);
            GenerateDoublesGame(secondPart, isNull);
            return null;
        }

        private List<Player> GenerateDoublesGame(List<Player> part, Boolean isNull) 
        {
            List <Player> ret = new List<Player>();
            for (int i = 0; i < part.Count-1; i++)
            {
                Game ToAdd = new Game();
                if (isNull || part.Count % 2 != 0) 
                {
                    for (int k = i; k < part.Count; k++)
                    {
                        if (part[k] == null)
                        {
                            isNull = true;
                        }
                        ToAdd.AddPlayer(part[k]);
                    }
                    if (!isNull)
                    {
                        ToAdd.AddNewGame("Double");
                    }
                }
            }

            return null;
        }

        private List<Game> RecursePlayerLists(List<Player> PlayerList) 
        {
            List<Player> firstPart = PlayerList.GetRange(0, PlayerList.Count / 2);
            List<Player> secondPart = PlayerList.GetRange(PlayerList.Count / 2 + 1, PlayerList.Count - 1);
            if (firstPart.Count != secondPart.Count)
            {
                secondPart.Add(null);
            }
            if (PlayerList.Count > 4) 
            {
                //firstPart = RecursePlayerLists(firstPart);
                //secondPart = RecursePlayerLists(secondPart);
            }
            List<Player> retPlayerList = new List<Player>();
            for (int i = 0; i < firstPart.Count; i++)
            {
                for (int j = i+1; j < firstPart.Count; j++)
                {
                    if (firstPart[j] == null || firstPart[i] == null) 
                    {

                    }
                }
            }
            return null;
        }
    }
}

