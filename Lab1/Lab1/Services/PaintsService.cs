namespace Lab1.Services
{
    public class PaintsService
    {
        public static bool ValidateCode(string str)
        {
            if (str.Length < 2 || str.Length > 5)
            {
                throw new Exception("Wrond Code value length");
            }

            if (str[0] != 'К')
            {
                throw new Exception("Code need starts with 'K'");
            }

            char genre = str[1];
            if (genre != 'П' && genre != 'А' && genre != 'І')
            {
                throw new Exception($"Code's second value is one of 'П','А' or 'І', not {str[1]}");
            }

            string digits = str.Substring(2);
            int number;
            if (!int.TryParse(digits, out number) || number < 1 || number > 9999)
            {
                throw new Exception("Wrond numbers length in Code value");
            }

            return true;
        }
        public static bool ValidateSecondName(string str)
        {

            if (char.IsLower(str[0]))
            {
                throw new Exception("Second name could not starts with lower letter");
            }

            return true;
        }
        public static bool ValidatePaintName(string str)
        {

            if (!str.All(char.IsLower))
            {
                throw new Exception("All letters in paint name value must be lower case");
            }

            return true;
        }
        public static bool ValidatePrice(int number)
        {
            if (number < 0)
            {
                throw new Exception("Price value could't be negative");
            }

            return true;
        }
        public static bool ValidatePaintType(int number)
        {

            if (number < 1 && number > 3)
            {
                throw new Exception("Paint type is 3 => x >= 1");
            }

            return true;
        }
    }
}
