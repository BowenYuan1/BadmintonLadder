using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Core.Pages

{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public string Description { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;

            this.Description = "this is a test";
            if (this.Request != null && this.Request.Query.ContainsKey("btn"))
            {
                this.Description = "clicked";
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {           
        }
    }
}
