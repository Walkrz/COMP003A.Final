namespace COMP003A.Final
{
    /// <summary>
    /// Author: Zachary Walker
    /// Course: COMP-003A-L01
    /// Purpose: Final Project 
    /// This program collects information and asks questions to build a dating profile
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // User Input Section
                string firstName = GetUserInput("Enter First Name: ");
                string lastName = GetUserInput("Enter Last Name: ");
                int birthYear = GetBirthYear();
                char gender = GetGender();
                string[] questionnaireResponses = GetQuestionnaireResponses();

                // Profile Summary Section
                Console.WriteLine("\nProfile Summary:");
                Console.WriteLine($"Full Name: {lastName}, {firstName}");
                Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
                Console.WriteLine($"Gender: {GetGenderDescription(gender)}");

                // Display Questionnaire Responses
                Console.WriteLine("\nQuestionnaire Responses:");
                for (int i = 0; i < questionnaireResponses.Length; i++)
                {
                    Console.WriteLine($"Question {i + 1}: {questionnaireResponses[i]}");
                }
            }
            catch  // Error Handling if everything else fails, I feel like this is redundant now because I cant find a way to break it but oh well
            {
                Console.WriteLine("\n Error Please Restart Program \n ");
            }
        }

        /// <summary>
        /// Gets user input with specified prompt and validates for null/empty/numeric/special characters.
        /// </summary>
        /// <param name="prompt">The prompt message for the user.</param>
        /// <returns>Validated user input.</returns>
        static string GetUserInput(string prompt)
        {
            string userInput;

            do
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput) || !userInput.All(char.IsLetter))
                {
                    Console.WriteLine("Invalid input. Please enter a valid value for the name.");
                }

            } while (string.IsNullOrWhiteSpace(userInput) || !userInput.All(char.IsLetter));

            return userInput;
        }

        /// <summary>
        /// Gets and validates the user's birth year.
        /// </summary>
        /// <returns>Validated birth year.</returns>
        static int GetBirthYear()
        {
            int currentYear = DateTime.Now.Year;

            while (true)
            {
                Console.Write("Enter Birth Year: ");
                if (int.TryParse(Console.ReadLine(), out int birthYear) && birthYear >= 1900 && birthYear <= currentYear)
                {
                    return birthYear;
                }
                else
                {
                    Console.WriteLine("Invalid birth year. Please enter a valid year.");
                }
            }
        }

        /// <summary>
        /// Gets and validates the user's gender.
        /// </summary>
        /// <returns>Validated gender.</returns>
        static char GetGender()
        {
            while (true)
            {
                Console.Write("Enter Gender (M/F/O): ");
                char gender = Char.ToUpper(Console.ReadKey().KeyChar);

                if (gender == 'M' || gender == 'F' || gender == 'O')
                {
                    Console.WriteLine(); // Move to the next line after user input
                    return gender;
                }
                else
                {
                    Console.WriteLine("\nInvalid gender. Please enter M, F, or O.");
                }
            }
        }

        /// <summary>
        /// Gets responses to a questionnaire.
        /// </summary>
        /// <returns>Array of user responses to the questionnaire.</returns>
        static string[] GetQuestionnaireResponses()
        {
            Console.WriteLine("\nQuestionnaire:");

            string[] responses = new string[10];
            for (int i = 0; i < responses.Length; i++)
            {
                Console.Write($"{i + 1}. ");
                switch (i)
                {
                    case 0:
                        Console.Write("What's your idea of a perfect date? \n");
                        break;
                    case 1:
                        Console.Write("If you could have dinner with any three people, dead or alive, who would they be and why? \n");
                        break;
                    case 2:
                        Console.Write("What's a book, movie, or TV show that left a lasting impression on you? \n");
                        break;
                    case 3:
                        Console.Write("What's your favorite way to spend a lazy Sunday afternoon? \n");
                        break;
                    case 4:
                        Console.Write("If you could travel anywhere in the world, where would you go first and why? \n");
                        break;
                    case 5:
                        Console.Write("What's a skill or hobby you've always wanted to learn but haven't had the chance to yet? \n");
                        break;
                    case 6:
                        Console.Write("What's your favorite type of music, and do you have a go-to song that always puts you in a good mood? \n");
                        break;
                    case 7:
                        Console.Write("Are you more of a city explorer or a nature enthusiast? \n");
                        break;
                    case 8:
                        Console.Write("What's the most adventurous thing you've ever done or would like to do? \n");
                        break;
                    case 9:
                        Console.Write("If you had to describe yourself in three words, what would they be? \n");
                        break;
                    default:
                        break;
                }

                do
                {
                    responses[i] = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(responses[i]))
                    {
                        Console.WriteLine("Invalid input. Please provide a response.");
                        Console.Write($"{i + 1}. ");
                    }

                } while (string.IsNullOrWhiteSpace(responses[i]));
            }

            return responses;
        }



        /// <summary>
        /// States the full description of the gender based on user input
        /// </summary>
        /// <param name="gender">The gender code (M/F/O).</param>
        /// <returns>Full gender description.</returns>
        static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other";
                default:
                    throw new ArgumentException("Invalid gender");
            }
        }
    }
}
