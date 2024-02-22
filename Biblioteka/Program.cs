using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Program
    {
        static void Main(string[] args) 
        {
            Library library1 = new Library();
            Borrow borrow1 = new Borrow();
            Reader reader1 = new Reader();

            Book book1 = new Book("Odwet", "Moe Gerni", 1678, 670, true);
            Book book2 = new Book("Dzieje", "Pablo Pablo", 1669, 51, true);
            Book book3 = new Book("Pokonaj mnie!", "Ejczu Ebezoga", 2015, 320, true);
            Book book4 = new Book();
            Book book5 = new Book();
            Book book6 = new Book();
            Book book7 = new Book();
            Book book8 = new Book();
            Book book9 = new Book();
            Book book10 = new Book();
            Book book11 = new Book();
            //book1.ShowInfo();
            library1.AddBook(book1);
            library1.AddBook(book2);
            library1.AddBook(book3);
            library1.SearchBook("1669");

            /*foreach (Book book in library1.books)
            {
                Console.WriteLine(book.Tytul + ", " + book.Autor + ", " + book.RokWydania + ", " + book.LiczbaStron + ", " + book.Dostepna);
            }*/

            /*reader1.BorrowBook(book1);
            Console.WriteLine(book1.Dostepna);

            reader1.ReturnBook(book1);
            reader1.ReturnBook(book2);

            Console.WriteLine(reader1.BDate);
            Console.WriteLine(reader1.WhenTR);
            Console.WriteLine(reader1.RDate);
            Console.WriteLine(library1.books.Count);*/

            /*reader1.BorrowBook(book1);
            reader1.BorrowBook(book2);
            reader1.BorrowBook(book3);
            reader1.BorrowBook(book4);
            reader1.BorrowBook(book5);
            reader1.BorrowBook(book6);
            reader1.BorrowBook(book7);
            reader1.BorrowBook(book8);
            reader1.BorrowBook(book9);
            reader1.BorrowBook(book10);
            reader1.BorrowBook(book11);*/

            Console.ReadKey();
        }
    }
}
