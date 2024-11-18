using System.Xml.Linq;

namespace TicTacToeGame
{
    public partial class Form1 : Form
    {
        // Assigning enums to the output of the player and CPU for X and O
        public enum Player
        {
            X, O
        }

        // Designates the player
        Player currentPlayer;

        // Creates the random input to be used for our CPU
        Random random = new Random();

        // Assigning values for player and CPU wins
        int playerWinCount = 0;
        int CPUWinCount = 0;

        // Making a new list
        List<Button> buttons;



        public Form1()
        {
            InitializeComponent();
            Restartgame();
        }

        private void CPUMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                // Chooses a random button using the int index from our list of buttons
                int index = random.Next(buttons.Count);

                // This will stop the button from being clicked again
                buttons[index].Enabled = false;

                // This assigns the CPU to the O variable for the game
                currentPlayer = Player.O;

                // This will convert the CPU informatio into a string, using the (O) enum
                buttons[index].Text = currentPlayer.ToString();

                // This will change the background of the selected button into the selected color
                buttons[index].BackColor = Color.DarkMagenta;

                // This will remove the button so the player or CPU wont try to choose it again
                buttons.RemoveAt(index);

                // This checks to see if the game has been won or lost yet
                CheckGame();

                // Stops the time for the CPU to choose a button once it finishes the above code
                CPUTimer.Stop();
            }
        }
        // Runs the restart game function if the game has been won or restarted when the button is pressed
        private void RestartGame(object sender, EventArgs e)
        {
            Restartgame();
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;

            // Assigns the player to the "X" variable
            currentPlayer = Player.X;

            // This will convert the player information (the click of the button) into a string (X) from the Player enum
            button.Text = currentPlayer.ToString();

            // This will make the button unable to be clicked again
            button.Enabled = false;

            // Gives color from the player character when clicked to show they clicked that button
            button.BackColor = Color.Cyan;

            // Removes the button so the CPU doesnt try to choose one thats already chosen
            buttons.Remove(button);

            // Runs the check game function to see if game has or hasnt been won yet
            CheckGame();

            // Starts the timer for the time for the CPU to move
            CPUTimer.Start();
        }

        private void CheckGame()
        {
            // Giving the "X" player the ability to win
            if (
                // Horizontal wins
                button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
             || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
             || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
             // Diagonal wins
             || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
             || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
             // Vertical wins
             || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
             || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
             || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
             )

            {
                // Stops the CPU timer if the win condition is met
                CPUTimer.Stop();

                // Plays a win message for the player
                MessageBox.Show("Player WIns!", "Good Job");

                // Adds to the player win count
                playerWinCount++;

                // Uses the lebel1.text function and adds a player win count to the text in the display
                label1.Text = "Player Wins: " + playerWinCount;

                // Restarts the game
                Restartgame();
            }

            // Giving the "O" player the ability to win
            else if (
            // Horizontal wins
                button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
             || button4.Text == "O" && button5.Text == "X" && button6.Text == "O"
             || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
             // Diagonal wins
             || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
             || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
             // Vertical wins
             || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
             || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
             || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
              )
            {
                // Stops the CPU timer if the win condition is met
                CPUTimer.Stop();

                // Plays a win message for the player
                MessageBox.Show("CPU WIns!", "You lose.");

                // Adds to the player win count
                CPUWinCount++;

                // Uses the label2.text function and adds a player win count to the text in the display
                label2.Text = "Player Wins: " + CPUWinCount;

                // Restarts the game
                Restartgame();
            }
        }

        /*This method will call to the buttons function and make a new list called buttons, naming each one
         *Then making a foreach loop to change every button to the following conditions when the restart button is pressed
         */
        private void Restartgame()
        {
            // Listing all of our buttons
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7,
                button8, button9 };


            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
