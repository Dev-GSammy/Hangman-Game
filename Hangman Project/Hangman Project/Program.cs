using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Written by Dev Samuel Fatunmbi
 * Date: 3rd, May 2021
 * Took 2 days to figure it all out
 */

namespace Hangman_Project
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            Console.WriteLine("\n =================HANGMAN       GAME===================");
            Console.WriteLine(" These unfilled gaps stand for a randomly generated name of man in the Bible");
            Console.WriteLine(" Guess and Type a letter at a time to fill the gaps. A wrong input reduces your life, a correct input earns you points \n You have only 5 lives. Let's Begin!!!\n");
            dataHolderList();

            Console.ReadLine();
        }

        public static void dataHolderList()
        {
            // instantiating and populating List.
            List<string> PopulateWords = new List<string>();
            PopulateWords.Add("Nehemiah");
            PopulateWords.Add("Samson");
            PopulateWords.Add("Paul");
            PopulateWords.Add("Moses");
            PopulateWords.Add("Nebuchadnezzar");
            PopulateWords.Add("Elimelech");
            PopulateWords.Add("Elijah");
            PopulateWords.Add("Zechariah");
            PopulateWords.Add("Nicodemus");
            PopulateWords.Add("Joseph");

            // Generating random number
            Random random = new Random();
            int randomNumber = random.Next(1, PopulateWords.Count());
            string CurrentWord = PopulateWords[randomNumber].ToLower();
            PopulateWords.Remove(PopulateWords[randomNumber]);
            CurrentDataHolder(CurrentWord);
        }
        
        public static void CurrentDataHolder(string CurrWord)
        {
            
            //stores current word, displays underscores of the currentWord length to the user.
            string currentWord = CurrWord;
            int currentWordLength = currentWord.Length;
            string[] wordFiller = new string[currentWord.Length];
            Console.WriteLine("\n");
            for (int i = 0; i < currentWord.Length; i++)
            {
                wordFiller[i] = "_";
            }
            //print out value of wordFiller for the user
            for (int i = 0; i < currentWord.Length; i++)
            {
                Console.Write(" " + wordFiller[i]);
            }
            Console.WriteLine("\n");
            char input = '_';
            //Try to catch error from user input
            try
            {
                Console.Write("Input a letter (must be a single character): ");
                input = Char.Parse(Console.ReadLine().ToLower());
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an error.");
                Console.WriteLine(ex.Message);
                Console.WriteLine("\n");
                CurrentDataHolder(CurrWord);
            }
            Console.WriteLine("\n");
            CalculateInput(currentWordLength, wordFiller, currentWord, input);
        }

        public static void CalculateInput(int cwl, string[] wf, string cw, char inp)
        {
            int userLife = 5;
            int score = 0;
            int currentWordLength = cwl;
            string[] wordFiller = wf; //I figured out that I need to change this string array to chararray
            string currWord = cw; // Well, same with this string to. I need to change it to charArray.
            char input = inp;
            char[] wordFill = new char[currentWordLength];
            for(int i=0; i<currentWordLength; i++)
            {
                wordFill[i] = char.Parse(wordFiller[i]); //successfully converted to char array
            }
            char[] currentWord = currWord.ToArray(); //changed this too to char array

            do
            {
                //if user is wrong from the input, decrease life
                if (!currentWord.Contains(input))
                {
                    userLife -= 1;
                }
                for (int i = 0; i < currentWordLength; i++)
                {
                    //if he's right, increase score
                    if (currentWord[i] == input)
                    {
                        wordFill[i] = input;
                        score += 2;
                    }
                }
                //display new wordFiller
                for (int i = 0; i < currentWordLength; i++)
                {
                    Console.Write(" " + wordFill[i]);
                }
                Console.WriteLine("                                         {0} points scored, {1} lives left", score, userLife);
                Console.WriteLine("\n");
                Console.Write("input a letter/character: ");
                input = char.Parse(Console.ReadLine());
                //if user re-enters an input that he already scored points for, report error and restart
                if (wordFill.Contains(input))
                {
                    Console.Write("Word already contains your input. Try again: ");
                    input = char.Parse(Console.ReadLine());
                    CalculateInput(cwl, wf, cw, inp);
                }
            } while (wordFill.Contains('_') && (userLife != 1));
            //inform user of the correct answer
            Console.WriteLine("The correct word is {0}.", currWord);
            Console.WriteLine("\n");
            //go to another word from the list and restart game.
            Console.WriteLine("Let's go to another word, shall we?");
            dataHolderList();
        }
    }
}
