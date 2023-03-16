namespace MVC.Handlers;

public static class UriHandler
{
    public static bool IsValidUri(string uri)
    {
        return Uri.TryCreate(uri, UriKind.Absolute, out Uri? uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}