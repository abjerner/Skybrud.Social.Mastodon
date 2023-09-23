using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Options.Timeline;

namespace Skybrud.Social.Mastodon.Endpoints;

/// <summary>
/// Class representing the raw <strong>Timeline</strong> endpoint.
/// </summary>
public class MastodonTimelineRawEndpoint {

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
    public MastodonTimelineRawEndpoint(MastodonHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public IHttpResponse GetHashtagTimeline(string hashtag) {
        return GetHashtagTimeline(new MastodonGetHashtagTimelineOptions(hashtag));
    }

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="maxId">All results returned will be lesser than this ID. In effect, sets an upper bound on results.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public IHttpResponse GetHashtagTimeline(string hashtag, int? limit, string? maxId) {
        return GetHashtagTimeline(new MastodonGetHashtagTimelineOptions(hashtag, limit, maxId));
    }

    /// <summary>
    /// Returns the timeline of the hashtag identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public IHttpResponse GetHashtagTimeline(MastodonGetHashtagTimelineOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetHashtagTimelineAsync(string hashtag) {
        return await GetHashtagTimelineAsync(new MastodonGetHashtagTimelineOptions(hashtag));
    }

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="maxId">All results returned will be lesser than this ID. In effect, sets an upper bound on results.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetHashtagTimelineAsync(string hashtag, int? limit, string? maxId) {
        return await GetHashtagTimelineAsync(new MastodonGetHashtagTimelineOptions(hashtag, limit, maxId));
    }

    /// <summary>
    /// Returns the timeline of the hashtag identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetHashtagTimelineAsync(MastodonGetHashtagTimelineOptions options) {
        return await Client.GetResponseAsync(options);
    }



















    /// <summary>
    /// Returns the public timeline.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public IHttpResponse GetPublicTimeline(MastodonGetPublicTimelineOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns the public timeline.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetPublicTimelineAsync(MastodonGetPublicTimelineOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

}