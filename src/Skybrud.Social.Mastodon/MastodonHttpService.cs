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
    /// Gets a reference to the <strong>Statuses</strong> API.
    /// </summary>
    public MastodonStatusesEndpoint Statuses { get; }

    /// <summary>
    /// Gets a reference to the <strong>Timelines</strong> API.
    /// </summary>
    public MastodonTimelineEndpoint Timelines { get; }

    #endregion

    #region Constructors

    private MastodonHttpService(MastodonHttpClient client) {

        Client = client;

        Accounts = new MastodonAccountsEndpoint(this);
        Statuses = new MastodonStatusesEndpoint(this);
        Timelines = new MastodonTimelineEndpoint(this);

    }

    #endregion

    #region Static methods

    /// <summary>
    /// Creates a new <see cref="MastodonHttpService"/> based on the specified HTTP <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    /// <returns>An instance of <see cref="MastodonHttpService"/>.</returns>
    public static MastodonHttpService CreateFromClient(MastodonHttpClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return new MastodonHttpService(client);
    }

    /// <summary>
    /// Creates a new <see cref="MastodonHttpService"/> based on the specified <paramref name="domain"/>. This instance
    /// can be used for accessing public information.
    /// </summary>
    /// <param name="domain">The domain of the Mastodon server.</param>
    /// <returns>An instance of <see cref="MastodonHttpService"/>.</returns>
    public static MastodonHttpService CreateFromDomain(string domain) {
        if (string.IsNullOrWhiteSpace(domain)) throw new ArgumentNullException(nameof(domain));
        return new MastodonHttpService(new MastodonHttpClient(domain));
    }

    /// <summary>
    /// Creates a new <see cref="MastodonHttpService"/> based on the specified <paramref name="domain"/> and
    /// <paramref name="accessToken"/>. This instance can be used for making authorized request on behalf of a user.
    /// </summary>
    /// <param name="domain">The domain of the Mastodon server.</param>
    /// <param name="accessToken">The user's access token.</param>
    /// <returns>An instance of <see cref="MastodonHttpService"/>.</returns>
    public static MastodonHttpService CreateFromAccessToken(string domain, string accessToken) {
        if (string.IsNullOrWhiteSpace(domain)) throw new ArgumentNullException(nameof(domain));
        return new MastodonHttpService(new MastodonHttpClient(domain, accessToken));
    }

    #endregion

}