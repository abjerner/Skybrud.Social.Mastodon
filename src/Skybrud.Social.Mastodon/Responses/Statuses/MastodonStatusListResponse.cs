using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Models.Statuses;

namespace Skybrud.Social.Mastodon.Responses.Statuses;

/// <summary>
/// Class representing a response from the Mastodon API.
/// </summary>
public class MastodonStatusListResponse : MastodonListResponse<MastodonStatus> {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonStatusListResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonArray(response.Body, MastodonStatus.Parse);
    }

}