using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulettipeli
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Tervetuloa rulettipeliin!");
            Console.WriteLine("Säännöt: Pelin alussa sinulla on 100 yksikköä pelin sisäistä rahaa.");
            Console.WriteLine();
            Console.WriteLine("1. Valitse, haluatko valita numeron vai värin.");
            Console.WriteLine();
            Console.WriteLine("2. Jos valitset numero:");
            Console.WriteLine("  ·Valitse numero väliltä 0-36.");
            Console.WriteLine("  ·Valitse panos 1-100 yksikköä.");
            Console.WriteLine();
            Console.WriteLine("3. Jos valitset värin:");
            Console.WriteLine("  ·Valitse \"punainen\" vai \"musta\".");
            Console.WriteLine("  ·Valitse panos 1-100 yksikköä.");
            Console.WriteLine();

            Console.WriteLine("Pelin aikana rahamäärä kasvaa tai pienenee. Et voi käyttää enemmän rahaa kuin sinulla on.");
            Console.WriteLine("Jos rahat loppuvat, peli päättyy.");
            Console.WriteLine();

            //Peliraha pelin alussa
            int raha = 100;
            string käyttäjänVastaus;
            bool ensimmäinenYritys = true;


            while (raha > 0)
            {

                //Tarkistetaan, haluaako käyttäjä lopettaa pelin
                if (ensimmäinenYritys == false)
                {
                    Console.WriteLine("Jos haluat lopettaa ja ottaa rahat, syötä \"loppu\". Jos haluat jatkaa peliä, syötä jokin muu sana");
                    Console.Write("> ");
                    käyttäjänVastaus = Console.ReadLine();

                    if (käyttäjänVastaus == "loppu")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sait pelin päätökseen. Sinulla on " + raha + " yksikköä pelin sisäistä rahaa.");
                        break;
                    }

                    Console.WriteLine();

                }

                ensimmäinenYritys = false;

                //Käyttäjä valitsee mitä hän halua valita: väri tai numero

                Console.WriteLine("Valitse, haluatko valita numeron vai värin:");
                Console.WriteLine(" ·Kirjoita \"numero\", jos haluat valita numeron.");
                Console.WriteLine(" ·Kirjoita \"väri\", jos haluat valita värin.");
                Console.Write("> ");

                //Functio tarkistaa käyttäjän vastaus (väri vai numero)
                string valinta = VäriVaiNumero();


                //Jos käyttäjä valitsee numeron
                if (valinta == "numero")
                {
                    //Käyttäjä valitsee numeron
                    Console.WriteLine("Valitse numero väliltä 0-36:");
                    Console.Write("> ");
                    int numero = NumeronValinta();


                    //Käyttäjä valitsee panoksen
                    Console.WriteLine("Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa. Valitse panos 1-" + raha + " yksikköä:");
                    Console.Write("> ");
                    int panos = PanoksenValinta(raha);
                    raha -= panos;

                    //Peli luo vittavan numeron
                    Random rnd = new Random();
                    int vittavaNumero = rnd.Next(0, 36);

                    Console.WriteLine("VittavaNumero on: " + vittavaNumero);

                    //Pelin tulos
                    if (numero == vittavaNumero)
                    {
                        raha = raha + panos * 36;
                        Console.WriteLine("Onnittelut! Arvasit numeron. Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa.");
                    }
                    else
                    {
                        Console.WriteLine("Voi ei! Et arvannut numeroa! Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa.");

                        if (raha == 0)
                        {
                            Console.WriteLine("Rahasi ovat loppu. Peli on ohi!");
                            break;
                        }
                    }


                }

                //Jos käyttäjä valitsee värin
                else
                {
                    //Käyttäjä valitsee värin
                    Console.WriteLine("Valitse punainen vai musta:");
                    Console.WriteLine(" ·Kirjoita \"1\", jos haluat valita punaisen.");
                    Console.WriteLine(" ·Kirjoita \"2\", jos haluat valita mustan.");
                    Console.Write("> ");
                    int värinNumero = VärinValinta();


                    //Käyttäjä valitsee panoksen
                    Console.WriteLine("Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa. Valitse panos 1-" + raha + " yksikköä:");
                    Console.Write("> ");
                    int panos = PanoksenValinta(raha);
                    raha -= panos;

                    //Peli luo vittavan numeron (värin numero)
                    Random rnd = new Random();
                    int vittavaNumero = rnd.Next(1, 2);

                    //Tulostetaan vittavan värin
                    if (vittavaNumero == 1)
                    {
                        Console.WriteLine("Vittava väri: punainen (1)");
                    }
                    else
                    {
                        Console.WriteLine("Vittava väri: musta (2)");
                    }


                    //Pelin tulos
                    if (värinNumero == vittavaNumero)
                    {
                        raha = raha + panos * 2;
                        Console.WriteLine("Onnittelut! Arvasit värin. Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa.");
                    }
                    else
                    {
                        Console.WriteLine("Voi ei! Et arvannut väriä! Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa.");

                        if (raha == 0)
                        {
                            Console.WriteLine("Rahasi ovat loppu. Peli on ohi!");
                            break;
                        }
                    }

                }

            }

            Console.ReadKey();

        }

        /*FUNKTIOT*/

        //Functio tarkistaa käyttäjän vastaus (väri vai numero)
        static string VäriVaiNumero()
        {
            //Käyttäjän vastaus 
            string vastaus = Console.ReadLine();
            Console.WriteLine();


            //Tarkastus 
            while (vastaus != "numero" && vastaus != "väri")
            {
                Console.WriteLine("Sinun pitää vastata 'numero' vai 'väri'.");
                Console.Write("> ");
                vastaus = Console.ReadLine();
            }

            return vastaus;
        }


        //Functio tarkistaa käyttäjän numero
        static int NumeronValinta()
        {
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Tarkastus
            while (numero < 0 || numero > 36)
            {
                Console.WriteLine("Et voi valita sitä numeroa. Valitse numero väliltä 0-36:");
                Console.Write("> ");
                numero = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            return numero;
        }


        //Funktio tarkistaa käyttäjän väri
        static int VärinValinta()
        {
            int värinNumero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Tarkastus
            while (värinNumero != 1 && värinNumero != 2)
            {
                Console.WriteLine("Et voi valita sitä väriä. Valitse numero \"1\" (punainen) vai \"2\" (musta)");
                Console.Write("> ");
                värinNumero = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            return värinNumero;
        }


        //Panoksen valinta
        static int PanoksenValinta(int raha)
        {
            int panos = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Vähennä rahamäärä vedonlyöntiyksiköiden lukumäärällä
            while (raha - panos < 0)
            {
                Console.WriteLine("Et voi käyttää enemmän rahaa kuin sinulla on. Valitse erilainen rahamäärä.");
                Console.WriteLine("Nyt sinulla on " + raha + " yksikköä pelin sisäistä rahaa. Sinun on valittava numero, joka on pienempi tai yhtä suuri kuin tämä numero.");
                Console.Write("> ");
                panos = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            return panos;
        }


    }
}
