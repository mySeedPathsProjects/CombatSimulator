using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        //GLOBAL VARIABLES
        static bool IsPlaying = true;
        static Random rng = new Random();

        static int PauseDuration = 1000;
        static int CursorX = Console.WindowWidth;
        static int CursorY = Console.WindowHeight;

        static int NachosRemaining = 20;
        static int BirdsRemaining = 30;
        static bool ChuckNorrisPower = false;




        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 35);

            //INTRO ANIMATION
            Instructions();
            //RUNGAME FUNCTION

            Console.ReadKey();
        }




        //INTRO ANIMATION
            //Console.CursorVisible = false;
        //pic of person at beach (pixels rain in like Matrix if possible)
        //text on screen "nothing like enjoying some nachos at the beach"
        //clear text, birds start popping up in the image
        //new image/anime: bird grabs nacho
        //clear image, large ascii text "dude, those are my nachos"
        //new image: kick bird
        //clear image, large ascii text "oh it's on!!"
        //words and image printed to screen "old typewriter" style:
      //"SEAGULL SHOWDOWN" ASCII image (***SEPARATE FUNCTION****)
        //image: person on one side of screen, seagull on other



        /// <summary>
        /// Prints instructions on how to play the game.
        /// </summary>
        static void Instructions()
        {
            Console.CursorVisible = false;
            Console.Clear();

            SeagullShowdownText();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("Man, you've been through this crap before.  Just trying to enjoy some nachos at the beach and a swarm of Seagulls come and eat all your food, ruining the day.", 10);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("This time you're fighting back!!  You've brought a bunch of Alka-Seltzer with you...knowing that Seagulls blow up if they eat one.", 10);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("You've also been honing your skills at throwing sand.  You're totally ready for this!!", 10);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("Alka-Seltzer kills a bird and causes others to fly away...but only if eaten.", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("Throwing sand always works, but only makes a few birds fly away at most.", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("Add more chips to the nachos if you almost run out (1-5).", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("WORK FAST!!!  The Seagulls are attacking your plate the whole time, grabbing up to several chips at a time!!", 10);

            //ROUND INFO function

        }

        static void RunGame()
        {
            NachosRemaining = 20;
            BirdsRemaining = 30;

            while (IsPlaying == true)
            {
                SeagullShowdownText();


            }
        }

        /// <summary>
        /// Input needs to be a 1, 2, or 3.  Can be a 4 only after "Chuck Norris Power" is enabled
        /// </summary>
        /// <param name="userInput_">1, 2, 3, or sometimes a 4</param>
        /// <returns>true if input is valid</returns>
        static bool InputValidator(string userInput_)
        {
            if (userInput_.Length > 1)
            {
                Console.WriteLine();
                OldTimeyTextPrinter("PLEASE ENTER A 1, 2, OR A 3", 20);
                Thread.Sleep(PauseDuration);
                return false;
            }
            else if ("123".Contains(userInput_[0]))
            {
                return true;
            }
            else if (userInput_ == "4")
            {
                if (ChuckNorrisPower == true)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    OldTimeyTextPrinter("PLEASE ENTER A 1, 2, OR A 3", 20);
                    Thread.Sleep(PauseDuration);
                    return false;
                }
            }
            else
            {
                Console.WriteLine();
                OldTimeyTextPrinter("PLEASE ENTER A 1, 2, OR A 3", 20);
                Thread.Sleep(PauseDuration);
                return false;
            }


        }


        /// <summary>
        /// Prints text to screen one char at a time
        /// </summary>
        /// <param name="inputText">text you want to print</param>
        /// <param name="pause">time between each digit printing</param>
        static void OldTimeyTextPrinter(string inputText, int pause)
        {
            //loop through each character
            for (int i = 0; i < inputText.Length; i++)
            {
                char letter = inputText[i];
                Console.Write(letter);
                Thread.Sleep(pause);
            }
        }



        //************GRAPHICS**************

        static void SeagullShowdownText()
        {
            Console.WriteLine();
            //ASCII ART
        }
    }
}
