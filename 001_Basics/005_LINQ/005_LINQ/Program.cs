//LINQ MANEJA TRES ETAPAS: EL ORIGEN DE LOS DATOS (LA LISTA), EL QUERY O CONSULTA (AQUI NO SE EJECUTA) Y LA EJECUCIÓN EN EL FOREACH.

var names = new List<string>() { 
    "Hector", "Juan", "Carlos", "Mellisa", "Nicky"    
}; 

var namesResults = from n in names orderby n select n;

foreach (var name in namesResults)
{
    Console.WriteLine(name);
}

Console.WriteLine("\n");

var namesResultDesc = from name in names orderby name descending select name;
foreach (var name in namesResultDesc)
{
    Console.WriteLine(name);
}

Console.WriteLine("\n");
var namesResultWhere = from name in names where name.Length > 5 select name;

foreach (var name in namesResultWhere)
{
    Console.WriteLine(name);
}

Console.WriteLine("\n");
var namesWithLambdas = names.Where(x => x.Length >= 7);
foreach (var name in namesWithLambdas)
{
    Console.WriteLine(name);
}