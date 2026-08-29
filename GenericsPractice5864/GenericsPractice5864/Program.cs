using GenericsPractice5864.ApiExample;
using GenericsPractice5864.MessageApi;

namespace GenericsPractice5864
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var delivery = Delivery<Box<Create<string>>>.Success(
            //    new Box<Create<string>>(
            //        new Create<string>(
            //            new List<string> {
            //                "test", "test2" })));


            //Console.WriteLine(delivery.Arrived);
            //Console.WriteLine(delivery.Package.Contents.Counts);

            //Console.WriteLine(string.Join(Environment.NewLine,
            //    delivery.Package.Contents.Items));


            //var book = ApiResponse<Book>.Success(
            //    new Book("Dune", new Author("Frank Herbert", 20), 1965));


            //Console.WriteLine(book.IsValid);
            //Console.WriteLine(book.Value!.Title);

            //List<Book> allBooks = new()
            //{
            //    new Book("Dune", new Author("Frank Herbert", 20), 1965),
            //    new Book("1984", new Author("George Orwell", 25), 1949),
            //    new Book("The Hobbit", new Author("J.R.R. Tolkien", 30), 1937),
            //    new Book("The Great Gatsby", new Author("F. Scott Fitzgerald", 22), 1925),
            //    new Book("To Kill a Mockingbird", new Author("Harper Lee", 18), 1960),
            //    new Book("Pride and Prejudice", new Author("Jane Austen", 28), 1813),
            //    new Book("Fahrenheit 451", new Author("Ray Bradbury", 35), 1953),
            //    new Book("The Catcher in the Rye", new Author("J.D. Salinger", 15), 1951),
            //    new Book("Brave New World", new Author("Aldous Huxley", 32), 1932),
            //    new Book("The Alchemist", new Author("Paulo Coelho", 27), 1988)
            //};


            //int page = 1;
            //int pageSize = 3;
            //var pageItems = allBooks.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //var pagedBooks = new PagedList<Book>(pageItems, page, pageSize, allBooks.Count);
            //var response = ApiResponse<PagedList<Book>>.Success(pagedBooks);

            //Console.WriteLine(response.IsValid);
            //Console.WriteLine(response.Value!.Items[0].Author.Name);
            //Console.WriteLine($"Page {response.Value!.Page} of {response.Value.TotalPages}");
            //foreach (var book in response.Value.Items)
            //    Console.WriteLine(book.Title);


            //var message = SendResult<ChatMessage>.Ok(
            //    new ChatMessage("Jim", "Hey", DateTime.UtcNow));

            //Console.WriteLine(message.Delivered);


            var result = SendResult<Thread<ChatMessage>>.Ok(
                new Thread<ChatMessage>(new List<ChatMessage>
                { new ChatMessage("Jane","Hello", DateTime.UtcNow)}, 5));


            Console.WriteLine(result.Delivered);
            Console.WriteLine(string.Join(Environment.NewLine, 
                result.Payload!.Messages));


            Console.ReadLine();
        }
    }
}
