using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.ConsoleUI.Models;


namespace LibraryManagement.ConsoleUI.Repository
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
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
