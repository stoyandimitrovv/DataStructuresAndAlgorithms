using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Wintellect.PowerCollections;

namespace MovieCharacters
{
    public class StartUp
    {
        public static void Main()
        {
            //Until the "End" command is received, receive lines in format:
            //{ Movie Name} | { Character Name}, { Character Role}

            OrderedMultiDictionary<string, Character> moviesWithCharacters = new OrderedMultiDictionary<string, Character>(true);

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                string movieName = tokens[0];

                string[] tokensForChakacter = tokens[1].Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string characterName = tokensForChakacter[0];
                string characterRole = tokensForChakacter[1];

                if (characterRole == "Main")
                {
                    moviesWithCharacters.Add(movieName, new Character(characterName, characterRole, true));
                }
                else
                {
                    moviesWithCharacters.Add(movieName, new Character(characterName, characterRole, false));
                }
                //moviesWithCharacters.Add(
                //    movieName, 
                //    new Character(characterName, characterRole, 
                //    characterRole == "Main" ? true : false));

                input = Console.ReadLine();
            }

            foreach (var movie in moviesWithCharacters)
            {
                Console.WriteLine($"{movie.Key}:");
                foreach (Character c in movie.Value)
                    Console.WriteLine($"{c}");

                Console.WriteLine();
            }
        }
    }
}
