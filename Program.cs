namespace Vcard;
using DataAccess;
using Models;
using Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string URL_ADDRESS = "https://randomuser.me/api?results=1";
        DbContext context = new(URL_ADDRESS);

        var res = await context.GetMyObjectAsync();

        PersonModel person = new(res.results[0].name.first, res.results[0].name.last, res.results[0].name.first +" "+ res.results[0].name.last, res.results[0].name.first.Substring(0, 4) +"_"+ res.results[0].name.last.Substring(0, 4), res.results[0].dob.date, res.results[0].registered.date, res.results[0].email, res.results[0].cell, res.results[0].location.street.name, res.results[0].location.city, res.results[0].location.postcode, res.results[0].location.country);
        System.Console.WriteLine("Result: {0}", person);

        VcardCreator creator = new();
        creator.CreateContact(person, "user");

        Console.ReadLine();
    }
}