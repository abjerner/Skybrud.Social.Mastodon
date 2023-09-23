using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Options.Statuses;

namespace Skybrud.Social.Mastodon.Endpoints;

/// <summary>
/// Class representing the raw <strong>Statuses</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/statuses/</cref>
/// </see>
public class MastodonStatusesRawEndpoint {

    #region Member methods

    /// <summary>
    /// Gets a reference to the parent <see cref="MastodonHttpClient"/>.
    /// </summary>
    public MastodonHttpClient Client { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">A reference to the parent <see cref="MastodonHttpClient"/>.</param>
    public MastodonStatusesRawEndpoint(MastodonHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the status with specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public IHttpResponse GetStatus(string id) {
        return GetStatus(new MastodonGetStatusOptions(id));
    }
    /// <summary>
    /// Returns information about the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public IHttpResponse GetStatus(MastodonGetStatusOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns information about the status with specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public async Task<IHttpResponse> GetStatusAsync(string id) {
        return await GetStatusAsync(new MastodonGetStatusOptions(id));
    }

    /// <summary>
    /// Returns the timeline of the hashtag identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public async Task<IHttpResponse> GetStatusAsync(MastodonGetStatusOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

}