using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Player
    {
        public int HP { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int WeaponBonus { get; set; } = 0;
        public int Initiative { get; set; } = 5;
        public int currentHP { get; set; } = 15;

        string Item1 { get; set; }
        string Item2 { get; set; }
        string Item3 { get; set; }

        string Weapon { get; set; }

        public Player()
        {
            HP = 15;
            Strength = 2;
            Defense = 1;
            Level = 1;
            XP = 0;
            Weapon = "knife";
        }

        private string levelMessage;

        public int Attack()
        {
            return Strength + WeaponBonus;
        }

        public string LevelUp(int Xperience)
        {
            bool newLevel = false;
            XP += Xperience;

            
            if (XP >= 540 && Level < 15) // 60 - HP + 10
            {
                Level = 15;
                newLevel = true;
                HP += 10;
                currentHP = HP;
                levelMessage = "Your HP has gone up!";
            }
            else if(XP >= 480 && Level < 14) // 60 - DEFENSE + 1
            {
                Level = 14;
                newLevel = true;
                Defense += 1;
                currentHP = HP;
                levelMessage = "Your DEFENSE has gone up!";
            }
            else if (XP >= 420 && Level < 13) // 50 - STRENGTH + 1
            {
                Level = 13;
                newLevel = true;
                Strength += 1;
                currentHP = HP;
                levelMessage = "Your STRENGTH has gone up!";
            }
            else if (XP >= 370 && Level < 12) // 50 - HP + 5
            {
                newLevel = true;
                Level = 12;
                HP += 5;
                currentHP = HP;
                levelMessage = "Your HP has gone up!";
            }
            else if (XP >= 320 && Level < 11) // 50 - DEFENSE + 1
            {
                newLevel = true;
                Level = 11;
                Defense += 1;
                currentHP = HP;
                levelMessage = "Your DEFENSE has gone up!";
            }
            else if (XP >= 270 && Level < 10) //40 - STRENGTH +1
            {
                Level = 10;
                newLevel = true;
                Strength += 1;
                currentHP = HP;
                levelMessage = "Your STRENGTH has gone up!";
            }
            else if (XP >= 230 && Level < 9) //40 - HP + 5
            {
                Level = 9;
                newLevel = true;
                HP += 5;
                currentHP = HP;
                levelMessage = "Your HP has gone up!";
            }
            else if (XP >= 190 && Level < 8) //40 - DEFENSE + 1
            {
                Level = 8;
                newLevel = true;
                Defense += 1;
                currentHP = HP;
                levelMessage = "Your DEFENSE has gone up!";
            }
            else if (XP >= 150 && Level < 7) //30 - STRENGTH + 1
            {
                Level = 7;
                newLevel = true;
                Strength += 1;
                currentHP = HP;
                levelMessage = "Your STRENGTH has gone up!";
            }
            else if (XP >= 120 && Level < 6) //30 - HP + 3
            {
                Level = 6;
                newLevel = true;
                HP += 3;
                currentHP = HP;
                levelMessage = "Your HP has gone up!";
            }
            else if (XP >= 90 && Level < 5) //30 - DEFENSE + 1
            {
                Level = 5;
                newLevel = true;
                Defense += 1;
                currentHP = HP;
                levelMessage = "Your DEFENSE has gone up!";
            }
            else if (XP >= 60 && Level < 4) //20 - STRENGTH + 1
            {
                Level = 4;
                newLevel = true;
                Strength += 1;
                currentHP = HP;
                levelMessage = "Your STRENGTH has gone up!";
            }
            else if (XP >= 40 && Level < 3) //20 - HP + 2
            {
                Level = 3;
                newLevel = true;
                HP += 2;
                currentHP = HP;
                levelMessage = "Your HP has gone up!";
            }
            else if (XP >= 20 && Level < 2) //20 - DEFENSE + 1
            {
                Level = 2;
                newLevel = true;
                Defense += 1;
                currentHP = HP;
                levelMessage = "Your DEFENSE has gone up!";
            }

            string message = "";

            if(newLevel == true)
            {
                message = "NEW LEVEL!!! You are now level " + Level + "!\n" + 
                          levelMessage;
            }
            else
            {
                message = "You gained: " + Xperience + " XP!";
            }

            return message;

        }





    }
}
