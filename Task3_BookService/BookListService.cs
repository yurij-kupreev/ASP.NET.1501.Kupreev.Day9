using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task3_BookService
{
    public class BookListService
    {
        private IBookRepository bookRepository;
        private Logger logger;
        public BookListService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            logger = LogManager.GetCurrentClassLogger();
        }
        public void AddBook(Book book)
        {
            List<Book> bookList = null;
            try
            {
                bookList = (List<Book>)bookRepository.LoadBooks();
            }
            catch (Exception e)
            {
                logger.Error("Reading file error.");
                logger.Error(e.StackTrace);
            }

            if (bookList == null || book == null) throw new ArgumentNullException("null-parameters in AddBook");

            foreach (Book element in bookList)
            {
                if (element.Equals(book)) throw new ArgumentException("This book already exists.");
            }

            bookList.Add(book);

            try
            {
                bookRepository.SaveBooks(bookList);
            }
            catch (Exception e)
            {
                logger.Error("Writing file error.");
                logger.Error(e.StackTrace);
            }
        }

        public void SortBooks(IComparer<Book> compareLogic)
        {
            List<Book> bookList = null;
            try
            {
                bookList = (List<Book>)bookRepository.LoadBooks();
            }
            catch (Exception e)
            {
                logger.Error("Reading file error.");
                logger.Error(e.StackTrace);
            }
            if (bookList == null || compareLogic == null) throw new ArgumentNullException("null-parameters in SortBooks");
            bookList.Sort(compareLogic);
            try
            {
                bookRepository.SaveBooks(bookList);
            }
            catch (Exception e)
            {
                logger.Error("Writing file error.");
                logger.Error(e.StackTrace);
            }
        }

        public List<Book> GiveBooksToParameter(String author = null, String title = null, int year = 0, String publishedBy = null)
        {
            List<Book> bookList = null;
            try
            {
                bookList = (List<Book>)bookRepository.LoadBooks();
            }
            catch (Exception e)
            {
                logger.Error("Reading file error.");
                logger.Error(e.StackTrace);
            }
            if (author == null && title == null && year == 0 && publishedBy == null)
                throw new ArgumentNullException("null-parameters in GiveBooksToParameter");
            List<Book> newBookList = new List<Book>();
            foreach (Book element in bookList)
            {
                bool parameterEquals = true;
                if (author != null)
                    if (element.Author != author) { parameterEquals = false; continue; }
                if (title != null)
                    if (element.Title != title) { parameterEquals = false; continue; }
                if (year != 0)
                    if (element.Year != year) { parameterEquals = false; continue; }
                if (publishedBy != null)
                    if (element.PublishedBy != publishedBy) { parameterEquals = false; continue; }
                if (parameterEquals) newBookList.Add(element);
            }
            if (newBookList.Count == 0) throw new ArgumentException("There are no books with such specification in the store.");
            else return newBookList;
        }

        public List<Book> GetBookList()
        {
            List<Book> bookList = null;
            try
            {
                bookList = (List<Book>)bookRepository.LoadBooks();
            }
            catch (Exception e)
            {
                logger.Error("Reading file error.");
                logger.Error(e.StackTrace);
            }
            return bookList;
        }
    }
}
