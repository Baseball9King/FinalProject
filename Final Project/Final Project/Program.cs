using System;

class BlackJackButBetter
{
    Random rand;
    bool RoundStart = false;
    int playerMoney = 1000;
    int betAmnt = 100;
    string playerResponse = "";
    bool LessThan50000 = true;
    public BlackJackButBetter()
    {
        rand = new Random();
    }

    public int NewCard()
    {
        int card =rand.Next(1, 14);
        if (card >= 10)
        {
            return 10;
        }
        else return card;
    }

    public int ComputerRound()
    {
        int CompNumb = NewCard();
        while (CompNumb < 16)
            if (CompNumb < 16)
            {
                CompNumb += NewCard();
            }

        return CompNumb;
    }

    public int PlayerRound()
    {
        string PlayerAnswer = "";

        int playerTotal = NewCard();        

        while (!PlayerAnswer.Equals("s"))
        {
            playerTotal += NewCard();

            if (playerTotal > 21)
            {
                Console.WriteLine("Your total is " + playerTotal + ". You Bust.");
                PlayerAnswer = "s";
            }
            else
            {
                Console.WriteLine("Your total is " + playerTotal + ". Would you like to hit (h) or stand (s)?");
                PlayerAnswer = Console.ReadLine();
            }
        }
        return playerTotal;
    }
    public string Score(int player, int computer)
    {
        if (computer > 21)
        {
            if (player > 21)
            {
                playerMoney -= betAmnt;
                return "You Lose.";
            }
            else
            {
                playerMoney += betAmnt;
                return "You Win.";
            }
        }
        else if (player > 21)
        {
            playerMoney -= betAmnt;
            return "You Lose.";
        }
        else
        {
            if (player > computer)
            {
                playerMoney += betAmnt;
                return "You Win.";
            }
            if (player < computer)
            {
                playerMoney -= betAmnt;
                return "You Lose.";
            }
            if (player == computer)
            {
                return "You Tie.";
            }
        }
        return "";
    }
    static void Main(string[] args)
    {
        BlackJackButBetter jack = new BlackJackButBetter();
        //Play infinate games
        while (jack.LessThan50000 == true)
        {
            //Make a new blackjack game
                            
            while (jack.RoundStart == false)
            {
                if (jack.playerMoney <= 50000)
                {
                    Console.WriteLine("How much would you like to bet? You have " + jack.playerMoney + ". Use (u) and (d) to adjust the ammount. Press (a) to go all in. Once you are fine with the amount press (m) to start.");
                    Console.WriteLine(jack.betAmnt);
                    jack.playerResponse = Console.ReadLine();
                    if (jack.playerResponse == "u")
                    {
                        jack.betAmnt += 10;
                        if (jack.betAmnt > jack.playerMoney)
                        {
                            jack.betAmnt -= 10;
                            Console.WriteLine("You Dont Have That Much Money, Win More.");
                        }
                        else
                            Console.WriteLine(jack.betAmnt);
                    }
                    else if (jack.playerResponse == "d")
                    {
                        jack.betAmnt -= 10;
                        Console.WriteLine(jack.betAmnt);
                    }
                    else if (jack.playerResponse == "a")
                    {
                        jack.betAmnt = jack.playerMoney;
                        Console.WriteLine(jack.betAmnt);
                    }
                    else
                    {
                        if (jack.betAmnt > jack.playerMoney)
                        {
                            jack.betAmnt -= 10;
                            Console.WriteLine("You Dont Have That Kind Of Money, Win More.");
                        }
                        else
                            jack.RoundStart = true;
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Whoa There Buddy You've been on too long of a hot streak, we're gonna have to ask you to leave");
                        jack.LessThan50000 = false;
                    }
                }                
            }
                

            
            //Player takes their turn to try and get the best score they can 
            int player = jack.PlayerRound();

            //Computer takes their turn to try and get the best score they can
            int computer = jack.ComputerRound();

            //Print the two scores and use the Score method to declare the outcome of the game.
            Console.WriteLine("You scored " + player + ", the computer scored " + computer + ".");
            Console.WriteLine(jack.Score(player, computer));
            jack.RoundStart = false;
        }
    }
}