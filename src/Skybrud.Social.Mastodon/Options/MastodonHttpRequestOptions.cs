using Skybrud.Essentials.Http;

namespace Skybrud.Social.Mastodon.Options;

/// <summary>
/// Abstract options class describing a HTTP request.
/// </summary>
public abstract class MastodonHttpRequestOptions {

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    /// <param name="client">A reference to the parent <see cref="MastodonHttpClient"/>.</param>
    public abstract IHttpRequest GetRequest(MastodonHttpClient client);

}