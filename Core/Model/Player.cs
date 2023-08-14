namespace Core.Model
{
    public class Player // Accessing information on the players from database
    {
        public String ID { get; private set; }
        
        // Access data from database
        public static Player? getPlayer(String ID) 
        {
            List<Player> players = getPlayers(new List<string> { ID });
            if ((players != null && players.Count > 0))
            {
                return (Player?)players[0];
            }
            
            return null;
        }

        public static List<Player> getPlayers(List<String> ids)
        {
            return new List<Player>();
        }

        public static void saveData(List<Player> players)
        {
            
        }
    }
}
