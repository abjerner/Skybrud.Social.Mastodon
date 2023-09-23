using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Options.Accounts;

namespace Skybrud.Social.Mastodon.Endpoints;

/// <summary>
/// Class representing the raw <strong>Accounts</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/accounts/</cref>
/// </see>
public class MastodonAccountsRawEndpoint {

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
    public MastodonAccountsRawEndpoint(MastodonHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the account with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the account.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public IHttpResponse GetAccount(string id) {
        return GetAccount(new MastodonGetAccountOptions(id));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public IHttpResponse GetAccount(MastodonGetAccountOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns information about the account with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the account.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public async Task<IHttpResponse> GetAccountAsync(string id) {
        return await GetAccountAsync(new MastodonGetAccountOptions(id));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public async Task<IHttpResponse> GetAccountAsync(MastodonGetAccountOptions options) {
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Returns information about the account with the specified username or Webfinger address.
    /// </summary>
    /// <param name="acct">The username or Webfinger address to lookup.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#lookup</cref>
    /// </see>
    public IHttpResponse Lookup(string acct) {
        return Lookup(new MastodonAccountLookupOptions(acct));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public IHttpResponse Lookup(MastodonAccountLookupOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns information about the account with the specified username or Webfinger address.
    /// </summary>
    /// <param name="acct">The username or Webfinger address to lookup.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#lookup</cref>
    /// </see>
    public async Task<IHttpResponse> LookupAsync(string acct) {
        return await LookupAsync(new MastodonAccountLookupOptions(acct));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public async Task<IHttpResponse> LookupAsync(MastodonAccountLookupOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

}