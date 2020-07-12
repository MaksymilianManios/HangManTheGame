using System;
using System.Linq;
using System.Numerics;

namespace HangmanGameProgram
{
    class Program
    {
        //######################################### Const
        public const int GameLivesNumber = 5;
        //######################################### Password class
        class Password
        {
            private String HiddenPassword, AlreadyGuessed;
            private int lives;
            public char[] ShownPasword;

            public Boolean IsAlive()
            {
                return lives > 0 ? true : false;
            }
            public int GetLives()
            {
                return lives;
            }
            public void Guess(Char LetterGuessed)
            {
                LetterGuessed = Char.ToUpper(LetterGuessed);
                foreach (char letter in AlreadyGuessed)
                {
                    if (LetterGuessed == letter)
                    {
                        return;
                    }
                }
                Boolean IsPresent = false;
                for (int index = 0; index < HiddenPassword.Length; index++)
                {
                    if (LetterGuessed == HiddenPassword[index])
                    {
                        ShownPasword[index] = LetterGuessed;
                        IsPresent = true;
                    }
                }

                AlreadyGuessed += LetterGuessed;
                if (!IsPresent) { lives--; }
            }

            public void PrintGame()
            {
                String buff = "";
                foreach (char c in ShownPasword)
                {
                    buff += c;
                }
                Console.WriteLine("Password status : {0} \nLitters guessed : {1} \nLives : " + GetLives() + "/" + GameLivesNumber, buff, AlreadyGuessed);
            }

            public Password(String password)
            {
                password = password.ToUpper();
                lives = GameLivesNumber;
                AlreadyGuessed = "";
                ShownPasword = new char[password.Length];
                foreach (char LetterInPassword in password)
                {
                    HiddenPassword += LetterInPassword;
                    ShownPasword[HiddenPassword.Length - 1] = '_';
                }
            }
        };
        //######################################### Random string
        public static string GetPassword()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string[] Words = { "samochod", "kwiatek", "palidrom" , "pumpernikiel","cppjestmoimulubionymjezykiemijestemswiadommojejglupoty"};
            return Words[rand.Next(0, Words.Length)];
        }

        //######################################### Main
        static void Main(string[] args)
        {
            Password p = new Password(GetPassword());

            while (p.IsAlive())
            {
                p.PrintGame();
                try
                {
                    p.Guess(Console.ReadLine()[0]);
                }
                catch (System.IndexOutOfRangeException)
                {

                }
            }
        }
    }
}
            