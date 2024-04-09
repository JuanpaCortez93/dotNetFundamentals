
//FUNCIÓN DE PRIMERA CLASE: CUANDO LAS FUNCIONES SON TRATADAS COMO VARIABLE
string Show(string name)
{
    return name;
}

var show = Show;
//show("Hello");

//Funcion tipo action: realiza una función 
void Some(Func<string, string> fn, string message)
{
    Console.WriteLine("Hace algo aquí");
    Console.WriteLine(fn(message)); 
    Console.WriteLine("Hace algo al final");
}

Some(show, "Hola como estas?");

Console.WriteLine("\n");

//FUNCION PURA: DEBE RETORNARTE EL MISMO VALOR CON EL PASO DEL TIEMPO CON LOS MISMOS VALORES DEL TIEMPO
//SE RECIBE DOS VALORES POR COPIA DE VALOR
//POR EJEMPLO SI PONES A = 1 Y B = 2 ENTONCES LA RESPUESTA ES 3 SIEMPRE
int Sum(int a, int b) => a + b;

//FUNCIÓN NO PURA: NO RETORNA EL MISMO VALOR CON EL PASO DEL TIEMPO.  
DateTime GetTomorrow ()  => DateTime.Now.AddDays(1);

//TRANSFORMADA A FUNCIÓN PURA
//DATETIME NO ES CLASE, ES STRUCT: SE PASA EL VALOR NO LA REFERENCIA.
DateTime GetTomorrowUsingData (DateTime date)  => date.AddDays(1);


var guinnes = new Beers()
{
    Name = "Guinness"
};


Console.WriteLine(ToUpper(guinnes).Name);
Console.WriteLine(guinnes.Name);

Beers ToUpper(Beers beer)
{
    var beer2 = new Beers()
    {
        Name = beer.Name.ToUpper(),
    };

    return beer2;
}

class Beers
{
    public string Name { get; set; }
}


