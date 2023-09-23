using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Models.Statuses;

namespace Skybrud.Social.Mastodon.Responses.Statuses;

/// <summary>
/// Class representing a response from the Mastodon API with information about a single Mastodon status.
/// </summary>
public class MastodonStatusResponse : MastodonResponse<MastodonStatus> {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonStatusResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, MastodonStatus.Parse);
    }

}