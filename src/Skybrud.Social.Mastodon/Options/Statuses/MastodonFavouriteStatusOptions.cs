using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Mastodon.Options.Statuses;

/// <summary>
/// Class with options for favouriting a status.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/statuses/#favourite</cref>
/// </see>
public class MastodonFavouriteStatusOptions : MastodonHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the status.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Id { get; set; }
#else
    public string? Id { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public MastodonFavouriteStatusOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status.</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonFavouriteStatusOptions(string id) {
        Id = id;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest(MastodonHttpClient client) {

        // Validate required properties
        if (string.IsNullOrWhiteSpace(Id)) throw new PropertyNotSetException(nameof(Id));

        // Initialize a new HTTP request
        return HttpRequest.Get($"/api/v1/statuses/{Id}/favourite");

    }

    #endregion

}