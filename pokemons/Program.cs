using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemons;

namespace program
{
    class Program
    {
        static void Main( string[] args )
        {
            Random rand = new Random();
            string ss;
            int choise;
            Stats player1;
            while (true)
            {
                Console.WriteLine( "Player1: \n1) Miki\n2) Baichu\n3) Z-Ver\n4) Rinamaru\n5) Limon\n\nMake your choise: " );
                ss = Console.ReadLine();
                if (ss == "")
                    continue;
                choise = Convert.ToByte( ss );
                if (rand.Next( 5 ) == 0)
                {
                    choise = 228;
                }
                switch(choise)
                {
                    case 1:
                        player1 = new Miki();
                        break;
                    case 2:
                        player1 = new Baichu();
                        break;
                    case 3:
                        player1 = new Z_ven();
                        break;
                    case 4:
                        player1 = new Rinamaru();
                        break;
                    case 5:
                        player1 = new Limon();
                        break;
                    case 228:
                        player1 = new Antonyuk();
                        break;
                    default:
                        Console.WriteLine( "Bad choise! Try again!" );
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
                break;
            }
            Console.Clear();
            Stats player2;
            while (true)
            {
                Console.WriteLine( "Player2: \n1) Miki\n2) Baichu\n3) Z-Ver\n4) Rinamaru\n5) Limon\n\nMake your choise: " );
                ss = Console.ReadLine();
                if (ss == "")
                    continue;
                choise = Convert.ToByte( ss );
                if (rand.Next( 5 ) == 0)
                {
                    choise = 228;
                }
                switch (choise)
                {
                    case 1:
                        player2 = new Miki();
                        break;
                    case 2:
                        player2 = new Baichu();
                        break;
                    case 3:
                        player2 = new Z_ven();
                        break;
                    case 4:
                        player2 = new Rinamaru();
                        break;
                    case 5:
                        player2 = new Limon();
                        break;
                    case 228:
                        player2 = new Antonyuk();
                        break;
                    default:
                        Console.WriteLine( "Bad choise! Try again!" );
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
                break;
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine( "Player1: \nHP = {0}\nDefence = {1}\nDamage = {2}\n\nPlayer2: \nHP = {3}\nDefence = {4}\nDamage = {5}\n\n", player1.Health, player1.Defence, player1.Damage, player2.Health, player2.Defence, player2.Damage );
                Console.ReadKey();
                Console.Clear();
                while (true)
                {
                    Console.WriteLine( "Player 1 turn: \n1) Attack\n2) Use spell (coldown = {0})\n3) Leave\n4) Provoke(skip turn)\n\nMake youre choise:", player1.Coldown );
                    ss = Console.ReadLine();
                    if (ss == "")
                        continue;
                    choise = Convert.ToByte( ss );
                    switch (choise)
                    {
                        case 1:
                            player1.Hit( player2 );
                            break;
                        case 2:
                            player1.UseSpell( player2 );
                            break;
                        case 3:
                            player1.Health = 0;
                            break;
                        case 4:
                            player1.Provoke();
                            break;
                        default:
                            Console.WriteLine( "Bad choise!" );
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                    }
                    break;
                }
                Console.ReadKey();
                Console.Clear();
                while (true)
                {
                    Console.WriteLine( "Player 2 turn: \n1) Attack\n2) Use spell(coldown = {0})\n3) Leave\n4) Provoke(skip turn)\n\nMake youre choise:", player2.Coldown );
                    ss = Console.ReadLine();
                    if (ss == "")
                        continue;
                    choise = Convert.ToByte( ss );
                    switch (choise)
                    {
                        case 1:
                            player2.Hit( player1 );
                            break;
                        case 2:
                            player2.UseSpell( player1 );
                            break;
                        case 3:
                            player2.Health = 0;
                            break;
                        case 4:
                            player2.Provoke();
                            break;
                        default:
                            Console.WriteLine( "Bad choise!" );
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                    }
                    break;
                }
                Console.ReadKey();
                Console.Clear();
                if (player1.Coldown > 0)
                    player1.Coldown--;
                if (player2.Coldown > 0)
                    player2.Coldown--;
                if (player1.Health <=0 && player2.Health <=0)
                {
                    Console.WriteLine( "Draw :c" );
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                if (player1.Health <= 0)
                {
                    Console.WriteLine( "Player2 WON!!!" );
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                if(player2.Health <=0)
                {
                    Console.WriteLine( "Player1 WON!!!" );
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
