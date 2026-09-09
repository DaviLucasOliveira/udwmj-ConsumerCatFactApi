using ConsumerGatinho;
using static System.Console;

var enderecoUrl = "https://catfact.ninja/fact";

WriteLine($"Consultando o endereço na url: {enderecoUrl}");

var client = new HttpClient();

try
{
    HttpResponseMessage response = await client.GetAsync(enderecoUrl);
    response.EnsureSuccessStatusCode();

    string respostaApi = await response.Content.ReadAsStringAsync();

    CatFact? catFact = System.Text.Json.JsonSerializer.Deserialize<CatFact>(respostaApi);

    WriteLine($"\nCat fact: {catFact?.fact}");
    WriteLine($"Lenght: {catFact?.length} \n");

}
catch (Exception e)
{
    WriteLine($"Ocorreu um erro ao consultar o endereço: {e.Message}");
}
