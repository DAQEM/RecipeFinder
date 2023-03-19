namespace BLL.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Type serviceType, string functionName, Type entityType, object obj)
        : base($"Could not find {entityType} in {serviceType}.{functionName}({entityType} {obj})")
    {
    }
}