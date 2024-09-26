using LibraryManagement.ConsoleUI.Dtos;
using LibraryManagement.ConsoleUI.Models;

namespace LibraryManagement.ConsoleUI.Repository;

public class BookRepository : BaseRepository, IBookRepository
{
    //Language Integrated Query
    private List<Book> books;
    private List<Category> categories;
    private List<Author> authors;
    public BookRepository()
    {
        categories = Categories();
        authors = Authors();
        books = Books();
    }
    public List<Book> GetAllBooksByPageSizeFilter(int min, int max)
    {
        //Geleneksel Yöntem

        //List<Book> filteredBooks = new List<Book>();

        //foreach (Book book in books)
        //{
        //    if (book.PageSize <= max && book.PageSize >= min)
        //    {
        //        filteredBooks.Add(book);
        //    }
        //}
        //return filteredBooks;


        //LİNQ Geleneksel Yöntem

        //List<Book> result = (from b in books
        //                    where b.PageSize <= max && b.PageSize > min
        //                    select b).ToList();
        //return result;


        //LİNQ Yeni Yöntem

        //List<Book> result = books.Where(b => b.PageSize <= max && b.PageSize > min).ToList();
        //return result;

        List<Book> result = books.FindAll(b => b.PageSize <= max && b.PageSize > min);
        return result;
    }
    public double PageSizeTotalCalculator()
    {
        double total = books.Sum(x=> x.PageSize);
        return total;
    }
    public List<Book> GetAllBooksByTitleContains(string text)
    {
        //List<Book> filteredBooks = new List<Book> ();

        //foreach (Book book in books)
        //{
        //    if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        filteredBooks.Add(book);
        //    }
        //}
        //return filteredBooks;

        List<Book> result = books.FindAll(x => x.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase)); 
        return result;
    }
    public Book? GetBookByISBN(string isbn)
    {
        //Book? book1 = null;
        //foreach(Book item in books)
        //{
        //    if(item.ISBN == isbn)
        //    {
        //        book1 = item;
        //    }
        //}
        //if(book1 is null)
        //{
        //    return null; 
        //}

        //return book1;

        //Geleneksel LİNQ
        //Book book = (from b in books
        //            where b.ISBN == isbn
        //            select b).FirstOrDefault();
        //return book;

        //Yeni LİNQ
        //Book book = books.Where(x => x.ISBN == isbn).SingleOrDefault();
        //return book;

        Book book = books.SingleOrDefault(x => x.ISBN == isbn);
        return book;

    }
    public List<Book> GetAllBookOrderByTitle()
    {
        List<Book> orderedBook = books.OrderBy(b => b.Title).ToList();
        return orderedBook;
    }
    public List<Book> GetAllBookOrderByDESCTitle()
    {
        List<Book> orderedBook = books.OrderByDescending(b => b.Title).ToList();
        return orderedBook;
    }

    //public Book sayfa sayısı en çok olan kitabı dön
    public Book GetBookMaxPageSize()
    {
        Book maxPageSizeBook = books.OrderBy(x => x.PageSize).LastOrDefault();
        return maxPageSizeBook;
    }
    public Book GetBookMinPageSize()
    {
        Book minPageSizeBook = books.OrderByDescending(x => x.PageSize).LastOrDefault();
        return minPageSizeBook;
    }
    //Old Style Of Join
    public List<BookDetailDto> GetDetails()
    {
        var result =
            from b in books
            join c in categories
            on b.CategoryId equals c.Id
            select new BookDetailDto(
                Id: b.Id,
                CategoryName: c.Name,
                "",
                Title: b.Title,
                Description: b.Description,
                PageSize: b.PageSize,
                PublishDate: b.PublishDate,
                ISBN: b.ISBN
                );

        return result.ToList();
    }
    //New Style Of Join
    public List<BookDetailDto> GetDetailsV2()
    {
        List<BookDetailDto> details = 
            books.Join(categories, 
            
            b => b.CategoryId,
            c => c.Id,
            (book, category) => new BookDetailDto(
                Id: book.Id,
                CategoryName: category.Name,
                "",
                Title: book.Title,
                Description: book.Description,
                PageSize: book.PageSize,
                PublishDate: book.PublishDate,
                ISBN: book.ISBN
                )
            ).ToList();
        return details;
    }

    public List<BookDetailDto> GetAllAuthorAndBookDetails()
    {
        var result =
            from b in books
            join c in categories on b.CategoryId equals c.Id
            join a in authors on b.AuthorId equals a.Id
            select new BookDetailDto(
                Id: b.Id,
                CategoryName: c.Name,
                AuthorName: $"{a.Name} {a.Surname}",
                Title: b.Title,
                Description: b.Description,
                PageSize: b.PageSize,
                PublishDate: b.PublishDate,
                ISBN: b.ISBN
                );
        return result.ToList();
    } 

    //Categori id ile eşleşesen bütün kitaplar geeeeslin
    public List<BookDetailDto> GetAllDetailsByCategoryId(int categoryId)
    {
        var result =
            from b in books
            where b.CategoryId == categoryId
            join c in categories on b.CategoryId equals c.Id
            join a in authors on b.AuthorId equals a.Id
            select new BookDetailDto(
                Id: c.Id,
                CategoryName: $"{c.Id} = {c.Name}",
                AuthorName: a.Name,
                Title: b.Title,
                Description: b.Description,
                PageSize: b.PageSize,
                PublishDate: b.PublishDate,
                ISBN: b.ISBN
                );
        return result.ToList();
    }
    public List<string> GetAllTitles()
    {
        List<string> titles = 
            books.Select( x => x.Title ).ToList();
        return titles;
    }

    public Book Add(Book created)
    {
        throw new NotImplementedException();
    }

    public Book? GetByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public Book? Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Book> GetAll()
    {
        throw new NotImplementedException();
    }
}
