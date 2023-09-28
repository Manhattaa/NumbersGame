using System;

//Fady Nadir Hatta .NET23
namespace NumbersGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("Välkommen till NumbersGame!");
                Console.WriteLine("Välj svårighetsnivå:");
                Console.WriteLine("1. Easy (20 tal, 12 försök)");
                Console.WriteLine("2. Medium (50 tal, 20 försök)");
                Console.WriteLine("3. Hard (100 tal, 10 försök)");
                Console.WriteLine("4. Harder Mode (100 tal, 5 försök)");
                Console.WriteLine("5. Inferno Mode (1000 tal, 10 försök)");

                int difficultyLevel;
                do
                {
                    Console.Write("Ange svårighetsnivå (1, 2, 3, 4 eller 5): ");
                } while (!int.TryParse(Console.ReadLine(), out difficultyLevel) || difficultyLevel < 1 || difficultyLevel > 5);

                int maxNumber;
                int maxAttempts;
                string[] responses = {
                "❄️⛇❄️ Det är svinkallt ❄️⛇❄️",
                "❄️ Det är väldigt kallt! ❄",
                "Typ Stockholmsväder",
                "Typ Ljummet.",
                "Det är ganska varmt ändå",
                "Väldigt varmt, Solkräm?",
                "🔥Extremt varmt just nu, du är nära!🔥",
            };

                switch (difficultyLevel)
                {
                    case 1:
                        maxNumber = 20;
                        maxAttempts = 12;
                        break;
                    case 2:
                        maxNumber = 50;
                        maxAttempts = 20;
                        break;
                    case 3:
                        maxNumber = 100;
                        maxAttempts = 10;
                        break;
                    case 4:
                        maxNumber = 100;
                        maxAttempts = 5;
                        break;
                    case 5:
                        maxNumber = 1000;
                        maxAttempts = 10;
                        break;
                    default:
                        maxNumber = 20; // Default till enkel nivå om ogiltig input
                        maxAttempts = 12;
                        break;
                }

                Console.WriteLine($"Du har valt svårighetsnivå {difficultyLevel}. Du får gissa ett nummer mellan 1 och {maxNumber}. Du har {maxAttempts} försök.");

                // Slumpa fram ett tal mellan 1 och maxNumber
                Random random = new Random();
                int number = random.Next(1, maxNumber + 1);

                int attempts = 0;
                bool correctGuess = false;
                bool firstGuess = true; // Flagga för den första gissningen
                int previousDifference = 0;

                while (attempts < maxAttempts)
                {
                    Console.WriteLine(); // Tom rad för mellanrum
                    Console.Write("Gissa vilket nummer jag tänker på: ");
                    if (int.TryParse(Console.ReadLine(), out int guess))
                    {
                        int difference = Math.Abs(guess - number);

                        if (difference == 0)
                        {
                            correctGuess = true;
                            Console.WriteLine("🔥🔥🔥Hela världen brinner runt omkring dig; men du har åtminstone rätt!🔥🔥🔥");
                            break; // Användaren gissade rätt, avsluta loopen
                        }
                        else if (difference > previousDifference && firstGuess == false)

                        {
                            Console.WriteLine("Du känner att det börjar bli kallare!");
                        }
                        else if (difference < previousDifference && firstGuess == false)
                        {
                            Console.WriteLine("Du känner att det börjar bli varmare.");
                        }
                        else if (firstGuess == false) 
                        {
                            Console.WriteLine("Det är samma som sist, ingen förändring.");
                        }

                        if (difference <= 7)
                        {
                            Console.WriteLine(responses[6]); // "🔥Extremt varmt just nu, du är nära!🔥"
                        }
                        else if (difference <= 15)
                        {
                            Console.WriteLine(responses[5]); // "Väldigt varmt, Solkräm?"
                        }
                        else if (difference <= 25)
                        {
                            Console.WriteLine(responses[4]); // "Det är ganska varmt ändå"
                        }
                        else if (difference <= 35)
                        {
                            Console.WriteLine(responses[3]); // "Det känns Ljummet."
                        }
                        else if (difference <= 45)
                        {
                            Console.WriteLine(responses[2]); // "Typ kylskåpskallt!"
                        }
                        else if (difference <= 60)
                        {
                            Console.WriteLine(responses[1]); // "Det är väldigt kallt!"
                        }
                        else
                        {
                            Console.WriteLine(responses[0]); // "Det är iskallt"
                        }

                        previousDifference = difference;
                    }
                    else
                    {
                        Console.WriteLine($"Ogiltig inmatning. Ange ett heltal mellan 1 och {maxNumber}.");
                    }

                    if (firstGuess == true)
                    {
                        firstGuess = false; // Sätt flaggan till false efter den första gissningen
                    }

                    attempts++;
                }

                if (!correctGuess)
                {
                    Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på {maxAttempts} försök. Det rätta talet var {number}.");
                }
                if (correctGuess)
                    Console.WriteLine("Vill du spela igen? (Y/N)");
                string playAgainResponse = Console.ReadLine();

                if (!playAgainResponse.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    playAgain = false; // Om användaren inte vill spela igen, avsluta loopen
                }
            }
        }
    }
}