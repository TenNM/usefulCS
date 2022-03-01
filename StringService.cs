namespace StringService
{
    /// <summary>
    /// Class with string extension methods.
    /// </summary>
    public static class StringService
    {
        //----------------------------------------------------------------------

        /// <summary>
        /// Note: 1,23 is number, but 1.23 is not. Because double.Parse("1.23") throws exception.
        /// </summary>
        public static bool StringIsNumber(this string s)
        {
            bool weHaveOneComma = false;
            if (s[0].Equals(',')) { weHaveOneComma = true; }
            else if (!(char.IsDigit(s[0]) || s[0].Equals('-'))) { return false; }

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i].Equals(','))
                {
                    if (weHaveOneComma) { return false; }
                    else weHaveOneComma = true;
                }
                else if (!char.IsDigit(s[i])) { return false; }
            }

            return true;
        }

        /// <summary>
        /// Replace all dots in string.
        /// </summary>
        public static string DotsToCommas(this string withCommasStr)
        {
            string tempStr = "";
            foreach (char c in withCommasStr)
            {
                if ('.' == c) { tempStr += ','; }
                else tempStr += c;
            }
            return tempStr;
        }

        /// <summary>
        /// Reverse string.
        /// </summary>
        public static string Reverse(this string s)
        {
            string sRever = "";
            foreach (char c in s) { sRever = c + sRever; }
            return sRever;
        }

        /// <summary>
        /// Replace only first entry.
        /// </summary>
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        
        //------------------------------------------------------------------------------end
    }
}