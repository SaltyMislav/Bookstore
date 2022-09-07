using ConsoleDump;
using Rhetos;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Logging;
using Rhetos.Utilities;

ConsoleLogger.MinLevel = EventType.Info; // Use EventType.Trace for more detailed log.
string rhetosHostAssemblyPath = @"..\..\..\..\..\src\Bookstore.Service\bin\Debug\net6.0\Bookstore.Service.dll";
using (var scope = LinqPadRhetosHost.CreateScope(rhetosHostAssemblyPath))
{
    var context = scope.Resolve<Common.ExecutionContext>();
    var repository = context.Repository;

    var allBooks = repository.Bookstore.Book.Load().ToList();
    allBooks.Dump(); //Nisam siguran kako ostatak napravit da mi se pokaze samo title i autor, te ime autora bez da koristim .Select


    var query = repository.Bookstore.Book
        .Query()
        .Select(b => new { b.Title, b.Author.Name });

    // ToList will force Entity Framework to load the data from the database.
    var items = query.ToList();
    items.Dump();

    query.ToString().Dump();

    Console.WriteLine("Unesite broj knjiga koliko zelite unjest:");
    var NumberOfBooks = int.Parse(Console.ReadLine());

    /*for (int i = 0; i < NumberOfBooks; i++)
    {
        Console.WriteLine($"Unesite naslov {i+1}. knjige: ");
        var bookTitle = Console.ReadLine();

        var newBook = new Bookstore.Book { Code = i+1.ToString(), Title = bookTitle };

        repository.Bookstore.Book.Insert(newBook);
    }*/

    var actionParameter = new Bookstore.InsertBooks
    {
        NumberOfBooks = NumberOfBooks,
        TitlePrefix = "A Song of Ice and Fire"
    };

    repository.Bookstore.InsertBooks.Execute(actionParameter);
    scope.CommitAndClose();
}