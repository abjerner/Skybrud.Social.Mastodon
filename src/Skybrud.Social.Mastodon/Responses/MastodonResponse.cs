using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Exceptions;
using Skybrud.Social.Mastodon.Models;

namespace Skybrud.Social.Mastodon.Responses;

/// <summary>
/// Class representing a response from the Mastodon API.
/// </summary>
public class MastodonResponse : HttpResponseBase {

    /// <summary>
    /// Gets rate limiting information about the response.
    /// </summary>
    public MastodonRateLimit RateLimit { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonResponse(IHttpResponse response) : base(response) {
        RateLimit = new MastodonRateLimit(response);
        if (response.StatusCode == HttpStatusCode.OK) return;
        if (response.StatusCode == HttpStatusCode.Created) return;
        throw new MastodonHttpException(response);
    }

}

/// <summary>
/// Class representing a response from the Mastodon API.
/// </summary>
public class MastodonResponse<T> : MastodonResponse {

    /// <summary>
    /// Gets the body of the response.
    /// </summary>
    public T Body { get; protected set; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonResponse(IHttpResponse response) : base(response) {
        Body = default!;
    }

}