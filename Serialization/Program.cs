using System.Text;
using System.Xml;
using System.Xml.Serialization;

const string filePath = "personalData.xml";
if (File.Exists(filePath))
{
    using Stream reader = new FileStream(filePath, FileMode.Open);
    var xmlSerializer = new XmlSerializer(typeof(Person));

    StreamReader stream = new StreamReader(reader, Encoding.UTF8);
    var person = (Person?)xmlSerializer.Deserialize(
        new XmlTextReader(stream));

    //for JSON format we would use this:
    //Person recreatedPerson = JsonConvert.DeserializeObject<Person>(json);

    Console.WriteLine($"Personal data read from xml:\n{person}");
}
else
{
    var name = Read("name");
    var lastName = Read("last name");
    var residence = Read("place of residence");
    var hobby = Read("hobby");

    var person = new Person(name, lastName, residence, hobby);

    string xml = Serialize(person);
    Console.WriteLine(
        $"The person object serialized to XML is:\n{xml}");

    SaveXmlToFile(filePath, xml);

    //for JSON format we would use this
    //string json = JsonConvert.SerializeObject(person, Formatting.Indented);
}
Console.ReadKey();

static string Read(string what)
{
    Console.WriteLine($"Enter the {what}:");
    return Console.ReadLine();
}

static string Serialize(Person person)
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

    var stringWriter = new StringWriter();

    var xmlWriter = XmlWriter.Create(
        stringWriter, new XmlWriterSettings { Indent = true });
    
        xmlSerializer.Serialize(xmlWriter, person);
            return stringWriter.ToString();      
}

static void SaveXmlToFile(string path, string xml)
{
    File.WriteAllText(path, xml);
}

//the Serializable attribute is not needed for XML or JSON serialization
//only for BinaryFormatter and SoapFormatter
//[Serializable]
public record Person
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Residence { get; set; }
    public string Hobby { get; set; }

    private Person()
    {

    }

    public Person(string name, string lastName, string residence, string hobby)
    {
        Name = name;
        LastName = lastName;
        Residence = residence;
        Hobby = hobby;
    }
}