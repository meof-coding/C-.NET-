using ODataBookStore.EDM;

namespace ODataBookStore
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }

        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }
            listBooks = new List<Book>();
            Book book = new Book
            {
                Id = 1,
                ISBN = "123-4-56-7-89-0",
                Title = "Book 1",
                Author = "Author 1",
                Price = 14.597m,
                Location = new Address
                {
                    City = "City 1",
                    Street = "Street 1",
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Press 1",
                    Category = Category.Book,
                }
            };
            listBooks.Add(book);
            book = new Book
            {
                Id = 2,
                ISBN = "123-4-56-7-89-1",
                Title = "Book 2",
                Author = "Author 2",
                Price = 14.597m,
                Location = new Address
                {
                    City = "City 2",
                    Street = "Street 2",
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "Press 2",
                    Category = Category.Book,
                }
            };
            listBooks.Add(book);
            book = new Book
            {
                Id = 3,
                ISBN = "123-4-56-7-89-2",
                Title = "Book 3",
                Author = "Author 3",
                Price = 14.597m,
                Location = new Address
                {
                    City = "City 3",
                    Street = "Street 3",
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "Press 3",
                    Category = Category.Book,
                }
            };
            listBooks.Add(book);
            return listBooks;
        }
    }
}
