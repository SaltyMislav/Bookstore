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
}