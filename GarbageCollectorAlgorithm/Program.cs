
bool flag = true;
Person person = new Person();
if(flag)
{
    string textInsideIf = "aaa";
    person.Name = "Tom";
}

string text = "bbb";


Console.ReadKey();

class Person
{
    public string Name { get; set; }
}
