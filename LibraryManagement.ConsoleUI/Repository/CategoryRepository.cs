using LibraryManagement.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ConsoleUI.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private List<Category> _category;

        public CategoryRepository()
        {
            _category = Categories();
        }

        public Category Add(Category created)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category? GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Category? Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
