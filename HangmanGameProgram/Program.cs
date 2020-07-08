using System;

namespace HangmanGameProgram
{
    class Program
    {
        public const int LivesNumber = 5;
        class GameValues
        {
            private char[] Password;
            private char[] ShownFraze;
            private int LivesCount;
            private char[] LittersUsed;

            public GameValues()
            {
                LivesCount = LivesNumber;
                Random rand = new Random((int)DateTime.Now.Ticks);
                string[] Words = { "duda", "rower", "palidrom" };
                
            }

            public char[] GetPassword() { return Password; }
            public char[] GetShownFraze() { return ShownFraze; }
            public char[] GetLittersUsed() { return LittersUsed; }
            public int GetLivesCount() { return LivesCount; }
        };
        static bool IsPresent(char Litter,Char[] Pasword) // czy taka litera jest w hasle?
        {
            for(int i = 0; i < Pasword.Length; i++)
            {
                if (Pasword[i] == Litter)
                {
                    return true;
                }
            }
            return false;
        }
        static int RefreshPasword(char[] Password,char[] ShownFraze,char Litter,int lives)
        {
            if(Password.Length != ShownFraze.Length) { return 1; }

            if (IsPresent(Litter, Password))
            {
                for(int i = 0; i < Password.Length; i++)
                {
                    if(Password[i] == Litter) { ShownFraze[i] = Litter; }
                }
            }
            else
            {

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
