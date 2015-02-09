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
        static Random rng = new Random();
        static int PauseDuration = 1000;
        static int CursorX = Console.WindowWidth;
        static int CursorY = Console.WindowHeight;

        static bool IsPlaying = true;
        static int RoundCounter = 0;
        static int NachosRemaining = 0;
        static int BirdsRemaining = 0;
        static bool ChuckNorrisPower = false;
        static string PlayerSuccess = string.Empty;
        static string BirdSuccess = string.Empty;



        static void Main(string[] args)
        {
            Console.SetWindowSize(116, 38);

            //IntroAnimation();
            //TitleSequence();
            //Instructions();
            RunGame();


            //for testing...
            //Console.ReadKey();
        }



        static void IntroAnimation()
        {
            Console.CursorVisible = false;
            IntroAniGraphics(0);
            Thread.Sleep(PauseDuration);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("Man....I love being retired.", 30);
            Thread.Sleep(PauseDuration * 2);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("                              ", 8);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("Nothing like enjoying some NACHOS at the beach.", 30);
            Thread.Sleep(PauseDuration * 2);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("                                                ", 8);
            Thread.Sleep(PauseDuration * 2);

            Console.Clear();
            IntroAniGraphics(1);
            Thread.Sleep(PauseDuration);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("OH CRAP!!  NOT AGAIN....!", 30);
            Thread.Sleep(PauseDuration);

            Console.Clear();
            IntroAniGraphics(2);
            Thread.Sleep(PauseDuration);
            Console.Clear();
            IntroAniGraphics(3);
            Thread.Sleep(PauseDuration / 4);
            Console.Clear();
            IntroAniGraphics(4);
            Thread.Sleep(PauseDuration / 2);
            Console.SetCursorPosition(15, 32);
            OldTimeyTextPrinter("GET AWAY FROM MY NACHOS YOU DAMN BIRDS!!!", 30);
            Thread.Sleep(PauseDuration * 3);
        }

        static void TitleSequence()
        {
            //"SEAGULL SHOWDOWN" ASCII image (***SEPARATE FUNCTION****)
            //image: person on one side of screen, seagull on other
            Console.Clear();
            SeagullShowdownText_1();
            Thread.Sleep(PauseDuration / 2);
            Console.Clear();
            SeagullShowdownText_2();
            Thread.Sleep(PauseDuration / 2);
            //Console.WriteLine();
            //Console.WriteLine();
            ManandSeagull_2();
            Thread.Sleep(PauseDuration);

            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                SeagullShowdownText_3();
                ManandSeagull_2();
                Thread.Sleep(PauseDuration / 4);
                Console.Clear();
                SeagullShowdownText_2();
                ManandSeagull_2();
                Thread.Sleep(PauseDuration / 4);
            }

            Thread.Sleep(PauseDuration * 2);

        }

        /// <summary>
        /// Prints instructions on how to play the game.
        /// </summary>
        static void Instructions()
        {
            Console.CursorVisible = false;
            Console.Clear();

            SeagullShowdownText_2();
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
            Thread.Sleep(PauseDuration);
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }

        static void RunGame()
        {
            IsPlaying = true;
            RoundCounter = 0;
       //***REMEMBER TO CHANGE VALUES BACK TO 20 AND 30
            NachosRemaining = 20;
            BirdsRemaining = 1;
            ChuckNorrisPower = false;
            PlayerSuccess = string.Empty;
            BirdSuccess = string.Empty;

            while (IsPlaying == true)
            {
                Console.Clear();
                if (ChuckNorrisPower == false)
                {
                    if (RoundCounter > 4)
                    {
                        if (3 >= rng.Next(1, 11))
                        {
                            ChuckNorrisPower = true;
                        }
                    }
                }
                SeagullShowdownText_2();
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
                Thread.Sleep(PauseDuration / 2);
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
                ChuckNorrisPowerText();
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
                OldTimeyTextPrinter("ENTER A VALID INPUT...", 10);
                PlayerSuccess = "STOP GOOFING AROUND!!";
                BirdSuccess = "YOUR NACHOS ARE IN DANGER!!";
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
                    OldTimeyTextPrinter("ENTER A VALID INPUT...", 10);
                    PlayerSuccess = "STOP GOOFING AROUND!!";
                    BirdSuccess = "YOUR NACHOS ARE IN DANGER!!";
                    Thread.Sleep(PauseDuration);
                    return false;
                }
            }
            else
            {
                Console.WriteLine();
                OldTimeyTextPrinter("ENTER A VALID INPUT...", 10);
                PlayerSuccess = "STOP GOOFING AROUND!!";
                BirdSuccess = "YOUR NACHOS ARE IN DANGER!!";
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

            nachosTaken = rng.Next(1, 4);
            NachosRemaining -= nachosTaken;
            if (NachosRemaining < 0)
            {
                NachosRemaining = 0;
            }
            BirdSuccess = "The Seagulls made off with " + nachosTaken + " of your chips!!";
        }

        static void WhoWon()
        {
            //YOU LOST!!
            if (NachosRemaining <= 0)
            {
                Console.Clear();
                SeagullShowdownText_2();
                RoundInfo();
                Thread.Sleep(PauseDuration * 2);
                Console.Clear();
                Console.CursorVisible = false;

                for (int i = 0; i < 3; i++)
                {
                    YouLost();
                    Thread.Sleep(PauseDuration / 6);
                    Console.Clear();
                    Thread.Sleep(PauseDuration / 6);
                }
                YouLost();
                Console.WriteLine();
                OldTimeyTextPrinter("         You can't win against some pesky birds???", 20);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(PauseDuration);

                PlayAgain();
            }
            //YOU WON!!
            else if (BirdsRemaining <= 0)
            {
                Console.Clear();
                SeagullShowdownText_2();
                RoundInfo();
                Thread.Sleep(PauseDuration * 2);
                Console.Clear();
                Console.CursorVisible = false;

                for (int i = 0; i < 3; i++)
                {
                    YouWon();
                    Thread.Sleep(PauseDuration / 6);
                    Console.Clear();
                    Thread.Sleep(PauseDuration / 6);
                }
                YouWon();
                Console.WriteLine();
                OldTimeyTextPrinter("         Damn birds are no match for your awesome skills!!", 20);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(PauseDuration);

                PlayAgain();
            }
        }

        static void PlayAgain()
        {
            Console.WriteLine();
            Console.Write("Do you want to play again, Y or N: ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                RunGame();
            }
            IsPlaying = false;
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

        static void IntroAniGraphics(int picNumber_)
        {
            switch (picNumber_)
            {
                case 0:
                    Console.WriteLine(@"
                 

                                                                              .     :     .
                                                                            .  :    |    :  .
                                                                             .  |   |   |  ,
                                                                              \  |     |  /
                                                                          .     ,-''''`-.     .
                                                                            '- /         \ -'
                                                                              |           |
                                                                        - --- |           | --- -
                                                                              |           |
                                                                            _- \         / -_
                                                                          .     `-.___,-'     .
                                                                              /  |     |  \
                                                                            .'  |   |   |  `.
                                                                               :    |    :
                                                                              .     :     .
                                                                                    .
 

              

    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                                                     ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          <()>                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 1:
                    Console.WriteLine(@"
                 

                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /         \ -'
            `^`^`^'`',    ;                                                   |           |
                      '; (                                              - --- |           | --- -
                        ``                                                    |           |
                                                                            _- \         / -_
                                                                          .     `-.___,-'     .
                                                                              /  |     |  \
                                                                            .'  |   |   |  `.
                                                                               :    |    :
                                                                              .     :     .
                                                                                    .
 

              

    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                                                     ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          <()>                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 2:
                    Console.WriteLine(@"
                 

                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /         \ -'
            `^`^`^'`',    ;                                                   |           |
                      '; (                        ___   ________        - --- |           | --- -
                        ``                       /---<9;/  ,__-==`            |           |
                                                ./~~( `)/`                  _- \         / -_
                                             ,-'_/// \  }                 .     `-.___,-'     .
                                              ~       XX\\                    /  |     |  \
                                                          \                 .'  |   |   |  `.
                                                                               :    |    :
                                                                              .     :     .
                                                                                    .
 

              

    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                         \    /                      ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          \()/                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 3:
                    Console.WriteLine(@"
 
                
                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /         \ -'
            `^`^`^'`',    ;                                                   |           |
                      '; (                        ___   ________        - --- |           | --- -
                        ``                       /---<9;/  ,__-==`            |           |
                                                ./~~( `)/`                  _- \         / -_
                                             ,-'_/// \  }                 .     `-.___,-'     .
                                              ~       XX\\                    /  |     |  \
      .`.   _ ____                                        \                 .'  |   |   |  `.
    __;_ \ /,//---\                                                            :    |    :
    --, `._) (                                                                .     :     .
     '//,,,  |                                                                      .
          )_/                
         /_|                 
                             
                                
    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                         \    /                      ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          \()/                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 4:
                    Console.WriteLine(@"
 
                
                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /  __ __  \ -'
            `^`^`^'`',    ;                                                   |  | .I. |  |
                      '; (                        ___   ________        - --- |   --^--   | --- -
                        ``                       /---<9;/  ,__-==`            |    ___    |
                                                ./~~( `)/`                  _- \  (___)  / -_
                                             ,-'_/// \  }                 .     `-.___,-'     .
                                              ~       XX\\                    /  |     |  \
      .`.   _ ____                                        \                 .'  |   |   |  `.
    __;_ \ /,//---\                                                            :    |    :
    --, `._) (                                                                .     :     .
     '//,,,  |                              ,                                       .
          )_/                 ,_     ,     .'<_
         /_|                 _> `'-,'(__.-' __<
                             >_.--(.. )  =;`
                                  `V-'`'\/``
    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                         \    /                      ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          \()/                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                default:
                    break;
            }
        }

        static void SeagullShowdownText_1()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
  _____   ___   ____   ____  __ __  _      _         
 / ___/  /  _] /    T /    T|  T  T| T    | T        
(   \_  /  [_ Y  o  |Y   __j|  |  || |    | |       
 \__  TY    _]|     ||  T  ||  |  || l___ | l___      
 /  \ ||   [_ |  _  ||  l_ ||  :  ||     T|     T    
 \    ||     T|  |  ||     |l     ||     ||     |    
  \___jl_____jl__j__jl___,_j \__,_jl_____jl_____j      
                                                                                                                   
");
            Console.WriteLine();
        }

        static void SeagullShowdownText_2()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
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

        static void SeagullShowdownText_3()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
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


        //NOT USING...
        static void ManandSeagull_1()
        {
            Console.WriteLine(@"

                .-'--.
              .'      '.
             /     _    `-.
            /      .\-     \,  ,
           ;       .-|-'    \####,
           |,       .-|-'    ;####
          ,##         `     ,|###'
        #,####, '#,        ,#|^;#
        `######  `#####,|##' |`)|
         `#####    ```o\`\o_.| ;\
          (-`\#,    .-'` |`  : `;
          `\ ;\#,         \   \-'
            )( \#    C,_   \   ;
            (_,  \  /   `'./   |
              \  / | .-`'--'`. |
               | ( \   ,  /_,  |
               \    `   ``     /
                '-.__     // .'
                     `'`.__.'

");

        }

        static void ManandSeagull_2()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
                                                   
                .-'--.                                                                  _______        
              .'      '.                                                            _.-'       ''...._
             /     _    `-.                                                       .'        .--.    '.`
            /      .\-     \,  ,                                                 : .--.    :    :     '-.
           ;       .-|-'    \####,                                              : :    :   :    :       :`
           |,       .-|-'    ;####                                              : :  @ :___:  @ : __     '`.
          ,##         `     ,|###'                                       _____..:---''''   `----''  `.   .''
        #,####, '#,        ,#|^;#                                     -''                      ___j  :   :
        `######  `#####,|##' |`)|                                    /                   __..''      :    `.
         `#####    ```o\`\o_.| ;\                                   /---------_______--''        __..'   /``
          (-`\#,    .-'` |`  : `;                                   \ _______________________--''       /
          `\ ;\#,         \   \-'                                                    --''               \
            )( \#    C,_   \   ;                                                     :                :`.:
            (_,  \  /   `'./   |                                                      :              /
              \  / | .-`'--'`. |                                                       \            /
               | ( \   ,  /_,  |                                                        \          .'
               \    `   ``     /                                                         :         :
                '-.__     // .'                                                           :        \
                     `'`.__.'                                                             :         \

");

        }


        static void ChuckNorrisPowerText()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(@"
  _______            __     _  __             _       ___                    
 / ___/ /  __ ______/ /__  / |/ /__  ________(_)__   / _ \___ _    _____ ____
/ /__/ _ \/ // / __/  '_/ /    / _ \/ __/ __/ (_-<  / ___/ _ \ |/|/ / -_) __/
\___/_//_/\_,_/\__/_/\_\ /_/|_/\___/_/ /_/ /_/___/ /_/   \___/__,__/\__/_/   
                                                                             ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void YouWon()
        {
            Console.WriteLine(@"
                                                       ______ __          
                                                     {-_-_= '. `'.          
                                                      {=_=_-  \   \     
                       \|//                      *     {_-_   |   /   
                     -/_ /            ,-.   *           '-.   |  /    .===,
                       _\\_           |  \    *      .--.__\  |_(_,==`  ( o)'-...
                       \_  \          x  |   *      `---.=_ `     ;      `/ -----\
                 ,///   >   )         \_  \             `,-_       ;    .'
                / + +\ /   /         _/ )_/               {=_       ;=~`    
                |     )  \/        _/ \/                   `//__,-=~`
                /\__D/    \      _/    )                   <<__ \\__
                 /  _   o  \   _/,   _/                    /`)))/`)))
                /   /       ,_/   __/       
               /   / \    o//    _/        
              /__o/   \___|    _/          
              _//       \__ __/\            
              \  \>       \     \            
              // |         \__   \            
                            /    /
                            \___(
                            /_/
                           / O \
                           '-   \__
                             \_____)  

");
        }

        static void YouLost()
        {
                    Console.WriteLine(@"
                                               _
                                              ~\\_
                                                \\\\
                                               `\\\\\
                         |                       |\\\\\
          \_            /;                        \\\\\|__.--~~\
          `\~--.._     //'                     _--~            /
           `//////\  \\/;'                ___/~ //////  _-~~~~'
             ~/////\~\`---\             /____'-//////-//
                 `~'  |                      //////(((-)
                 ;'_\'\                    /////
                /~/ '' ''               _///'                
               `\/'                    ~


                       _O/                
                         \        
                         /\_         
                         \      
        
");
        }


    }
}
