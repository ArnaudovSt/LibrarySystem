using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Repositories;

namespace LibrarySystem.Services.Data
{
    public class UserService
    {
        private readonly IEfRepostory<User> userRepository;

        public UserService(IEfRepostory<User> userRepository)
        {
            Guard.WhenArgument(userRepository, "User Repository").IsNull().Throw();
            this.userRepository = userRepository;
        }

        public void AddBook(Guid userId, Book book)
        {
            this.userRepository.All.FirstOrDefault(u => u.Id == userId.ToString())?.WantToRead.Add(book);
        }
    }
}
