using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Mastodon.Options.Statuses;

/// <summary>
/// Class with options for getting information about a single Mastodon status.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
/// </see>
public class MastodonGetStatusOptions : MastodonHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the status.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#path-parameters</cref>
    /// </see>
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
    public MastodonGetStatusOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status.</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonGetStatusOptions(string id) {
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
        return HttpRequest.Get($"/api/v1/statuses/{Id}");

    }

    #endregion

}