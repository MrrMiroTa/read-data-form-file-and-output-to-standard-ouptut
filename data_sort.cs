using Read_data_from_file_and_filter_name_change_value_M_F.Read_data_from_file;

string filename = "Personal_file.txt";
Console.WriteLine($"Reading People Data from file {filename}");
Console.SetIn(File.OpenText(filename));

int line = 1;
List<Person> people = new List<Person>();

while (true)
{
    Console.WriteLine($"Line {line++}...\n");
    string? data = Console.ReadLine();
    if (string.IsNullOrEmpty(data))
    {
        Console.WriteLine("Nothing");
        break;
    }
    Person person = new Person();
    if (person.SetData(data, "/") == false)
    {
        Console.WriteLine("Invalid");
        continue;
    }
    Console.WriteLine("OK\n");
    people.Add(person);
}

// Filter persons for age > 25
var filteredPeople = people.Where(p => p.GetAge() < 25).ToList();

// Sort persons in ascending order by name
filteredPeople.Sort((p1, p2) => string.Compare(p1.GetName(), p2.GetName()));

// Update values of gender from "Male" to "M" and "Female" to "F"
foreach (var person in filteredPeople)
{
    if (person.GetGender() == "Male")
    {
        person.SetData($"{person.GetName()}/M/{person.GetAge()}");
    }
    else if (person.GetGender() == "Female")
    {
        person.SetData($"{person.GetName()}/F/{person.GetAge()}");
    }
}

string result = string.Join("\n", filteredPeople.Select(p => p.GetInfo()));

string heading = $"{"Name",-30}{"Gender",-6}{"Age",4}";
string bar = new string('_', 45);
Console.WriteLine();
Console.WriteLine("People Information\n \n");
Console.WriteLine(heading);
Console.WriteLine(bar);
Console.WriteLine(result);
Console.WriteLine(bar);