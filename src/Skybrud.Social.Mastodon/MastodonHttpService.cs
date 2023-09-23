using System;
using Skybrud.Social.Mastodon.Endpoints;

namespace Skybrud.Social.Mastodon;

/// <summary>
/// Class working as an entry point to making requests to the various endpoints of the Mastodon API.
/// </summary>
public class MastodonHttpService {

    #region Properties

    /// <summary>
    /// Gets a reference to the underlying HTTP client.
    /// </summary>
    public MastodonHttpClient Client { get; }

    /// <summary>
    /// Gets a reference to the <strong>Accounts</strong> API.
    /// </summary>
    public MastodonAccountsEndpoint Accounts { get; }

    /// <summary>
    /// Gets a reference to the <strong>Timelines</strong> API.
    /// </summary>
    public MastodonTimelineEndpoint Timelines { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Returns a new instance of <see cref="MastodonHttpService"/> based on the specified <paramref name="domain"/>.
    /// </summary>
    /// <param name="domain">The domain of the Mastodon server.</param>
    public MastodonHttpService(string domain) {

        if (string.IsNullOrWhiteSpace(domain)) throw new ArgumentNullException(nameof(domain));

        Client = new MastodonHttpClient(domain);

        Accounts = new MastodonAccountsEndpoint(this);
        Timelines = new MastodonTimelineEndpoint(this);

    }

    #endregion

    #region Static methods

    /// <summary>
    /// Creates a new <see cref="MastodonHttpService"/> based on the specified <paramref name="domain"/>. This instance
    /// can be used for accessing public information.
    /// </summary>
    /// <param name="domain">The domain of the Mastodon server.</param>
    /// <returns>An instance of <see cref="MastodonHttpService"/>.</returns>
    public static MastodonHttpService CreateFromDomain(string domain) {
        if (string.IsNullOrWhiteSpace(domain)) throw new ArgumentNullException(nameof(domain));
        return new MastodonHttpService(domain);
    }

    #endregion

}