namespace Skywalker.Webshop.Helpers
{
    public static class StringExtensions
    {
        public static string TrimSafe(this string s)
        {
            return s == null ? string.Empty : s.Trim();
        }
    }
}