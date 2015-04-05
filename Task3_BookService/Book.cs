using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_BookService
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public string PublishedBy { get; private set; }

        public Book(String author, String title, int year, String publishedBy)
        {
            Author = author;
            Title = title;
            Year = year;
            PublishedBy = publishedBy;
        }

        public bool Equals(Book book)
        {
            if (book == null) return false;
            return (Author == book.Author) && (Title == book.Title) && (Year == book.Year) && (PublishedBy == book.PublishedBy);
        }

        public int CompareTo(Book arg)
        {
            if (this.Equals(arg)) return 0;
            else return this.Author.CompareTo(arg.Author);
        }
        //int IComparable.CompareTo(object arg)
        //{
        //    if (!(arg is Book)) throw new ArgumentException("Invalide type"); 
        //    return this.CompareTo((Book)arg);
        //}
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Book p = obj as Book;
            if (p == null)
            {
                return false;
            }
            return Equals(p);
        }

        public override int GetHashCode()
        {
            return Author.GetHashCode() + Title.GetHashCode() + Year + PublishedBy.GetHashCode();
        }

        public override string ToString()
        {
            return Author + ", " + Title + ", " + Year + ", Издательство: " + PublishedBy;
        }
    }
}
