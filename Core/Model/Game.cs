namespace Core.Model;
using static Azure.Core.HttpHeader;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Game // Access information on Games from database
{
    public String GameID { get; private set; }
    public String GameInfo { get; private set; }
    public String GameDate { get; private set; }
    public String GameType { get; private set; }
    public int PlayerOne { get; private set; }
    public int PlayerTwo { get; private set; }
    public int PlayerThree { get; private set; }
    public int PlayerFour { get; private set; }
    public String GetGameInfo()
    {
        using var conn = Core.DBConnection.Connection;
        try
        {
            if (conn != null)
            {
                var rows = new List<string>();
            }
            var command = new SqlCommand("SELECT * FROM Game WHERE ID = @TargetID;", conn); // Finds Game with a specific ID.
            command.Parameters.AddWithValue("@TargetID", GameID);
            using SqlDataReader reader = command.ExecuteReader();
            String Names = "";
            if (reader.Read())
            {
                string GameInfo = reader.GetString(1);
                Names = GameInfo; // Set the return value as the requested Game info.
            }
            return Names;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public String GetGameDate()
    {
        using var conn = Core.DBConnection.Connection;
        try
        {
            if (conn != null)
            {
                var rows = new List<string>();
            }
            var command = new SqlCommand("SELECT * FROM Game WHERE ID = @TargetID;", conn); // Finds Game with a specific ID.
            command.Parameters.AddWithValue("@TargetID", GameID);
            using SqlDataReader reader = command.ExecuteReader();
            String Names = "";
            if (reader.Read())
            {
                string GameInfo = reader.GetString(2);
                Names = GameInfo; // Set the return value as the requested Game creation date.
            }
            return Names;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public Game GetGame() // Assumes the ID as already been inserted
    {
        try
        {
            this.GameInfo = GetGameInfo();
            this.GameDate = GetGameDate();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }

    public Game GetGame(String ID) // Assumes the ID hasn't been inserted
    {
        try
        {
            this.GameID = ID;
            this.GameInfo = GetGameInfo();
            this.GameDate = GetGameDate();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;
    }
    public Boolean AddNewGame(String Type)  // Adds a new Game into the db, assuming all of the infos have been added already.
    {
        if (this.GameInfo == null && this.GameType == null)
        {
            return false;
        }
        try
        {
            using var conn = Core.DBConnection.Connection;
            if (conn != null)
            {
                var rows = new List<string>();
                var command = new SqlCommand("INSERT Game (Type, PlayerOne, PlayerTwo, PlayerThree, PlayerFour) VALUES (@Type, @PlayerOne, @PlayerTwo, @PlayerThree, @PlayerFour)", conn); //inserts a new row into the table
                command.Parameters["@GameType"].Value = Type;
                command.Parameters["@PlayerOne"].Value = this.PlayerOne;
                command.Parameters["@PlayerTwo"].Value = this.PlayerTwo;
                command.Parameters["@PlayerThree"].Value = this.PlayerThree;
                command.Parameters["@PlayerFour"].Value = this.PlayerFour;
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
    public void AddPlayerOne(Player player)
    {
        if (player != null) 
        {
            this.PlayerOne = player.GetPlayerID();
        }
    }
    public void AddPlayerTwo(Player player)
    {
        if (player != null)
        {
            this.PlayerTwo = player.GetPlayerID();
        }
    }
    public void AddPlayerThree(Player player)
    {
        if (player != null)
        {
            this.PlayerThree = player.GetPlayerID();
        }
    }
    public void AddPlayerFour(Player player)
    {
        if (player != null)
        {
            this.PlayerFour = player.GetPlayerID();
        }
    }

    public void AddID(string ID) //add the id to the Game Object in String form 
    {
        if (ID != null) 
        {
            this.GameID = ID;
        }
    }
    public void AddGameInfo(string Info) //add the Game info to the Game Object in String form 
    {
        if (Info != null) 
        {
            this.GameInfo = Info;
        }
    }
    public void AddGameType(string Type) 
    {
        if (Type != null) 
        {
            this.GameType = Type;
        }
    }
    
    public int getPlayerOneID() 
    {
        return PlayerOne;
    }
}

