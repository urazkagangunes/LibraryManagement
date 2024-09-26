using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        private List<Author> _authors;

        public AuthorRepository()
        {
            _authors = Authors();
        }

        public Author Add(Author created)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public Author? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Author? Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
