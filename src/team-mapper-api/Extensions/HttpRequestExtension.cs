namespace team_mapper_api.Extensions;

public static class HttpRequestExtension
{
    /// <summary>
    /// Get's correlation Id from the http request.
    /// </summary>
    /// <param name="httpRequest"></param>
    /// <returns></returns>
    public static Guid GetCorrelationId(this HttpRequest httpRequest)
    {
        if (Guid.TryParse(httpRequest.Headers["X-Correlation-ID"], out Guid _))
        {
            return Guid.Empty;
        }
        return Guid.NewGuid();
    }
}
