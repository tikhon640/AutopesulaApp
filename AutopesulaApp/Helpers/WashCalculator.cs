using AutopesulaApp.Enums;

namespace AutopesulaApp.Helpers
{
    public static class WashCalculator
    {
        public static decimal CalculatePrice(WashProgram program)
        {
            switch (program)
            {
                case WashProgram.Tavapesu:
                    return 10;

                case WashProgram.Standardpesu:
                    return 15;

                case WashProgram.Premiumpesu:
                    return 25;

                default:
                    return 0;
            }
        }

        public static int CalculateDuration(WashProgram program)
        {
            switch (program)
            {
                case WashProgram.Tavapesu:
                    return 15;

                case WashProgram.Standardpesu:
                    return 30;

                case WashProgram.Premiumpesu:
                    return 45;

                default:
                    return 0;
            }
        }
    }
}