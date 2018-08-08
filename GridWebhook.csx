#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;


public class GridEvent
{
    public string Id { get; set; }
    public string EventType { get; set; }
    public string Subject { get; set; }
    public DateTime EventTime { get; set; }
    public Dictionary<string, string> Data { get; set; }
    public string Topic { get; set; }
}

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook was triggered!");
    

    string jsonContent = await req.Content.ReadAsStringAsync();
    var events = JsonConvert.DeserializeObject<GridEvent[]>(jsonContent);

    if (req.Headers.GetValues("Aeg-Event-Type").FirstOrDefault() == "SubscriptionValidation")
    {
        var code = events[0].Data["validationCode"];
        return req.CreateResponse(HttpStatusCode.OK,
            new { validationResponse = code });
    }

    return req.CreateResponse(HttpStatusCode.OK);

}
