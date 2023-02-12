using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Verseny
{
    internal class Program
    {
        static List<VersenyClass> lista_Verseny = new List<VersenyClass>();
        static string fajlnev = "versenyek.txt";
        static int srsz;
        static int hely = 0;

        static void Beker()
        {
            string benev = "a";
            while (benev != "")
            {
                Console.Clear();
                Console.WriteLine("==========   A D A T O K   B E K É R É S E   ==========");
                Console.WriteLine("2. feladat:");
                Console.WriteLine("Kérem a versenyző nevét (Üres jelre kilép)!");
                benev = Console.ReadLine();

                if (benev == "")
                {
                    Console.WriteLine("Visszalépés főmenübe...");
                }
                else
                {
                    VersenyClass versenyzo = new VersenyClass();
                    versenyzo.nev = benev;

                    Console.WriteLine("Kérem a tantárgy nevét!");
                    versenyzo.tantargy = Console.ReadLine();

                    int beszazalek = 0;
                    int van = 0;
                    
                    do
                    {
                        Console.WriteLine("Kérem az elért százalékos eredményt (0-100)!");
                        beszazalek = Convert.ToInt32(Console.ReadLine());
                        if (beszazalek >= 0 || beszazalek <= 100)
                        {
                            van = 1;
                        }
                    }
                    while (van != 1);
                    versenyzo.szazalek = beszazalek;
                    srsz++;
                    versenyzo.azon = srsz;
                    Console.WriteLine("Versenyző azonosítója: " + Convert.ToString(versenyzo.azon));
                    lista_Verseny.Add(versenyzo);
                    Console.ReadKey();

                }
                
            }
            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiiratása: ");
            foreach (VersenyClass a in lista_Verseny)
            {
                Console.WriteLine(Convert.ToString(a.azon) + "\t" + a.nev + "\t" + a.tantargy + "\t" + Convert.ToString(a.szazalek));
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void ListaDarabszama()
        {
            Console.Clear();
            Console.WriteLine("==========   L I S T A     D A R A B S Z Á M A   ==========");
            Console.WriteLine("3. feladat:");
            Console.WriteLine("Határozza meg és írja ki a képernyőre, hogy hány diák adatai kerültek rögzítésre!");
            Console.WriteLine(Convert.ToString(lista_Verseny.Count));

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void ListaAtlag()
        {
            int osszeg = 0;
            Console.Clear();
            Console.WriteLine("==========   L I S T A     Á T L A G A   ==========");
            Console.WriteLine("4. feladat:");
            Console.WriteLine("Határozza meg és írja ki a képernyőre, hogy a versenyzőknek mennyi volt az átlagos elért százaléka! Az átlagot az összes diák százalékából számoljuk. Az átlagot egy tizedesjegyre kerekítve jelenítse meg!");
            for (int i = 0; i < lista_Verseny.Count; i++)
            {
                osszeg = osszeg + lista_Verseny[i].szazalek;
            }
            Console.WriteLine("Versenyzők átlagos elért százaléka: " + Convert.ToString(osszeg / lista_Verseny.Count));

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void LegjobbEredmeny()
        {
            int max = 0;
            int maxhely = 0;
            Console.Clear();
            Console.WriteLine("==========   L E G J O B B     E R E D M É N Y   ==========");
            Console.WriteLine("5. feladat:");
            Console.WriteLine("Keresse meg, hogy melyik diáknak volt a legnagyobb elért százaléka a bekért adatok között, írja ki az összes hozzátartozó adatot is!");
            for(int i = 0; i < lista_Verseny.Count; i++)
            {
                if (lista_Verseny[i].szazalek > max)
                {
                    max = lista_Verseny[i].szazalek;
                    maxhely = i;
                }
            }
            Console.WriteLine(Convert.ToString(lista_Verseny[maxhely].azon) + "\t" + lista_Verseny[maxhely].nev + "\t" + lista_Verseny[maxhely].tantargy + "\t" + Convert.ToString(lista_Verseny[maxhely].szazalek));

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void ListaKiiratasa()
        {
            Console.Clear();
            Console.WriteLine("==========   L I S T A     K I I R A T Á S A   ==========");
            Console.WriteLine("6. feladat:");
            Console.WriteLine("!");

            // Lista kiiratása
            Console.WriteLine("Lista elemeinek kiiratása: ");
            foreach (VersenyClass a in lista_Verseny)
            {
                Console.WriteLine(Convert.ToString(a.azon) + ";" + a.nev + ";" + a.tantargy + ";" + Convert.ToString(a.szazalek));
            }

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Fajlbair()
        {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B A   Í R Á S   ==========");
            Console.WriteLine("7. feladat:");
            Console.WriteLine("Készítsen új UTF-8 kódolású állományt versenyek.txt néven a versenyzők adataiból!");
            StreamWriter kiir = new StreamWriter(fajlnev);
            // Lista kiiratása fájlba
            Console.WriteLine("Lista elemeinek kiírása fájlba... ");
            foreach (VersenyClass a in lista_Verseny)
            {
                kiir.WriteLine(Convert.ToString(a.azon) + ";" + a.nev + ";" + a.tantargy + ";" + Convert.ToString(a.szazalek));
            }
            kiir.Flush();
            kiir.Close();

            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Buborek()
        {
            Console.WriteLine("\n==========   B U B O R É K   ==========");
            Console.WriteLine("9. feladat:");
            for (int i = srsz - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (lista_Verseny[j].szazalek > lista_Verseny[j + 1].szazalek)
                    {
                        int temp = lista_Verseny[j].szazalek;
                        lista_Verseny[j].szazalek = lista_Verseny[j + 1].szazalek;
                        lista_Verseny[j + 1].szazalek = temp;
                    }
                }
            }

            foreach (VersenyClass a in lista_Verseny)
            {
                Console.WriteLine(Convert.ToString(a.azon) + ";" + a.nev + ";" + a.tantargy + ";" + Convert.ToString(a.szazalek));
            }

            for (int i = 0; i < srsz; i++)
            {
                Console.Write(Convert.ToString(lista_Verseny[i].szazalek) + " *** ");
            }
            Console.Write("\nTovább...");
            Console.ReadKey();
        }

        static void Fajlbolbe()
        {
            Console.Clear();
            Console.WriteLine("\n==========   F Á J L B Ó L   B E O L V A S Á S   ==========");
            Console.WriteLine("10. feladat:");
            StreamReader beolvas = new StreamReader(fajlnev, Encoding.UTF8);
            Console.WriteLine("Lista elemeinek beolvasása fájlból... ");
            // IDE JÖN A BEOLVASÁS
            string s;
            var egyeblista = new List<string[]>();

            while ((s = beolvas.ReadLine()) != null)
            {
                Console.WriteLine(Convert.ToString(s));
                egyeblista.Add(s.Split(';'));
            }

            foreach (string[] a in egyeblista)
            {
                Console.WriteLine(a);
                VersenyClass versenyzo = new VersenyClass();
                versenyzo.azon = Convert.ToInt32(a[0]);
                versenyzo.nev = a[1];
                versenyzo.tantargy = a[2];
                versenyzo.szazalek = Convert.ToInt32(a[3]);
                lista_Verseny.Add(versenyzo);
            }

            // BEOLVASÁS VÉGE
            beolvas.Close();


            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void KeresesDiak()
        {
            Console.Clear();
            Console.WriteLine("\n==========   K E R E S É S     D I Á K R A   ==========");
            Console.WriteLine("11. feladat:");
            Console.Write("Kérem a keresendő diák nevét! ");
            string keres_nev = Console.ReadLine();
            bool megvan = false;
            int hely = 0;

            for (int i = 0; i < srsz; i++)
            {
                if (keres_nev == lista_Verseny[i].nev)
                {
                    megvan = true;
                    hely = i;
                }
            }

            if (megvan == true)
            {
                Console.WriteLine("Megvan!");
                Console.WriteLine(lista_Verseny[hely].nev + "\t" + Convert.ToString(lista_Verseny[hely].szazalek));
            }
            else
            {
                Console.WriteLine("Nincs ilyen nevű diák!");
            }
            Console.Write("\nVisszalépés főmenübe...");
            Console.ReadKey();
            Fomenu();
        }

        static void Fomenu()
        {
            Console.Clear();
            Console.WriteLine("==========   F Ő M E N Ű   ==========");
            Console.WriteLine("2., Adatok bekérése");
            Console.WriteLine("3., Lista darabszáma");
            Console.WriteLine("4., Versenyzők átlagos elért százaléka");
            Console.WriteLine("5., Legjobb eredmény");
            Console.WriteLine("6., Lista kiiratása");
            Console.WriteLine("7., Fájlba írás");
            Console.WriteLine("9., Buborék");
            Console.WriteLine("10., Fájlból betöltés");
            Console.WriteLine("11., Keresés diákra");
            Console.WriteLine("0., Kilépés");
            string menupont = Console.ReadLine();
            switch (Convert.ToInt32(menupont))
            {
                case 2:
                    Beker();
                    break;
                case 3:
                    ListaDarabszama();
                    break;
                case 4:
                    ListaAtlag();
                    break;
                case 5:
                    LegjobbEredmeny();
                    break;
                case 6:
                    ListaKiiratasa();
                    break;
                case 7:
                    Fajlbair();
                    break;
                case 9:
                    Buborek();
                    break;
                case 10:
                    Fajlbolbe();
                    break;
                case 11:
                    KeresesDiak();
                    break;
                case 0:
                    return;
                default:
                    return;
            }
        }

        static void Main(string[] args)
        {
            Fomenu();
        }
    }
}
