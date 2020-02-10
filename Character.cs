using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameCharacter
    {
        public string Name;
        public int Health;
        public List<Items> Inventory = new List<Items>();
        public int CurrentRoom;
    }

    class Avatar : GameCharacter
    {
        public static Dictionary<string, GameCharacter> Characters;
        public Avatar(string name, int health, int currentRoom)
        {
            Name = name;
            Health = health;
            CurrentRoom = currentRoom;
        }
        public static Avatar setupAvatar()
        {
            Avatar hatice = new Avatar(
                "Hatice", 3, 0
            );
            Characters = new Dictionary<string, GameCharacter>();
            Characters["Hatice"] = hatice;
            return hatice;
        }
        public static int AvatarMove(Location location, Avatar avatar, Enemy enemy)
        {
            Avatar.Characters["Hatice"].CurrentRoom = location.RoomNumber;
            ConsoleOutput.DescribeLocation(location);
            Enemy.EnemySameRoom(location, avatar, enemy);
            
            return Avatar.Characters["Hatice"].CurrentRoom;
        }
    }

    class Enemy : GameCharacter
    {
        public bool Life;
        public string JobTitle; 
        public static Dictionary<string, GameCharacter> Characters;

        public Enemy(string name, int health, int currentRoom, bool life, string jobTitel)
        {
            Name = name;
            Health = health;
            CurrentRoom = currentRoom;
            Life = life;
            JobTitle = jobTitel;
        }

        public static Enemy SetupEnemy()
        {
            Enemy drscalp = new Enemy(
                "drscalp", 3, 2, true, "Bösewicht"
            );
            Items secretKey = new Items
            (
                "geheimschlüssel", "Geheimschlüssel", "Zentralschlüssel der Zugang zu allen Räumen bietet.", true
            );
            drscalp.Inventory.AddRange(new List<Items>
            {
                secretKey
            });

            Characters = new Dictionary<string, GameCharacter>();
            Characters["drscalp"] = drscalp;
            return drscalp;
        }
        public static void EnemySameRoom(Location location, Avatar avatar, Enemy enemy)
        {
            if(enemy.Life == true)
            {
                if(avatar.CurrentRoom == enemy.CurrentRoom)
                    {
                        Attack.EnemyCurrentRoom(avatar, enemy);
                    }
            }
        }
    }
}