using LibraryManagement.ConsoleUI.Models;
using System.Net.Cache;
using System.Xml.Linq;

namespace LibraryManagement.ConsoleUI.Repository
{
    public abstract class BaseRepository
    {
        List<Book> books = new List<Book>()
        {
            new Book(1, 1, 1, "Germinal","Kömür Madeni",341,"2012 Mayıs","9781234567897"),
            new Book(2, 1, 1, "Suç ve Ceza","Raskolnikov un hayatı",315,"2010 Haziran","9781234567891"),
            new Book(3, 1, 2, "Kumarbaz","Bir Öğretmenin hayatı",210,"2009 Ocak","9781234567892"),
            new Book(4, 2, 2, "Araba Sevdası","Arabayla alakası olmayan Kitap",180,"1999 Ocak","9781234567838"),
            new Book(5, 2, 3, "Ateşten Gömlek","Kurtulu savaşını anlatan kitap",120,"2001 Eylül","9781234567834"),
            new Book(6, 2, 3, "Kaşağı","Okunmaması gereken bir kitap",95,"1993 Ocak","9781234567845"),
            new Book(7, 3, 4, "28 Şampiyonluk","Hayal ürünüdür",350,"1907 Ocak ","9781234567807"),
            new Book(8, 3, 5, "16 Yıl Şampiyonluk","Hayal ürünüdür.",255,"10 Eylül","9781234567800"),
            new Book(9, 3, 6, "Ali Arı","Uyanık Ceo nun hikayesi",551,"20 Haziran","9781234567800")
        };

        List<Category> categories = new List<Category>()
        {
            new Category(1,"Dünya Klasikleri"),
            new Category(2,"Türk Klasikleri"),
            new Category(3,"Bilim Kurgu")
        };

        List<Author> authors = new List<Author>()
        {
            new Author(1,"Emile","Zola"),
            new Author(2,"Fyodor","Dostoyevski"),
            new Author(3,"Recaizade Mahmut","Ekrem"),
            new Author(4, "Halide Edib","Adıvar"),
            new Author(5,"Ömer","Seyfettin"),
            new Author(6,"Ali","Koç"),
            new Author(7,"Vız vız","Ali")
        };

        private List<Member> members = new List<Member>()
        {
            new Member(1, "Uraz", "GÜNEŞ", 25),
            new Member(2, "Kağan", "GÜNEŞ", 26)
        };
        public List<Book> Books()
        {
            return books; 
        }

        public List<Author> Authors()
        {
            return authors;
        }

        public List<Category> Categories()
        {
            return categories;
        }

        public List<Member> Members()
        {
            return members; 
        }
    }
}
