using GraphQLPoC.Entities;

namespace GraphQLPoC.Queries
{
    public class Query
    {
        public Book GetBook() =>
            new Book
            {
                Title = "C# in depth.",
                //Author = new Author
                //{
                //    Name = "Jon Skeet"
                //}
            };

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Entities.Book> GetBooks([Service] bookshelfContext context)
        {
            return context.Books;
        }
    }
}
