using static Azure.Core.HttpHeader;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Core.Model
{
    public class Ladder // Accessing information on the ladders
    {
        public String LadderID { get; set; }
        public String LadderInfo { get; set; }
        public String GetLadderInfo()
        {
            using var conn = Core.DBConnection.Connection;
            try
            {
                if (conn != null)
                {
                    var rows = new List<string>();
                }
                var command = new SqlCommand("SELECT * FROM Ladder WHERE ID = @TargetID;", conn); // Finds ladder with a specific ID.
                command.Parameters.AddWithValue("@TargetID", LadderID);
                using SqlDataReader reader = command.ExecuteReader();
                String Names = "";
                if (reader.Read())
                {
                    string LadderInfo = reader.GetString(2);
                    Names = LadderInfo; // Set the return value as the requested ladder info.
                }
                return Names;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public String GetLadderDate()
        {
            using var conn = Core.DBConnection.Connection;
            try
            {
                if (conn != null)
                {
                    var rows = new List<string>();
                }
                var command = new SqlCommand("SELECT * FROM Ladder WHERE ID = @TargetID;", conn); // Finds ladder with a specific ID.
                command.Parameters.AddWithValue("@TargetID", LadderID);
                using SqlDataReader reader = command.ExecuteReader();
                String Names = "";
                if (reader.Read())
                {
                    string LadderInfo = reader.GetString(1);
                    Names = LadderInfo; // Set the return value as the requested ladder creation date.
                }
                return Names;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public Ladder GetLadder() 
        {

            return null;
        }
        public Boolean AddLadder()  // Adds a new ladder into the db.
        {
            if (LadderInfo == null) 
            {
                return false;
            }

            try
            {
                using var conn = Core.DBConnection.Connection;
                if (conn != null)
                {
                    var rows = new List<string>();
                    var command = new SqlCommand("INSERT Ladder (LadderInfo) VALUES (@LadderInfo)", conn); //inserts a new row into the table
                    command.Parameters["@LadderInfo"].Value = this.LadderInfo;
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0) // checks if there was a new row that was inserted.
                    {
                        Console.WriteLine($"Row inserted successfully.");
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
        public void AddID(string ID) //add the id to the Ladder Object in String form 
        {
            this.LadderID = ID;
        }
        public void AddLadderInfo(string Info) //add the ladder info to the Ladder Object in String form 
        {
            this.LadderInfo = Info;
        }
    }
}
