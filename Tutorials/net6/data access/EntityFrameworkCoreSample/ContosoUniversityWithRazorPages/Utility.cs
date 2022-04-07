#if SQLLiteVersion

namespace ContosoUniversityWithRazorPages
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token.ToString().Substring(token.ToString().Length - 3);
        }
    }
}

#else
namespace ContosoUniversityWithRazorPages
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token[7].ToString();
        }
    }
}

#endif
