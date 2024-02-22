using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Book
    {
        //jezeli chcemy kategorie, to nie tworzymy kurwa nastepnej funkcji, tylko mozemy tutaj dodac atrybut
        public string Tytul;
        public string Autor;
        public int RokWydania;
        public int LiczbaStron;
        public bool Dostepna;

        public Book()
        {
            Tytul = "Brak";
            Autor = "Brak";
            RokWydania = 0;
            LiczbaStron = 0;
            Dostepna = true;
        }

        public Book(string tytul, string autor, int rok, int liczba, bool dostepna)
        {
            Tytul = tytul;
            Autor = autor;
            RokWydania = rok;
            LiczbaStron = liczba;
            Dostepna = dostepna;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Tytul + ", " + Autor + ", " + RokWydania + ", " + LiczbaStron);
        }

        public void ModifyInfo()
        {
            Console.WriteLine("Ile zmiennych będziesz modyfikował? (max 4)");
            int x = int.Parse(Console.ReadLine());
            if (x>4)
            {
                Console.WriteLine("Podales za duza liczbe.");
            }
            else
            {
                for(int i=1; i==x; i++)
                {
                    Console.WriteLine("Dane ktorej zmiennej bedziesz modyfikowal? (tytul, autor, rok wydania, liczba stron)");
                    string zmiennam = Console.ReadLine();
                    if (zmiennam.ToLower() == "tytul")
                    {
                        Console.WriteLine("Podaj tytul: ");
                        Tytul = Console.ReadLine();
                    }
                    else if (zmiennam.ToLower() == "autor")
                    {
                        Console.WriteLine("Podaj autora: ");
                        Autor = Console.ReadLine();
                    }
                    else if (zmiennam.ToLower() == "rok wydania")
                    {
                        Console.WriteLine("Podaj rok wydania: ");
                        RokWydania = int.Parse(Console.ReadLine());
                    }
                    else if (zmiennam.ToLower() == "liczba stron")
                    {
                        Console.WriteLine("Podaj liczbe stron: ");
                        LiczbaStron = int.Parse(Console.ReadLine());
                    }
                    else
                        Console.WriteLine("Wprowadzona zla nazwe zmiennej");
                }
            }
        }
    }
    class PaperBook : Book
    {

    }
    class EBook : Book
    {

    }
    class Library : Book
    {
        public List<Book> books;
        public Library()
        {
            books = new List<Book>();
        }
        public void AddBook(Book obj)
        {
            books.Add(obj);
        }
        public void RemoveBook(Book obj)
        {
            books.Remove(obj);
        }
        public void SearchBook(string wyszukiwane) //Try catch, bo w pierwszej wersji metody, string z inputa był konwertowany na int i to wywalało exception
        {
            for (int i = 0; i < books.Count(); i++)
            {
                try
                {
                    if (books[i].RokWydania == Convert.ToInt32(wyszukiwane))
                    {
                        books[i].ShowInfo();
                    }
                    else if (books[i].LiczbaStron == Convert.ToInt32(wyszukiwane))
                    {
                        books[i].ShowInfo();
                    }
                }
                catch
                {

                }
                finally
                {
                    if (books[i].Tytul == wyszukiwane)
                    {
                        books[i].ShowInfo();
                    }
                    else if (books[i].Autor == wyszukiwane)
                    {
                        books[i].ShowInfo();
                    }
                }
            }
        }
    }
    class Reader : Library
    {
        public string Imie;
        public string Nazwisko;
        public string NumerKarty;
        public string BDate;
        public string RDate;
        public DateTime WhenTR; //When to return
        public List<Book> wyporzyczenia;

        public Reader()
        {
            wyporzyczenia = new List<Book>();
        }

        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
        public void BorrowBook(Book obj) //Metoda przypisuje date wyporzyczenia, zmienia dostepnosc i dodaje ksiazke do listy wyporzyczonych
        {
            if (obj.Dostepna == true && wyporzyczenia.Count < 10)
            {
                DateTime date = GetCurrentDate();
                BDate = date.ToString("dd - MM - yyyy");
                WhenTR = date.AddDays(10);  //W tej bibliotece masz 10 dni na zwrot ksiazki

                obj.Dostepna = false;
                wyporzyczenia.Add(obj);
                Console.WriteLine("Ksiazka zostala wyporzyczona.");
            }
            //ksiazka musi byc dostepna, a limit wyporzyczen wynosi 10 ksiazek
            else if (Dostepna == false || wyporzyczenia.Count == 10)
            {
                Console.WriteLine("Ksiazka niedsotepna do wyporzyczenia.");
            }
        }
        public void ReturnBook(Book obj)
        {
            if (wyporzyczenia.Contains(obj))
            {
                DateTime date = GetCurrentDate();
                RDate = date.ToString("dd - MM - yyyy");

                obj.Dostepna = true;
                wyporzyczenia.Remove(obj);
                Console.WriteLine("Oddales ksiazke.");
            }
            else
            {
                Console.WriteLine("Nie udalo Ci sie oddac ksiazki.");
            }
        }
    }
    class Borrow : Reader
    {
        //!stringi nie przechowują dat!!!!!!!!!!!
        public string BorrowDate;
        public string ReturnDate;
        public void LongerBorrow(double days)
        {
            WhenTR.AddDays(days);
        }
    }
}
