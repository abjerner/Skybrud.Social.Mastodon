using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Social.Mastodon.Endpoints;
using Skybrud.Social.Mastodon.Options;

namespace Skybrud.Social.Mastodon;

/// <summary>
/// Class for handling the HTTP communication with the Mastodon API.
/// </summary>
public class MastodonHttpClient : HttpClient {

    #region Properties

    /// <summary>
    /// Gets or sets the domain of the Mastodon server.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Domain { get; set; }
#else
    public string? Domain { get; set; }
#endif

    /// <summary>
    /// Gets or sets an access token to be used for authenticated requests.
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    /// Gets a reference to the raw <strong>Accounts</strong> endpoint.
    /// </summary>
    public MastodonAccountsRawEndpoint Accounts { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Timelines</strong> endpoint.
    /// </summary>
    public MastodonTimelineRawEndpoint Timelines { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Statuses</strong> endpoint.
    /// </summary>
    public MastodonStatusesRawEndpoint Statuses { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="domain">The domain of the Mastodon server.</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonHttpClient(string domain) {

        if (string.IsNullOrWhiteSpace(domain)) throw new ArgumentNullException(nameof(domain));

        Domain = domain;

        Accounts = new MastodonAccountsRawEndpoint(this);
        Statuses = new MastodonStatusesRawEndpoint(this);
        Timelines = new MastodonTimelineRawEndpoint(this);

    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="domain"/> and <paramref name="accessToken"/>.
    /// </summary>
    /// <param name="domain">The domain of the Mastodon server.</param>
    /// <param name="accessToken">The user's access token.</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonHttpClient(string domain, string accessToken) : this(domain) {
        if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
        AccessToken = accessToken;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns the response of the request identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public IHttpResponse GetResponse(MastodonHttpRequestOptions options) {
        return GetResponse(options.GetRequest(this));
    }

    /// <summary>
    /// Returns the response of the request identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetResponseAsync(MastodonHttpRequestOptions options) {
        return await GetResponseAsync(options.GetRequest(this));
    }

    /// <inheritdoc />
    protected override void PrepareHttpRequest(IHttpRequest request) {

        // Specified request must have a URL
        if (string.IsNullOrWhiteSpace(request.Url)) throw new PropertyNotSetException(nameof(IHttpRequest.Url));

        // Append the domain if URL starts with a forward slash
        if (request.Url.StartsWith("/")) {
            if (string.IsNullOrWhiteSpace(Domain)) throw new PropertyNotSetException(nameof(Domain));
            request.Url = $"https://{Domain}{request.Url}";
        }

    }

    #endregion

}