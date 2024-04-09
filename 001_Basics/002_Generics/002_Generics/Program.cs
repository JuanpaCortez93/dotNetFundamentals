MyList<int> numbers = new MyList<int>(5);
MyList<string> names = new MyList<string>(5);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);

numbers.GetContent();

names.Add("Felipe");
names.Add("Ximena");
names.Add("Pablo");

names.GetContent();

class MyList <T>
{

    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>();
    }

    public void Add(T element)
    {
        if(_list.Count < _limit)
        {
            _list.Add(element);
        }
    }


    public void GetContent()
    {
        foreach(var item in _list) Console.WriteLine(item);
    }

    private List<T> _list;
    private int _limit;

}