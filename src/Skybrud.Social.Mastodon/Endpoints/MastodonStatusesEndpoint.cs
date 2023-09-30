using System.Threading.Tasks;
using Skybrud.Social.Mastodon.Options.Statuses;
using Skybrud.Social.Mastodon.Responses.Statuses;

namespace Skybrud.Social.Mastodon.Endpoints;

/// <summary>
/// Class representing the <strong>Statuses</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/statuses/</cref>
/// </see>
public class MastodonStatusesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public MastodonHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public MastodonStatusesRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">A reference to the parent <see cref="MastodonHttpService"/>.</param>
    public MastodonStatusesEndpoint(MastodonHttpService service) {
        Service = service;
        Raw = service.Client.Statuses;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the status with specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status.</param>
    /// <returns>An instance of <see cref="MastodonStatusResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public MastodonStatusResponse GetStatus(string id) {
        return new MastodonStatusResponse(Raw.GetStatus(id));
    }

    /// <summary>
    /// Returns information about the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonStatusResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public MastodonStatusResponse GetStatus(MastodonGetStatusOptions options) {
        return new MastodonStatusResponse(Raw.GetStatus(options));
    }

    /// <summary>
    /// Returns information about the status with specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status.</param>
    /// <returns>An instance of <see cref="MastodonStatusResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public async Task<MastodonStatusResponse> GetStatusAsync(string id) {
        return new MastodonStatusResponse(await Raw.GetStatusAsync(id));
    }

    /// <summary>
    /// Returns the timeline of the hashtag identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonStatusResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#get</cref>
    /// </see>
    public async Task<MastodonStatusResponse> GetStatusAsync(MastodonGetStatusOptions options) {
        return new MastodonStatusResponse(await Raw.GetStatusAsync(options));
    }

    #endregion

}