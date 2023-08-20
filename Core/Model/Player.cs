using static Azure.Core.HttpHeader;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Player // Accessing information on the players from database
{
    public int PlayerID { get; private set; }
    public String PlayerFirstName { get; private set; }
    public String PlayerLastName { get; private set; }
    public String PlayerDate { get; private set; }
    public int PlayerAge { get; private set; }

    public String Level { get; private set; }

    public String GetPlayerFirstName(int ID)
    {
        using var conn = Core.DBConnection.Connection;
        try
        {
            if (conn != null)
            {
                var rows = new List<string>();
            }
            var command = new SqlCommand("SELECT * FROM Player WHERE ID = @TargetID;", conn); // Finds Player with a specific ID.
            command.Parameters.AddWithValue("@TargetID", ID);
            using SqlDataReader reader = command.ExecuteReader();
            String Names = "";
            if (reader.Read())
            {
                string PlayerInfo = reader.GetString(1);
                Names = PlayerInfo; // Set the return value as the requested Player info.
            }
            return Names;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public String GetPlayerLastName(int ID)
    {
        using var conn = Core.DBConnection.Connection;
        try
        {
            if (conn != null)
            {
                var rows = new List<string>();
            }
            var command = new SqlCommand("SELECT * FROM Player WHERE ID = @TargetID;", conn); // Finds Player with a specific ID.
            command.Parameters.AddWithValue("@TargetID", ID);
            using SqlDataReader reader = command.ExecuteReader();
            String Names = "";
            if (reader.Read())
            {
                string PlayerInfo = reader.GetString(1);
                Names = PlayerInfo; // Set the return value as the requested Player info.
            }
            return Names;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public String GetPlayerAge()
    {
        using var conn = Core.DBConnection.Connection;
        try
        {
            if (conn != null)
            {
                var rows = new List<string>();
            }
            var command = new SqlCommand("SELECT * FROM Player WHERE ID = @TargetID;", conn); // Finds Player with a specific ID.
            command.Parameters.AddWithValue("@TargetID", PlayerID);
            using SqlDataReader reader = command.ExecuteReader();
            String Names = "";
            if (reader.Read())
            {
                string PlayerInfo = reader.GetString(4);
                Names = PlayerInfo; // Set the return value as the requested Player info.
            }
            return Names;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public String GetPlayerDate(int ID) // gets the creation date of the players
    {
        using var conn = Core.DBConnection.Connection;
        try
        {
            if (conn != null)
            {
                var rows = new List<string>();
            }
            var command = new SqlCommand("SELECT * FROM Player WHERE ID = @TargetID;", conn); // Finds Player with a specific ID.
            command.Parameters.AddWithValue("@TargetID", ID);
            using SqlDataReader reader = command.ExecuteReader();
            String Names = "";
            if (reader.Read())
            {
                string PlayerInfo = reader.GetString(3);
                Names = PlayerInfo; // Set the return value as the requested Player creation date.
            }
            return Names;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public Player GetPlayer(int ID) // Assumes the ID hasn't been inserted
    {
        try
        {
            Player retPlayer = new Player();
            {
                this.PlayerID = ID;
                this.PlayerFirstName = GetPlayerFirstName(ID);
                this.PlayerLastName = GetPlayerLastName(ID);
                this.PlayerDate = GetPlayerDate(ID);
            }
            return retPlayer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public Boolean AddPlayer()  // Adds a new Player into the db.
    {
        if (this.PlayerFirstName == null || this.PlayerLastName == null)
        {
            return false;
        }
        try
        {
            using var conn = Core.DBConnection.Connection;
            if (conn != null)
            {
                var rows = new List<string>();
                var command = new SqlCommand("INSERT Player (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)", conn); //inserts a new row into the table
                command.Parameters["@FirstName"].Value = this.PlayerFirstName;
                command.Parameters["@LastName"].Value = this.PlayerLastName;
                command.Parameters["@Age"].Value = this.PlayerAge;
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0) // checks if there was a new row that was inserted.
                {
                    Console.WriteLine($"Row inserted successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to insert row.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;
    }

    public int GetPlayerID() 
    {
        return PlayerID;
    }

    public String[] findPlayers(String[] IDs) // method that finds large number of players using ids provided
    {
        String[] PlayerList = new String[IDs.Length];
        for(int i = 0; i < IDs.Length; i++) 
        {
            
        }
        return null;
    }
    public void AddID(int ID) //add the id to the Player Object in String form 
    {
        this.PlayerID = ID;
    }
    public void AddPlayerInfo(string FirstName, string LastName, int Age) //add the Player info to the Player Object in String form 
    {
        this.PlayerFirstName = FirstName;
        this.PlayerLastName = LastName;
        this.PlayerAge = Age;
    }
}

