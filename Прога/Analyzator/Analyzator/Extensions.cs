namespace Analyzator
{
    public static class Extensions
    {
        public static bool IsNumber(this char ch)
        {
            return char.IsDigit(ch);
        }
        public static bool IsLetter(this char ch)
        {
            return char.IsLetter(ch);
        }
        public static bool IsSign(this char ch)
        {
            return ch == '+' || ch == '-' || ch == '=';
        }
        public static bool IsSpace(this char ch)
        {
            return ch == ' ';
        }
        public static bool IsReservedWord(this string str)
        {
            return str == "dcl"
                    || str == "declare"
                    || str == "bin"
                    || str == "fixed"
                    || str == "float"
                    || str == "char";
        }
        public static int ToInt(this string intNumb)
        {
            return int.Parse(intNumb);
        }
    }
}
