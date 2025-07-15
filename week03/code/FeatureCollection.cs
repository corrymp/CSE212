public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public float[] Bbox { get; set; }
    public Feature[] Features { get; set; }
    public Meta Metadata { get; set; }
}

public class Feature
{
    public Geo Geomentry { get; set; }
    public Props Properties { get; set; }
    public string Id { get; set; }
    public string Type { get; set; }
}

public class Meta
{
    public int Count { get; set; }
    public int Status { get; set; }
    public long Generated { get; set; }
    public string Api { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}

public class Geo
{
    public float Longitude { get; set; }
    public float Latitude { get; set; }
    public float Depth { get; set; }
}

public class Props
{
    public int? Felt { get; set; }
    public int? NST { get; set; }
    public int Sig { get; set; }
    public int? Tsunami { get; set; }
    public int? TZ { get; set; }
    public float? CDI { get; set; }
    public float? DMin { get; set; }
    public float? Gap { get; set; }
    public float Mag { get; set; }
    public float? MMI { get; set; }
    public float RMS { get; set; }
    public long Time { get; set; }
    public long Updated { get; set; }
    public string Alert { get; set; }
    public string Code { get; set; }
    public string Detail { get; set; }
    public string IDs { get; set; }
    public string MagType { get; set; }
    public string Net { get; set; }
    public string Place { get; set; }
    public string Sources { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Types { get; set; }
    public string URL { get; set; }
}
