namespace IgnoreInputValidation.Types;

[QueryType]
public static class Query
{
    public static Book GetBook([InputValidation] String name)
    {
        return new Book { Title = "C# in depth", Author = "Jon Skeet" };       
    }
}