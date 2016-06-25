namespace AustinSite.Utils
{
    public static class StringUtils
    {
        public static string RemoveInvalidCharsAndNormalize(string removeFrom)
        {
            return removeFrom.ToLower().Replace("-", " ");
        }
    }
}