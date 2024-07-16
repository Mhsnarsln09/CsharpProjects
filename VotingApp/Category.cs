public class Category
{
    public string Name { get; set; }
    public int Votes { get; set; }

    public Category(string name)
    {
        Name = name;
        Votes = 0;
    }
}
