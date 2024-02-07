using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MtgClient;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("--- Démarrage...");
        Client client = new Client();
        await client.ReadRandomCards();
        Console.WriteLine("--- Fin !");
    }
}