namespace sandboxCS
{
    internal abstract class StringService
    {
        //----------------------------------------------------------------------
        internal static bool StringIsNumber(string s)
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
        internal static string DotsToCommas(string withCommasStr)
        {
            string tempStr = "";
            foreach (char c in withCommasStr)
            {
                if ('.' == c) { tempStr += ','; }
                else tempStr += c;
            }
            return tempStr;
        }
        internal static string Reverse(string s)
        {
            string sRever = "";
            foreach (char c in s) { sRever = c + sRever; }
            return sRever;
        }
        //------------------------------------------------------------------------------end
    }
}