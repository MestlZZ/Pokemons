using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    public interface Stats
    {
        int Health { get; set; }
        int Damage { get; set; }
        int Defence { get; set; }
        int Coldown { get; set; }
        void Say(string message, string action = null );
        void Hit( Stats enemy );
        void UseSpell( Stats enemy );
        void Provoke();
    }
    public abstract class Pokemon : Stats
    {
        public int Health { get; set; }

        public bool IsDead { get; protected set; }
        public int Damage { get;  set; }
        public int Defence { get; set; }
        public int Coldown { get; set; }
        public int SpellDamage { get; set; }

        public Pokemon()
        {
        }

        public Pokemon( int health, int damage )
        {
            Health = health;
            Damage = damage;
        }

        #region protected fields
        protected static string name = "Pokemon";
        protected int health = 5;
        #endregion

        #region protected methods
        public void Say( string message, string action = null )
        {
            if (IsDead)
                return;
            if (string.IsNullOrEmpty( message ))
                message = "$%!$#%^#";
            Console.WriteLine( string.Format( "{0} {1}: \"{2}\"", name, action ?? "said", message ) );
        }
        public void Hit( Stats enemy )
        {
            Random rand = new Random();
            int f = rand.Next(6);
            double koef = 1 / (double)enemy.Defence;
            int damag;
            if (f == 6)
                damag = Damage * 2;
            else
                damag = (int)((double)(Damage + f) * koef);
            if (enemy.Health <= damag)
                enemy.Health = 0;
            else
                enemy.Health -= damag;
            Console.WriteLine("Wow! Enemy lost {0}HP", damag);
        }
        protected void Die()
        {
            Say( "I'll be back!!! Ohh...", "died" );
            IsDead = true;
        }

        public abstract void UseSpell( Stats enemy );
        public abstract void Provoke();
        #endregion
    }
    public class Miki : Pokemon
    {
        public Miki()
        {
            Health = 100;
            Damage = 10;
            Defence = 1;
            Coldown = 0;
        }
        public override void Provoke()
        {
            Say( "Youre skill equal only 5% of my skill c:" );
        }
        public override void UseSpell(Stats enemy)
        {
            if (Coldown > 0)
            {
                Say( "Sorry( Not yet!" );
                return;
            }
            Say ( "Too easy :3", "used spell" );
            enemy.Damage--;
            Coldown = 4;
        }
    }
    public class Baichu : Pokemon
    {
        public Baichu()
        {
            Health = 110;
            Damage = 8;
            Defence = 2;
            Coldown = 0;
        }
        public override void Provoke()
        {
            Say( "I will remove you next time >:)" );
        }
        public override void UseSpell( Stats enemy )
        {
            if (Coldown > 0)
            {
                Say( "Sorry( Not yet!" );
                return;
            }
            Say( "Ha-ha! Get my ball!!!", "used spell" );
            enemy.Defence--;
            if (enemy.Defence < 1)
                enemy.Defence = 1;
            Coldown = 5;
        }
    }
    public class Z_ven : Pokemon
    {
        public Z_ven()
        {
            Health = 90;
            Damage = 15;
            Defence = 1;
            Coldown = 0;
        }
        public override void Provoke()
        {
            Say( "I have friend! His name is death! They like you :)" );
        }
        public override void UseSpell( Stats enemy )
        {
            if (Coldown > 0)
            {
                Say( "Sorry( Not yet!" );
                return;
            }
            Say( "You must fap for my defence!", "used spell" );
            Defence++;
            if(Defence == 9)
            {
                Defence = 8;
            }
            Coldown = 5;
        }
    }
    public class Rinamaru : Pokemon
    {
        public Rinamaru()
        {
            Health = 75;
            Damage = 20;
            Defence = 3;
            Coldown = 0;
        }
        public override void Provoke()
        {
            Say( "I'm STRONG!!!" );
        }
        public override void UseSpell( Stats enemy )
        {
            if (Coldown > 0)
            {
                Say( "Sorry( Not yet!" );
                return;
            }
            Say( "I kill you!!", "used spell" );
            enemy.Health -= 30;
            Coldown = 6;
        }
    }
    public class Limon : Pokemon
    {
        public Limon()
        {
            Health = 100;
            Damage = 14;
            Defence = 1;
            Coldown = 0;
        }
        public override void Provoke()
        {
            Say( "Bua... %@^#$^@... :((" );
        }
        public override void UseSpell( Stats enemy )
        {
            if (Coldown > 0)
            {
                Say( "Sorry( Not yet!" );
                return;
            }
            Say( "FOOOOOOODD!!!!", "used spell" );
            enemy.Coldown += 2;
            Coldown = 4;
        }
    }
    public class Antonyuk: Pokemon
    {
        public Antonyuk()
        {
            Health = 100;
            Damage = 8;
            Coldown = 5;
            Defence = 1;
        }
        public override void Provoke()
        {
            Say( "I will fired you :3" );
        }
        public override void UseSpell( Stats enemy )
        {
            if (Coldown > 0)
            {
                Say( "Sorry( Not yet!" );
                return;
            }
            Say( "YOU FIRED!!!", "used spell" );
            enemy.Health = 0;
        }
    }
}
