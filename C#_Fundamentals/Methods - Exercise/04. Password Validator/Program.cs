namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
               bool firstRuleisValid = PassCharacterCheck(password); 
            bool secondRuleisValid = PassOnlyLettersAndDigitsCheck(password);
            bool thirdRuleisValid = PassDigitsAbove2Check(password);

           if (firstRuleisValid == false) Console.WriteLine("Password must be between 6 and 10 characters");
            if (secondRuleisValid == false) Console.WriteLine("Password must consist only of letters and digits");
            if (thirdRuleisValid == false) Console.WriteLine("Password must have at least 2 digits");

            if (firstRuleisValid && secondRuleisValid && thirdRuleisValid)
                Console.WriteLine("Password is valid");
          
        }
        static bool PassCharacterCheck(string password)
        {
            if (password.Length is >= 6 and <= 10)
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }

        static bool PassOnlyLettersAndDigitsCheck(string password)
        {
            
           foreach (char symbol in  password) 
            {
                if ((symbol is >= (char)48 and <= (char)57)
                    || (symbol is >= (char)65 and <= (char)90)
                    || (symbol is >= (char)97 and <= (char)122))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static bool PassDigitsAbove2Check(string password )
        {
            int digitsCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] is >= (char)47 and <= (char)57)
                {
                    digitsCount++;
                }
            }
            if (digitsCount < 2) return false;
            else return true;
            
        }
    }
}
