//FUNCIONES LAMBDA O FUNCIONES FLECHA

Func<int, int, int> sum = (x, y) => x + y;
Func<int, int, int> sub = (x, y) => x - y;

Func<int, int> mult = x => x * 2;
Func<int, int> add = x => x+1;

int SomeFunction(Func<int, int, int> fn, int number) => fn(number, number);
Console.WriteLine(SomeFunction((a, b) => a + b, 5));