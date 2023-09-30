using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Models.Accounts;

namespace Skybrud.Social.Mastodon.Responses.Accounts;

/// <summary>
/// Class representing a response from the Mastodon API.
/// </summary>
public class MastodonAccountResponse : MastodonResponse<MastodonAccount> {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonAccountResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, MastodonAccount.Parse);
    }

}