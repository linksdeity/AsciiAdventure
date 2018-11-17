using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Enemy
    {
        //static random object for each enemy class to use
        static Random EnemyRoll = new Random();


        //constructor for stats
        public Enemy()
        {
        }


        //stats...
        public int Experience { get; set; } //the amount of experience a player gets for defeating the enemy
        public int Initiative { get; set; } //enemy speed, 1 - 10, 10 being fastest (determines who goes first in battle)
        public int Health { get; set; } //initial enemy hp
        public int Defense { get; set; } //enemy defense, reduces damage taken
        public int Strength { get; set; } //damage the enemy deals if they hit an attack
        public int Accuracy { get; set; } //odds of enemy hitting attack
        public int Intelligence { get; set; } //odds of enemy just taunting, or counter-attacking when defensive

        public string EnemyWeapon { get; set; } //what the enemy is attacking with
        public string Taunt { get; set; } //what the enemy shouts when taunting
        public string EnemyName { get; set; }//name fo enemy



        //"images"... these need the folder name plus a slash and then the text file name
        public string EnemyImage { get; set; } //default image of enemy
        public string EnemyAttack { get; set; } //enemy preparing to attack image
        public string EnemyTaunt { get; set; } //enemy preparing to taunt image
        public string EnemyDefend { get; set; } //enemy preparing to defend image
        public string EnemyAttacking { get; set; } //'animation' image for when enemy attacks
        public string EnemyDamaged { get; set; } //'animation' image of when enemy takes damage
        public string EnemyTaunting { get; set; } //'animation' image of an enemy taunting
        public string EnemyPop { get; set; } //image when enemy defeated
        public string EnemyDust { get; set; }// victory screen

        public string EnemyDisplay { get; set; } //stores the currently displayed image


 
            


        public int ActionAttack()
        {
            if(EnemyRoll.Next(1,11) <= Accuracy)
            {
                //hits for damage = to strength minus player armor (never negative)
                //display image of enemy attacking (use delay for 'animation effect'
            }
            {
                //misses and returns 0 damage
            }

            return 0;
        }



        public int ActionDefend()
        {
            //display enemy defensive image
            //raise defense by 50%
            //if player atacks
            //roll to see if knocked off balance
            //roll to see if attack succesful
            //display attacking image / 'animation'
            //if succesful return damage as strength minus armor (never negative)


            //the enemy defends, and takes less damage and can also counterattack if attacked
            //enemy counterattacks based on random number and inteligence, and then must also pass random number and accuracy
            return 0;
        }



        public int ActionTaunt()
        {
            //display image of enemy and use delay for 'aimation'
            //the enemy prepares to shout a taunt, and then shouts a taunt undefended
            //taunting enemy does not attack or defend but shouts a taunt at the player
            return 0;
        }
    }
}
