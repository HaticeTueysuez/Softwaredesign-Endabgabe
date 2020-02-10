using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static string[] words;
        public static void GameControls()
        {
            ConsoleOutput.GameDescription();
            Location currentLocation = Location.MapSetUp();
        
            Avatar avatar = Avatar.setupAvatar();
            Enemy enemy = Enemy.SetupEnemy();
            ConsoleOutput.DescribeLocation(currentLocation);
            for(;;)
            {
                SplitInput();

                switch (words[0])
                {   
                    case "north":
                    case "n":
                        if (currentLocation.North!= null) 
                        {
                            if(Location.RoomOpen(currentLocation.North, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.North;
                            Avatar.AvatarMove(currentLocation, avatar, enemy);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "east":
                    case "e":
                        if (currentLocation.East!= null)
                        {
                            if(Location.RoomOpen(currentLocation.East, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                                currentLocation = currentLocation.East;
                                Avatar.AvatarMove(currentLocation, avatar, enemy);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "south":
                    case "s":
                        if (currentLocation.South!= null)
                        {
                            if(Location.RoomOpen(currentLocation.South, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.South;
                            Avatar.AvatarMove(currentLocation, avatar, enemy);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "west":
                    case "w":
                        if (currentLocation.West != null)
                        {
                            if(Location.RoomOpen(currentLocation.West, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.West;
                            Avatar.AvatarMove(currentLocation, avatar, enemy);
                            }
                        }
                        else
                        {
                            Console.WriteLine("In diese Richtung gibt es keinen Weg! Bitte gehe in eine andere Richtung!");
                        }
                        break;
                    case "take":
                    case "t":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.TakeItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                ConsoleOutput.TakeAnyInput();
                            }
                        }
                        catch
                        {
                            ConsoleOutput.TakeAnyInput();
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.DropItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                ConsoleOutput.DropAnyInput();
                            }
                        }
                        catch
                        {
                            ConsoleOutput.DropAnyInput();
                        }
                        break;
                    case "Inventory":
                    case "i":
                            Items.ShowInventory(avatar);
                        break;
                    case "look":
                    case "l":
                        ConsoleOutput.DescribeLocation(currentLocation);
                        break;
                   
                    case "commands":
                    case "c":
                        Console.WriteLine("commands(c), look(l), inventory(i), take(t)<Item>, drop(d)<Item>, getinformation(g)<Item>, quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    case "attack":
                    case "a":
                        try
                        {
                            if(words[1] != "")
                            {
                                if(enemy.CurrentRoom == avatar.CurrentRoom)
                                {
                                    Attack.AttackEnemy(words[1] ,currentLocation, avatar, enemy);
                                }
                                else
                                {
                                    Console.WriteLine("Du kannst diesen Knopf nicht benutzen. Bitte drücke c für Hilfe!");
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            ConsoleOutput.AttackWrongInput();
                        }
                        break;
                        case "getinformation":
                        case "g":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.GetInformation(words[1]);
                            }
                            else
                            {
                                Console.WriteLine("Falsche eingabe");
                            }
                        }
                        catch
                        {

                        }
                        break;
                        default:
                        Console.WriteLine("Du kannst diesen Knopf nicht benutzen. Bitte drücke c für Hilfe!");
                        break;
                }
                WinConditions.CheckFinished(avatar);
            }
        }

        public static Array SplitInput()
        {
            string _input = Console.ReadLine();
            words = _input.Split(' ');
            return words;
        }
    }

}