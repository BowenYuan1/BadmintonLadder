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
                    
                    Ladder same = new Ladder();
                    
                    // Recieves player names and input them into the players table.
                    




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

                    
                }
            }
                //This is a comment
        }
    }
}
