using AutopesulaApp.Enums;

namespace AutopesulaApp.Models
{
    public class WashOrder
    {
        public string ClientName { get; set; }

        public WashProgram Program { get; set; }

        public decimal Price { get; set; }

        public int Duration { get; set; }
    }
}