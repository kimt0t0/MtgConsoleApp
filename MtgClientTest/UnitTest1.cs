using MtgClient;

namespace MtgClientTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestClient()
    {
        var client = new Client();
        Assert.IsTrue(client.httpClient.GetType() == typeof(System.Net.Http.HttpClient));
    }

    [Test]
    public async Task TestReadCard()
    {
        var client = new Client();
        var card = await client.ReadCard("random");
        Assert.IsTrue(card.Length > 0);
    }

    // [Test]
    // public void TestStartsWithUpper()
    // {
    //     // Tests that we expect to return true.
    //     string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };
    //     foreach (var word in words)
    //     {
    //         bool result = word.StartsWithUpper();
    //         Assert.IsTrue(result,
    //                string.Format("Expected for '{0}': true; Actual: {1}",
    //                              word, result));
    //     }
    // }

    // [Test]
    // public void TestDoesNotStartWithUpper()
    // {
    //     // Tests that we expect to return false.
    //     string[] words = { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
    //                            "1234", ".", ";", " " };
    //     foreach (var word in words)
    //     {
    //         bool result = word.StartsWithUpper();
    //         Assert.IsFalse(result,
    //                string.Format("Expected for '{0}': false; Actual: {1}",
    //                              word, result));
    //     }
    // }

    // [Test]
    // public void DirectCallWithNullOrEmpty()
    // {
    //     // Tests that we expect to return false.
    //     string?[] words = { string.Empty, null };
    //     foreach (var word in words)
    //     {
    //         bool result = word.StartsWithUpper();
    //         Assert.IsFalse(result,
    //                string.Format("Expected for '{0}': false; Actual: {1}",
    //                              word == null ? "<null>" : word, result));
    //     }
    // }
}