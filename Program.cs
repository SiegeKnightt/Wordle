namespace Wordle {

    class Program {

        // Print the game board
        /*
        - - - - - - - - - - - 
        | H | E | L | L | O |
        - - - - - - - - - - -
        | W | O | R | L | D |
        - - - - - - - - - - -
        |   |   |   |   |   |
        - - - - - - - - - - -
        |   |   |   |   |   |
        - - - - - - - - - - -
        |   |   |   |   |   |
        - - - - - - - - - - -
        |   |   |   |   |   |
        - - - - - - - - - - -
        */
        // Generate 5 letter word for the game (from file or API?) to guess
        // Take user input for guess
        // Parse input for validation
        // If input is longer than 5 letters, only use first 5
        // Validate if a letter matches on the board (in the correct position)
        // Validate if a letter is in the word (but not in the correct position)
        // Update the game board to show the correct letter and correct position guess
        // Update the gameboard to show letter is not in word guess
        // Update the gameboard to show correct letter wrong position guess
        // Account for only having 6 attempts to guess
        // If all letters match, end the game with a win
        static void Main() {

            Console.WriteLine("Welcome to Wordle!");
            Console.WriteLine();

            bool game = true;
            int attempt = 0;
            string winningWord = "WINER";
            string[] words = ["", "", "", "", "", ""];

            while (game) {

                string word = "";
                
                while (word.Length != 5) {

                    Console.WriteLine("Type in a 5 letter word to guess: ");

                    word = Console.ReadLine() ?? "";
                }

                words[attempt] = word.ToUpper();

                Program.printBoard(words, winningWord, attempt);

                if (words[attempt] == winningWord) {

                    Console.WriteLine("Y   O   U   W   I   N\n");
                    Console.WriteLine("The word was: " + winningWord);

                    game = false;
                }
                
                if (attempt == 5) {

                    Console.WriteLine("You Lose!");
                    Console.WriteLine("The word was: " + winningWord);

                    game = false;
                }

                attempt++;
            }   
        }

        static void printBoard(string[] words, string winningWord, int attempt) {

            for (int row = 0; row < 6; row++) {

                Console.WriteLine("- - - - - - - - - - -");
                Console.WriteLine("|   |   |   |   |   |");

                if (words[row] != string.Empty) {
                    
                    Console.Write("| ");

                    for (int i = 0; i < 5; i++) {

                        for (int j = 0; j < 5; j++) {

                            if (winningWord[j] == words[row][i]) {

                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                        }

                        if (words[row][i] == winningWord[i]) {

                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        Console.Write(words[row][i]);
                        
                        Console.ResetColor();

                        if (i != 4) {

                            Console.Write(" | ");
                        }
                    }

                    Console.Write(" |\n");
                }
                else {

                    Console.WriteLine("|   |   |   |   |   |");
                }

                Console.WriteLine("|   |   |   |   |   |");
            }
                
            Console.WriteLine("- - - - - - - - - - -");
            Console.WriteLine();
        } 
    }
}