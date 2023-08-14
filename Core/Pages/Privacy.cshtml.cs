using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Microsoft.Data.SqlClient;

using System.Globalization;

using System.Configuration;
using Azure;
using System.Collections.Generic;
using System;
using Core.Model;

namespace Core.Pages

{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public string Description { get; set; }

        public string Input { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet() 
        {
        }
        public void OnPost()
        {
            //string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            //ViewData["TimeStamp"] = dateTime;
            //this.Description = "this is a test";
            if (this.Request != null && this.Request.Form.ContainsKey("apply"))
            {
                if (this.Request.Form.ContainsKey("NameInput"))
                {
                    String NameInputs = this.Request.Form["NameInput"];
                    //String parse = this.Request.Form["clickval"];
                    //int clickval = int.Parse(parse);
                    if (NameInputs == null || NameInputs == "" ) // checks if the Name Inputs were valid if not return a message
                    {
                        this.Description = "Input not accepted";
                        return;
                    }
                    String[] NameArr = NameInputs.Split(", ");

                    using var conn = Core.DBConnection.Connection;
                    
                    try
                    {
                        if (conn != null)
                        {
                            var rows = new List<string>();
                            var command = new SqlCommand("INSERT Persons (FirstName) VALUES (@FirstName)", conn); //inserts a new row into the table
                            for (int k = 0; k < NameArr.Length; k++) 
                            {
                                //command.Parameters["@FirstName"].Value = NameArr[k];
                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected > 0) // checks if there was a new row that was inserted.
                                {
                                    Console.WriteLine($"Row {k + 1} inserted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"Failed to insert row {k + 1}.");
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Ladder same = new Ladder();
                    try // gets the first 3 names from the table and gets the name with the ID:SBC0003
                    {
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Random random = new Random(); // splits the input into individual names and randomize the players for teaming.
                    for (int i = NameArr.Length - 1; i > 0; i--) 
                    {
                        int j = random.Next(i+1);
                        string temp = NameArr[i];
                        NameArr[i] = NameArr[j];
                        NameArr[j] = temp;
                    }
                    String SortedNames = "Ladder Pairing: ";
                    for (int i = 0; i < NameArr.Length - 1; i++)  // matches individuals into pairs for a match.
                    {
                        SortedNames += NameArr[i] + " + " + NameArr[i+1];
                        
                        i++;
                        if (i < NameArr.Length - 2) 
                        {
                            SortedNames += ", ";
                        }
                    }
                    // returns the pairs back onto the webpage.
                    
                    try
                    {
                        if (conn != null)
                        {
                            var rows = new List<string>();

                            var command = new SqlCommand("SELECT * FROM Persons", conn); // reads the last name from the list.
                            using SqlDataReader reader = command.ExecuteReader();
                            String Names = "";
                            if (reader.HasRows)
                            {
                                int s = 0;
                                while (reader.Read() && s < 3)
                                {
                                    //rows.Add($"{reader.GetInt32(0)}, {reader.GetString(1)}, {reader.GetString(2)}");
                                    string firstNames = reader.GetString(1);
                                    string lastNames = reader.GetString(2);
                                    
                                    Names += firstNames + " " + lastNames + "\n"; // prints out the name on the page.
                                    s++;
                                }
                            }
                            this.Description = Names;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    try
                    {
                        if (conn != null)
                        {
                            var rows = new List<string>();

                            var command = new SqlCommand("SELECT * FROM Persons WHERE ID = @TargetID;", conn); // Finds the name of the person who has a specific ID.
                            command.Parameters.AddWithValue("@TargetID", "SBC0003");
                            using SqlDataReader reader = command.ExecuteReader();
                            String Names = "";
                            if (reader.Read())
                            {
                                //rows.Add($"{reader.GetInt32(0)}, {reader.GetString(1)}, {reader.GetString(2)}");
                                string firstNames = reader.GetString(1);
                                string lastNames = reader.GetString(2);

                                Names += firstNames + " " + lastNames + "\n"; // prints out the name on the page.
                            }
                            
                            this.Description = Names;
                            Ladder some = new Ladder();
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
                //This is a comment
        }
    }
}
