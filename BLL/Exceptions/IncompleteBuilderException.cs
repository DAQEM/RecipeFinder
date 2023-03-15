namespace BLL.Exceptions;

public class IncompleteBuilderException : Exception
{
    public IncompleteBuilderException(Type builderType) : base($"Builder for {builderType} is missing one or more required fields.")
    {
    }
}