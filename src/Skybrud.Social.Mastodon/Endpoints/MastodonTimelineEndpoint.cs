using System.Threading.Tasks;
using Skybrud.Social.Mastodon.Options.Timeline;
using Skybrud.Social.Mastodon.Responses.Statuses;

namespace Skybrud.Social.Mastodon.Endpoints;

/// <summary>
/// Implementation of the <strong>Timelines</strong> endpoint.
/// </summary>
public class MastodonTimelineEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public MastodonHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public MastodonTimelineRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal MastodonTimelineEndpoint(MastodonHttpService service) {
        Service = service;
        Raw = service.Client.Timelines;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public MastodonStatusListResponse GetHashtagTimeline(string hashtag) {
        return new MastodonStatusListResponse(Raw.GetHashtagTimeline(hashtag));
    }

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="maxId">All results returned will be lesser than this ID. In effect, sets an upper bound on results.</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public MastodonStatusListResponse GetHashtagTimeline(string hashtag, int? limit, string? maxId) {
        return new MastodonStatusListResponse(Raw.GetHashtagTimeline(hashtag, limit, maxId));
    }

    /// <summary>
    /// Returns the timeline of the hashtag identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public MastodonStatusListResponse GetHashtagTimeline(MastodonGetHashtagTimelineOptions options) {
        return new MastodonStatusListResponse(Raw.GetHashtagTimeline(options));
    }





    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public async Task<MastodonStatusListResponse> GetHashtagTimelineAsync(string hashtag) {
        return new MastodonStatusListResponse(await Raw.GetHashtagTimelineAsync(hashtag));
    }

    /// <summary>
    /// Returns the timeline of the specified <paramref name="hashtag"/>.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="maxId">All results returned will be lesser than this ID. In effect, sets an upper bound on results.</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public async Task<MastodonStatusListResponse> GetHashtagTimelineAsync(string hashtag, int? limit, string? maxId) {
        return new MastodonStatusListResponse(await Raw.GetHashtagTimelineAsync(hashtag, limit, maxId));
    }



    /// <summary>
    /// Returns the timeline of the hashtag identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public async Task<MastodonStatusListResponse> GetHashtagTimelineAsync(MastodonGetHashtagTimelineOptions options) {
        return new MastodonStatusListResponse(await Raw.GetHashtagTimelineAsync(options));
    }













    /// <summary>
    /// Returns the public timeline.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public MastodonStatusListResponse GetPublicTimeline(MastodonGetPublicTimelineOptions options) {
        return new MastodonStatusListResponse(Raw.GetPublicTimeline(options));
    }

    /// <summary>
    /// Returns the public timeline.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonStatusListResponse"/> representing the response.</returns>
    public async Task<MastodonStatusListResponse> GetPublicTimelineAsync(MastodonGetPublicTimelineOptions options) {
        return new MastodonStatusListResponse(await Raw.GetPublicTimelineAsync(options));
    }

    #endregion

}