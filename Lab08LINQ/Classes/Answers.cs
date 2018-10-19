using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08LINQ.Classes
{
  /// <summary>
  /// main object from json data
  /// contains type and features properties
  /// </summary>
  public class Answers
  {
    [JsonProperty("type")]
    public string Type { get; set; }
    /// <summary>
    /// this object property contains an array of objects
    /// </summary>
    [JsonProperty("features")]
    public Features[] Features { get; set; }
  }
  /// <summary>
  /// defines the Features objects
  /// </summary>
  public class Features
  {
    [JsonProperty("type")]
    public string TypeTwo { get; set; }
    /// <summary>
    /// an object within an object
    /// </summary>
    [JsonProperty("geometry")]
    public Geometry Geometry { get; set; }
    [JsonProperty("properties")]
    public Property Properties { get; set; }
  }
  /// <summary>
  /// defines the Geomtry Property
  /// </summary>
  public class Geometry
  {
    [JsonProperty("type")]
    public string TypeThree { get; set; }

    [JsonProperty("coordinates")]
    public double[] Coordinates { get; set; }
  }
  /// <summary>
  /// defines the object property, has neighborhood property in it
  /// </summary>
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
