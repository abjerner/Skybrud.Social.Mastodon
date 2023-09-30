using System;
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
    /// Bookmarks the status with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status to bookmark.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#bookmark</cref>
    /// </see>
    public IHttpResponse BookmarkStatus(string id) {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
        return BookmarkStatus(new MastodonBookmarkStatusOptions(id));
    }

    /// <summary>
    /// Bookmarks the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#bookmark</cref>
    /// </see>
    public IHttpResponse BookmarkStatus(MastodonBookmarkStatusOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Bookmarks the status with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status to bookmark.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#bookmark</cref>
    /// </see>
    public async Task<IHttpResponse> BookmarkStatusAsync(string id) {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
        return await BookmarkStatusAsync(new MastodonBookmarkStatusOptions(id));
    }

    /// <summary>
    /// Bookmarks the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#bookmark</cref>
    /// </see>
    public async Task<IHttpResponse> BookmarkStatusAsync(MastodonBookmarkStatusOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Favourites the status with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status to favourite.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#favourite</cref>
    /// </see>
    public IHttpResponse FavouriteStatus(string id) {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
        return FavouriteStatus(new MastodonFavouriteStatusOptions(id));
    }

    /// <summary>
    /// Favourites the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#favourite</cref>
    /// </see>
    public IHttpResponse FavouriteStatus(MastodonFavouriteStatusOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Favourites the status with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status to favourite.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#favourite</cref>
    /// </see>
    public async Task<IHttpResponse> FavouriteStatusAsync(string id) {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
        return await FavouriteStatusAsync(new MastodonFavouriteStatusOptions(id));
    }

    /// <summary>
    /// Favourites the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#favourite</cref>
    /// </see>
    public async Task<IHttpResponse> FavouriteStatusAsync(MastodonFavouriteStatusOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

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

    /// <summary>
    /// Publishes a new status described by the specified <paramref name="options"/>..
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#create</cref>
    /// </see>
    public IHttpResponse PostStatus(MastodonPostStatusOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Publishes a new status described by the specified <paramref name="options"/>..
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#create</cref>
    /// </see>
    public async Task<IHttpResponse> PostStatusAsync(MastodonPostStatusOptions options) {
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Reblogs the status with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status to reblog.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#boost</cref>
    /// </see>
    public IHttpResponse ReblogStatus(string id) {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
        return ReblogStatus(new MastodonReblogStatusOptions(id));
    }

    /// <summary>
    /// Reblogs the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#boost</cref>
    /// </see>
    public IHttpResponse ReblogStatus(MastodonReblogStatusOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Reblogs the status with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the status to reblog.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#boost</cref>
    /// </see>
    public async Task<IHttpResponse> ReblogStatusAsync(string id) {
        if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
        return await ReblogStatusAsync(new MastodonReblogStatusOptions(id));
    }

    /// <summary>
    /// Reblogs the status identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/statuses/#boost</cref>
    /// </see>
    public async Task<IHttpResponse> ReblogStatusAsync(MastodonReblogStatusOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}