using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using MtgClient;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("--- Démarrage...");
        Client client = new Client();
        CardModel?[]? cards = await client.ReadRandomCards();
        IEnumerable<CardModel?> creatures = client.FilterCardsByType("creature", cards);
        IEnumerable<CardModel?> enchantments = client.FilterCardsByType("enchantment", cards);
        IEnumerable<CardModel?> lands = client.FilterCardsByType("land", cards);
        IEnumerable<CardModel?> rituals = client.FilterCardsByType("ritual", cards);
        IEnumerable<CardModel?> interrupts = client.FilterCardsByType("interrupt", cards);
        Console.WriteLine("--- Fin !");
    }
}