namespace Lb_2.Models
{
    public class Libary
    {
        private List<Book> books;

        public Libary()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(book => book.Author == author).ToList();
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(book => book.Title == title).ToList();
        }

        public List<Book> SearchByYear(int year)
        {
            return books.Where(book => book.Year == year).ToList();
        }
    }
}