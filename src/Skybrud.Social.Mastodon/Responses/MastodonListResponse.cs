using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Models;

namespace Skybrud.Social.Mastodon.Responses;

/// <summary>
/// Class representing a response from the Mastodon API with a list of entities.
/// </summary>
public class MastodonListResponse<T> : MastodonResponse<IReadOnlyList<T>> {

    /// <summary>
    /// Gets a reference to the <strong>Link</strong> header used for pagination.
    /// </summary>
    public MastodonLinkHeader Link { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public MastodonListResponse(IHttpResponse response) : base(response) {
        Link = MastodonLinkHeader.Parse(response);
        Body = default!;
    }

}