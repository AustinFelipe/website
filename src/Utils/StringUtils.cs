namespace AustinSite.Utils
{
    public static class StringUtils
    {
        public static string RemoveInvalidCharsAndNormalize(string removeFrom)
        {
            return removeFrom.ToLower().Replace("-", " ");
        }

        public static string GetFirstName(this string name)
        {
            var names = name.Split(' ');

            if (name.Length == 0)
                return string.Empty;

            return names[0];
        }
    }
}