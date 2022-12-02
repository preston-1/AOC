using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_22.Day_2
{
    internal class Game {
        public int score { get ; set;}

        private char player1 { get; set; }
        private char player2 { get; set; }
        internal Game(char p1, char p2) 
        {
            player1 = p1; 
            player2 = p2;
        }

        internal int play() {
            //0 for loss 3 for draw 6 if win
            //1 for rock 2 for paper 3 for scissors
            //A & X ROCK
            //B & Y PAPER
            //C & Z SCISSORS
            //player1 
            switch (player1) {
                //rock
                case 'A':
                    {
                        switch (player2) {
                            case 'X': 
                                {
                                    //rock
                                    score = 4;
                                    break;
                                }
                            case 'Y': 
                                {
                                    //paper
                                    score = 8;
                                    break;
                                }
                            case 'Z':
                                {
                                    //scissors
                                    score = 3;
                                    break;
                                }
                        }
                        break;
                    }
                //paper
                case 'B':
                    {
                        switch (player2) {
                            case 'X': 
                                {
                                    //rock
                                    score = 1;
                                    break;
                                }
                            case 'Y': 
                                {
                                    //paper
                                    score = 5;
                                    break;
                                }
                            case 'Z': 
                                {
                                    //scissors
                                    score = 9;
                                    break;
                                }
                        }
                        break;
                    }
                //scissors
                default:
                    switch (player2)
                    {
                        case 'X':
                            {
                                //rock
                                score = 7;
                                break;
                            }
                        case 'Y':
                            {
                                //paper
                                score = 2;
                                break;
                            }
                        case 'Z':
                            {
                                //scissors
                                score = 6;
                                break;
                            }
                    }
                    break;
            }
            return score;
        }
        internal int play2()
        {
            //0 for loss 3 for draw 6 if win
            //1 for rock 2 for paper 3 for scissors
            //A & X ROCK
            //B & Y PAPER
            //C & Z SCISSORS
            //player1 
            switch (player1)
            {
                //rock
                case 'A':
                    {
                        switch (player2)
                        {
                            case 'X':
                                {
                                    //rock
                                    score = 3;
                                    break;
                                }
                            case 'Y':
                                {
                                    //paper
                                    score = 4;
                                    break;
                                }
                            case 'Z':
                                {
                                    //scissors
                                    score = 8;
                                    break;
                                }
                        }
                        break;
                    }
                //paper
                case 'B':
                    {
                        switch (player2)
                        {
                            case 'X':
                                {
                                    //rock
                                    score = 1;
                                    break;
                                }
                            case 'Y':
                                {
                                    //paper
                                    score = 5;
                                    break;
                                }
                            case 'Z':
                                {
                                    //scissors
                                    score = 9;
                                    break;
                                }
                        }
                        break;
                    }
                //scissors
                default:
                    switch (player2)
                    {
                        case 'X':
                            {
                                //rock
                                score = 2;
                                break;
                            }
                        case 'Y':
                            {
                                //paper
                                score = 6;
                                break;
                            }
                        case 'Z':
                            {
                                //scissors
                                score = 7;
                                break;
                            }
                    }
                    break;
            }
            return score;
        }
    }

    public class Day_2
    {
        public int result { get; set; }

        public Day_2()
        {
            int current_total = 0;
            foreach (string line in System.IO.File.ReadLines(@"/code/AOC/AOC_22/AOC_22/Day_2/input.txt"))
            {
                char[] picks = line.ToCharArray();
                var round = new Game((char)picks[0], picks[2]);
                int score = round.play2();
                current_total += score;
            }
            result = current_total;

        }
    }
}
