using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08LINQ.Classes
{
  public class Answers
  {
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("features")]
    public Features[] Features { get; set; }
  }

  public class Features
  {
    [JsonProperty("type")]
    public string TypeTwo { get; set; }

    [JsonProperty("geometry")]
    public Geometry Geometry { get; set; }
    [JsonProperty("properties")]
    public Property Properties { get; set; }
  }
  public class Geometry
  {
    [JsonProperty("type")]
    public string TypeThree { get; set; }

    [JsonProperty("coordinates")]
    public double[] Coordinates { get; set; }
  }
  public class Property
  {
    [JsonProperty("zip")]
    public string zip { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("borough")]
    public string Borough { get; set; }

    [JsonProperty("neighborhood")]
    public string Neigborhood { get; set; }


    [JsonProperty("county")]
    public string Country { get; set; }
  }
}
