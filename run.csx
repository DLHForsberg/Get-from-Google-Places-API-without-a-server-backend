using System.Net;
using System.Text;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
    var url = "https://maps.googleapis.com/maps/api/place/details/json?placeid={ YOUR PLACE }&key={ YOUR GOOGLE API KEY }";
    var client = new HttpClient();
    var response = await client.GetAsync(url);
    var content = await response.Content.ReadAsStringAsync();
    
    return new HttpResponseMessage(HttpStatusCode.OK) 
    {
        Content = new StringContent(content, Encoding.UTF8, "application/json")
    };
}
