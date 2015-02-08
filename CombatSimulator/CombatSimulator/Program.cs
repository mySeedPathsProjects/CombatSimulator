﻿using System;
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

        static int RoundCounter = 0;
        static int NachosRemaining = 0;
        static int BirdsRemaining = 0;
        static bool ChuckNorrisPower = false;
        static string PlayerSuccess = string.Empty;
        static string BirdSuccess = string.Empty;



        static void Main(string[] args)
        {
            Console.SetWindowSize(116, 35);

            //IntroAnimation();
            Instructions();
            //RunGame();

            //Console.ReadKey();
        }



        static void IntroAnimation()
        {
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
        }



        /// <summary>
        /// Prints instructions on how to play the game.
        /// </summary>
        static void Instructions()
        {
            Console.CursorVisible = false;
            Console.Clear();

            SeagullShowdownText();
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            OldTimeyTextPrinter("Man, you've been through this crap before.  Just trying to enjoy some nachos at the beach \nand a swarm of Seagulls come and eat all your food, ruining the day.", 20);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("This time you're fighting back!!  You've brought a bunch of Alka-Seltzer with you...\nknowing that Seagulls blow up if they eat one.", 20);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("You've also been honing your skills at throwing sand.  You're totally ready for this!!", 20);
            Thread.Sleep(PauseDuration);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       COMBAT CHOICES:");
            Thread.Sleep(PauseDuration);
            OldTimeyTextPrinter("**Alka-Seltzer kills a bird and causes others to fly away...but only if eaten.", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("**Throwing sand always works, but only makes a few birds fly away at most.", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("**Add more chips to the nachos if you almost run out (1-4).", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration);
            Console.WriteLine();
            OldTimeyTextPrinter("WORK FAST!!!  The Seagulls are attacking your plate the whole time, grabbing up to several chips at a time!!", 20);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }

        static void RunGame()
        {
            IsPlaying = true;
            NachosRemaining = 20;
            BirdsRemaining = 30;
            RoundCounter = 0;
            ChuckNorrisPower = false;
            PlayerSuccess = string.Empty;
            BirdSuccess = string.Empty;

            while (IsPlaying == true)
            {
                Console.Clear();
                if (RoundCounter > 2)
                {
                    int powerChance = rng.Next(1, 11);
                    if (powerChance <= 3)
                    {
                        ChuckNorrisPower = true;
                    }
                    else
                    {
                        ChuckNorrisPower = false;
                    }
                }
                SeagullShowdownText();
                RoundInfo();
                BasicInstructions();

                string userCombatChoice = Console.ReadLine();
                if (InputValidator(userCombatChoice))
                {
                    GameAction(userCombatChoice);
                    RoundCounter++;
                }
                WhoWon();
            }
        }

        static void RoundInfo()
        {
            if (RoundCounter > 0)
            {
                //Console.WriteLine(PlayerSuccess);
                OldTimeyTextPrinter(PlayerSuccess, 10);
                Thread.Sleep(PauseDuration / 2);
                Console.WriteLine();
                Console.WriteLine();
                //Console.WriteLine(BirdSuccess);
                OldTimeyTextPrinter(BirdSuccess, 10);
                Thread.Sleep(PauseDuration);
            }
            else
            {
                OldTimeyTextPrinter("NEVER GIVE UP!!", 10);
                Thread.Sleep(PauseDuration / 2);
                Console.WriteLine();
                Console.WriteLine();
                OldTimeyTextPrinter("THESE BIRDS WILL STOP AT NOTHING!!", 10);
                Thread.Sleep(PauseDuration);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(("Number of remaining BIRDS:  " + BirdsRemaining).PadRight(33));
            for (int i = 0; i < BirdsRemaining; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            //Console.WriteLine();
            Console.Write(("Number of remaining NACHOS: " + NachosRemaining).PadRight(33));
            for (int i = 0; i < NachosRemaining; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        static void BasicInstructions()
        {
            //print basic instructions
            Console.WriteLine("Enter 1 to use an Alka-Seltzer tablet...");
            Console.WriteLine("Enter 2 to throw sand at the damn birds...");
            Console.WriteLine("Enter 3 to replenish your chips if running low...");
            Console.WriteLine();
            if (ChuckNorrisPower == true)
            {
                //put in some ascii art of "Holy smokes!!"
                Console.WriteLine();
                Console.WriteLine("***HOLY SMOKES!!***  The Gods have bestowed upon you CHUCK NORRIS POWER!!");
                Console.WriteLine("Enter 4 to throw a tornado of sand at the birds and wipe them out!!!  DO IT!!!");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.Write("Enter your combat choice: ");
        }

        /// <summary>
        /// Input needs to be a 1, 2, or 3.  Can be a 4 only after "Chuck Norris Power" is enabled
        /// </summary>
        /// <param name="userInput_">1, 2, 3, or sometimes a 4</param>
        /// <returns>true if input is valid</returns>
        static bool InputValidator(string userInput_)
        {
            if (userInput_.Length != 1)
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

        static void GameAction(string userChoice_)
        {
            //int nachosTaken = 0;

        //***maybe make some string arrays to give slightly differnt responses for "PlayerSuccess" and "BirdSuccess"

            switch (Int32.Parse(userChoice_))
            {
                case 1:
                    if (rng.Next(2) == 0)
                    {
                        //Your play
                        BirdsRemaining--;
                        int extraBirdsFlyAway = rng.Next(2, 5);
                        BirdsRemaining -= extraBirdsFlyAway;
                        if (BirdsRemaining < 0)
                        {
                            BirdsRemaining = 0;
                        }
                        PlayerSuccess = "THE ALKA-SELTZER WORKED!!  " + extraBirdsFlyAway + " other birds also flew away!!";
                        //Seagull's play
                        SeagullsTurn();
                    }
                    else
                    {
                        //Your play
                        PlayerSuccess = "Sorry, that bird is too smart for your shenanigans.";
                        //Seagull's play
                        SeagullsTurn();
                    }
                    break;

                case 2:
                    //Your play
                    int sandSuccess = rng.Next(1, 4);
                    BirdsRemaining -= sandSuccess;
                    if (BirdsRemaining < 0)
                    {
                        BirdsRemaining = 0;
                    }
                    PlayerSuccess = "Nice sand toss.  " + sandSuccess + " birds flew off.";
                    //Seagull's play
                    SeagullsTurn();
                    break;

                case 3:
                    //Your play
                    int chipsAdded = rng.Next(1, 5);
                    NachosRemaining += chipsAdded;
                    PlayerSuccess = "You added " + chipsAdded + " chips back to your nachos.";
                    //Seagull's play
                    SeagullsTurn();
                    break;

                case 4:
                    //Your play
                    BirdsRemaining = 0;
                    PlayerSuccess = "OH YEAH!!!  You wiped them all out!!  Time to chill with some nachos!!";
                    //Seagull's play
                    BirdSuccess = "Seagulls are no match for a Chuck Norris sized tornado of sand!!";
                    break;

                default:
                    break;
            }
        }

        static void SeagullsTurn()
        {
            int nachosTaken = 0;

            nachosTaken = rng.Next(0, 4);
            NachosRemaining -= nachosTaken;
            if (NachosRemaining < 0)
            {
                NachosRemaining = 0;
            }
            BirdSuccess = "The Seagulls made off with " + nachosTaken + " of your chips!!";
        }

        static void WhoWon()
        {
            if (NachosRemaining <= 0 || BirdsRemaining <= 0)
            {
                Console.Clear();
            //***MAYBE DON'T SHOW "SeagullShowdownText" OR "RoundInfo" UPON WINNING OR LOSING, JUST GET ONTO END GRAPHIC****
                SeagullShowdownText();
                RoundInfo();
            //something other than a "pause" here???
                Thread.Sleep(PauseDuration * 2);
                Console.Clear();
                if (NachosRemaining == 0)
                {
            //you lost...create picture and text
                    Console.WriteLine("sorry you lost");
                }
                else if (BirdsRemaining == 0)
                {
            //you won...create picture and text
                    Console.WriteLine("awesome, you won");
                }

                Console.WriteLine();
                Console.Write("Do you want to play again: ");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    RunGame();
                }
                else
                {
                    IsPlaying = false;
                }
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
            Console.WriteLine(@"
  _____   ___   ____   ____  __ __  _      _           _____ __ __   ___   __    __  ___     ___   __    __  ____  
 / ___/  /  _] /    T /    T|  T  T| T    | T         / ___/|  T  T /   \ |  T__T  T|   \   /   \ |  T__T  T|    \ 
(   \_  /  [_ Y  o  |Y   __j|  |  || |    | |        (   \_ |  l  |Y     Y|  |  |  ||    \ Y     Y|  |  |  ||  _  Y
 \__  TY    _]|     ||  T  ||  |  || l___ | l___      \__  T|  _  ||  O  ||  |  |  ||  D  Y|  O  ||  |  |  ||  |  |
 /  \ ||   [_ |  _  ||  l_ ||  :  ||     T|     T     /  \ ||  |  ||     |l  `  '  !|     ||     |l  `  '  !|  |  |
 \    ||     T|  |  ||     |l     ||     ||     |     \    ||  |  |l     ! \      / |     |l     ! \      / |  |  |
  \___jl_____jl__j__jl___,_j \__,_jl_____jl_____j      \___jl__j__j \___/   \_/\_/  l_____j \___/   \_/\_/  l__j__j
                                                                                                                   
");
            Console.WriteLine();
        }
    }
}
