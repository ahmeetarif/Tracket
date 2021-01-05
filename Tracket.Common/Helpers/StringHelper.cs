namespace Tracket.Common.Helpers
{
    public static class StringHelper
    {
        public static bool CheckStringNullWhitespaceAndEmpty(this string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text))
            {
                return true;
            }

            return false;
        }
    }
}