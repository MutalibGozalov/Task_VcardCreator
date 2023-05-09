using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vcard.DataAccess;

using System.Net.Http.Json;
using Models;

public class DbContext
{
    HttpClient _httpClient;
    string URL_ADDRESS;

    public DbContext(string uRL_ADDRESS)
    {
        _httpClient = new HttpClient();
        URL_ADDRESS = uRL_ADDRESS;
    }

    public async Task<Root> GetMyObjectAsync(CancellationToken cts = default)
    {
        // http get request to a rest api address
        using var httpResponse = await _httpClient.GetAsync(URL_ADDRESS, cts);

        if (!httpResponse.IsSuccessStatusCode)
            throw new Exception("Oops... Something went wrong");

        // deserialize content stream into MyObject
        return await httpResponse.Content.ReadFromJsonAsync<Root>(options: System.Text.Json.JsonSerializerOptions.Default, cts);
    }
}
