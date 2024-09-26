using LibraryManagement.ConsoleUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.ConsoleUI.Models;
using LibraryManagement.ConsoleUI.Dtos;


namespace LibraryManagement.ConsoleUI.Service
{
    public class BookService
    {

        BookRepository bookRepository = new BookRepository();

        public void GetAll()
        {
            List<Book> books = bookRepository.GetAll();

            foreach (Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public void GetById(int id)
        {
            Book? book = bookRepository.GetByID(id);
            if (book == null)
            {
                Console.WriteLine($"Aradığınız id ye göre kitap bulunamadı: {id}");
                return;
            }

            Console.WriteLine(book);
        }

        public void Remove(int id)
        {
            Book? deletedBook = bookRepository.Remove(id);
            if (deletedBook == null)
            {
                Console.WriteLine("Aradığınız kitap bulunamadı.");
                return;
            }
            Console.WriteLine(deletedBook);
        }

        public void GetBookByISBN(string isbn)
        {
            Book? book = bookRepository.GetBookByISBN(isbn);

            if (book == null)
            {
                Console.WriteLine($"Aradığınız ISBN numarasına göre kitap bulunamadı.{isbn}");
                return;
            }
            Console.WriteLine(book);
        }

        public void Add(Book book)
        {
            BookIdBusinessRules(book.Id);
            BookISBNBusinessRules(book.ISBN);
            
            Book created = bookRepository.Add(book);
            Console.WriteLine($"Kitap eklendi: {created}");
        }

        public void GetAllBooksByTitleContains(string text)
        {
            List<Book> books = bookRepository.GetAllBooksByTitleContains(text);
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void GetAllBooksByPageSizeFilter(int min, int max)
        {
            List<Book> books = bookRepository.GetAllBooksByPageSizeFilter(min, max);
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void GetAllBookOrderByTitle()
        {
            List<Book> books = bookRepository.GetAllBookOrderByTitle();
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void GetAllBookOrderByDESCTitle()
        {
            List<Book> books = bookRepository.GetAllBookOrderByDESCTitle();
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
        }

        public void GetAllBookMaxPageSize()
        {
            Book maxPageSize = bookRepository.GetBookMaxPageSize();
            Console.WriteLine(maxPageSize);
        }

        public void GetAllBookMinPageSize()
        {
            Book minPageSize = bookRepository.GetBookMinPageSize();
            Console.WriteLine(minPageSize);
        }

        public void GetDetails()
        {
            List<BookDetailDto> books = bookRepository.GetDetails();
            foreach (BookDetailDto bookDetail in books)
            {
                Console.WriteLine(bookDetail);
            }
        }

        public void GetDetailsV2()
        {
            List<BookDetailDto> books = bookRepository.GetDetailsV2();
            foreach (BookDetailDto bookDetail in books) 
            { 
                Console.WriteLine(bookDetail); 
            }
        }

        public void GetAllBookAndAuthorDetails()
        {
            List<BookDetailDto> details = bookRepository.GetAllAuthorAndBookDetails();
            details.ForEach(x => Console.WriteLine(x));
            
            //foreach(BookDetailDto bookDetail in details)
            //{
            //    Console.WriteLine(bookDetail);
            //}
        }

        public void GetAllBookByCategoryId(int categoryId)
        {
            List<BookDetailDto> details = bookRepository.GetAllDetailsByCategoryId(categoryId);
            details.ForEach(i => Console.WriteLine(i));
        }
        
        private void BookIdBusinessRules(int id)
        {
            Book? getByIdBook = bookRepository.GetByID(id);
            if (getByIdBook != null)
            {
                Console.WriteLine($"Girmiş olduğunuz kitabın id alanı BENZERSİZ olmalıdır: {id}");
                return;
            }
        }

        private void BookISBNBusinessRules(string isbn)
        {
            Book? getBookByISBN = bookRepository.GetBookByISBN(isbn);
            if (getBookByISBN != null)
            {
                Console.WriteLine($"Girmiş olduğunuz kitabın ISBN alanı benzersiz olmalıdır: {isbn}");
                return;
            }
        }
    }
}
