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

        //stats
        public int Health;
        public int Defense;
        public int Strength;
        public int Accuracy;
        public int Intelligence;


        //constructor for stats
        public Enemy(int health,int defense,int strength,int accuracy,int intelligence)
        {
            Health = health;
            Defense = defense;
            Strength = strength;
            Accuracy = accuracy;
            Intelligence = intelligence;
        }

        public string EnemyWeapon { get; set; } //what the enemy is attacking with
        public string Taunt { get; set; } //what the enemy shouts when taunting

        //"images"
        public string EnemyImage { get; set; } //default image of enemy
        public string EnemyAttack { get; set; } //enemy preparing to attack image
        public string EnemyTaunt { get; set; } //enemy preparing to taunt image
        public string EnemyDefend { get; set; } //enemy preparing to defend image
        public string EnemyAttacking { get; set; } //'animation' image for when enemy attacks
        public string EnemyDamaged { get; set; } //'animation' image of when enemy takes damage
        public string EnemyTaunting { get; set; } //'animation' image of an enemy taunting


        public int ActionGetAction()
        {
            if(EnemyRoll.Next(1,11) > Intelligence)
            {
                //taunt
            }
            else
            {
                int decision = (EnemyRoll.Next(1, 11));

                if(decision > 4)
                {
                    //attack
                    //return damage from attack method
                }
                else
                {
                    //defend
                    //return damage if counter attack landed
                }


            }

            return 0;
        }



        public int ActionAttack()
        {
            if(EnemyRoll.Next(1,11) >= Accuracy)
            {
                //hits for damage = to strength minus player armor (never negative)
            }
            {
                //misses and returns 0 damage
            }

            return 0;
        }



        public int ActionDefend()
        {

            //raise defense by 50%
            //if player atacks
            //roll to see if knocked off balance
            //roll to see if attack succesful
            //if succesful return damage as strength minus armor (never negative)


            //the enemy defends, and takes less damage and can also counterattack if attacked
            //enemy counterattacks based on random number and inteligence, and then must also pass random number and accuracy
            return 0;
        }



        public int ActionTaunt()
        {
            //the enemy prepares to shout a taunt, and then shouts a taunt undefended
            //taunting enemy does not attack or defend but shouts a taunt at the player
            return 0;
        }
    }
}
