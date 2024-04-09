using System.Text.Json;

Players ronaldo = new Players("Ronaldo Nazario de Lima", "Forward");
ronaldo.GetInfo();


//Serializar
var ronaldoJson = JsonSerializer.Serialize(ronaldo);
Console.WriteLine(ronaldoJson);

//Deserializar
var myJson = @"{
    ""Name"": ""Cristiano Ronaldo"",
    ""Position"": ""Forward""
}";

Players cristianoRonaldo = JsonSerializer.Deserialize<Players>(myJson);
Console.WriteLine(cristianoRonaldo?.Name);

interface IInfo
{
    void GetInfo();
}


class Players : IInfo
{

    public Players (string name, string position)
    {
        _name = name;
        _position = position;
    }


    public void GetInfo()
    {
        Console.WriteLine($"Player's name: {_name}\nPosition: {_position}");
    }

    public string Name { get {return _name ; } set {_name = value; } }
    public string Position { get {return _position; } set {_position = value; } }



    private string _name;   
    private string _position;

}
