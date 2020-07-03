using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artikli1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Artikal> Magacin = new List<Artikal>();

			string izbor = "";
			while (izbor != "5")
			{
				PrikaziMeni();
				izbor = Console.ReadKey().KeyChar.ToString();
				Console.WriteLine();

				switch (izbor)
				{
					case "1":
						Unos(Magacin);
						break;
					case "2":
						foreach (Artikal a in Magacin)
						{
							Console.WriteLine($"{a.sifra} {a.naziv} {a.cena}");
						}
						break;
					case "3":
						Pretraga(Magacin);
						break;
					case "4":
						Brisanje(Magacin);
						break;
					case "5":
						Console.WriteLine("Vidimo se :)");
						break;
					default:
						Console.WriteLine("Pogresna opcija :(");
						break;
				}
			}


			Console.ReadKey();

		}

		static void Unos(List<Artikal> Proizvod)
		{
			Artikal a = new Artikal();

			Console.Write("Unesite sifru: ");
			a.sifra = Console.ReadLine();
			Console.Write("Unesite naziv: ");
			a.naziv = Console.ReadLine();

			Console.Write("Unesite cenu: ");
			a.cena = decimal.Parse(Console.ReadLine());

			Proizvod.Add(a);
		}

		static void Pretraga(List<Artikal> Proizvod)
		{
			Console.Write("Unesite naziv ili sifru artikla: ");
			string pretraga = Console.ReadLine();

			foreach (Artikal a in Proizvod)
			{
				if (a.naziv.ToLower().Contains(pretraga.ToLower()) || a.sifra.ToLower().Contains(pretraga.ToLower()))
				{
					Console.WriteLine($"{a.sifra} {a.naziv} {a.cena}");
				}
			}

			
		}

		static void Brisanje(List<Artikal> Proizvod)
		{

			Console.Write("Unesite naziv ili sifru proizvoda: ");
			string pretraga = Console.ReadLine();

			Artikal zaBrisanje = null;

			foreach (Artikal a in Proizvod)
			{
				if (a.naziv.ToLower().Contains(pretraga.ToLower()) || a.sifra.ToLower().Contains(pretraga.ToLower()))
				{
					Console.WriteLine($"Da li zelite da obrisete: {a.sifra} {a.naziv} {a.cena}? (d/n)");
					string unos = Console.ReadKey().KeyChar.ToString();
					if (unos == "d")
					{
						zaBrisanje = a;
						break;
					}
				}
			}

			Proizvod
				.Remove(zaBrisanje);
		}

		static void PrikaziMeni()
		{
			Console.WriteLine("1 --- Unos");
			Console.WriteLine("2 --- Pregled");
			Console.WriteLine("3 --- Pretraga");
			Console.WriteLine("4 --- Ukloni");
			Console.WriteLine("5 --- Izlaz");
			Console.WriteLine("---------------");
			Console.Write("Unesite izbor: ");
		}
	}

    class Artikal
    {
        public string sifra;
        public string naziv;
        public decimal cena;

        public Artikal (string s, string n, decimal c)
        {
            sifra = s;
            naziv = n;
            cena = c;
        }
		public Artikal() { }
	}
}
