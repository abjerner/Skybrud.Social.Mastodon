using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Mastodon.Models;

/// <summary>
/// Class representing the rate limiting information about a response received from the Mastodon API.
/// </summary>
public class MastodonRateLimit {

    /// <summary>
    /// Gets the total number of calls allowed within the current window.
    /// </summary>
    public int Limit { get; }

    /// <summary>
    /// Gets the remaining number of calls available to your app within the current window.
    /// </summary>
    public int Remaining { get; }

    /// <summary>
    /// Gets the time until a new rate limiting window starts.
    /// </summary>
    public EssentialsTime Reset { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonRateLimit(IHttpResponse response) {
        Limit = StringUtils.ParseInt32(response.Headers["X-RateLimit-Limit"]);
        Remaining = StringUtils.ParseInt32(response.Headers["X-RateLimit-Remaining"]);
        Reset = EssentialsTime.Parse(response.Headers["X-RateLimit-Reset"])!;
    }

}
