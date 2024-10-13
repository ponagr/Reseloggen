using System.Text.Json;
using Reseloggen;

public class Resor
{
    public string Place { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public int Grade { get; set; }

    public override string ToString()
    {
        return $"{Place}, {Year}, {Grade}/5, {Description}";
    }

    public static void SaveList()
    {
        string fileName = "Reselogg.json";
        string jsonString = JsonSerializer.Serialize(Resehanterare.reseLogg);
        File.WriteAllText(fileName, jsonString);
    }
    public static void LoadList()
    {
        string fileName = "Reselogg.json";
        string jsonString = File.ReadAllText(fileName);
        Resehanterare.reseLogg = JsonSerializer.Deserialize<List<Resor>>(jsonString);
    }
}