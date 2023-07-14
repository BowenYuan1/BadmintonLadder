using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

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
                    if (NameInputs == null || NameInputs == "" )
                    {
                        this.Description = "Input not accepted";
                        return;
                    }
                    String[] NameArr = NameInputs.Split(", ");
                    Random random = new Random();
                    for (int i = NameArr.Length - 1; i > 0; i--) 
                    {
                        int j = random.Next(i+1);
                        string temp = NameArr[i];
                        NameArr[i] = NameArr[j];
                        NameArr[j] = temp;
                    }
                    String SortedNames = "Ladder Pairing: ";
                    for (int i = 0; i < NameArr.Length - 1; i++) 
                    {
                        SortedNames += NameArr[i] + " + " + NameArr[i+1];
                        
                        i++;
                        if (i < NameArr.Length - 2) 
                        {
                            SortedNames += ", ";
                        }
                    }
                    this.Description = SortedNames;
                }
            }
                //This is a comment
        }
    }
}
