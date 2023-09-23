using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Mastodon.Options.Accounts;
using Skybrud.Social.Mastodon.Responses.Statuses;

namespace Skybrud.Social.Mastodon.Endpoints;

/// <summary>
/// Class representing the <strong>Accounts</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/accounts/</cref>
/// </see>
public class MastodonAccountsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public MastodonHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public MastodonAccountsRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">A reference to the parent <see cref="MastodonHttpService"/>.</param>
    public MastodonAccountsEndpoint(MastodonHttpService service) {
        Service = service;
        Raw = service.Client.Accounts;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the account with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the account.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public MastodonAccountResponse GetAccount(string id) {
        return new MastodonAccountResponse(Raw.GetAccount(id));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public MastodonAccountResponse GetAccount(MastodonGetAccountOptions options) {
        return new MastodonAccountResponse(Raw.GetAccount(options));
    }

    /// <summary>
    /// Returns information about the account with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the account.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public async Task<MastodonAccountResponse> GetAccountAsync(string id) {
        return new MastodonAccountResponse(await Raw.GetAccountAsync(id));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public async Task<MastodonAccountResponse> GetAccountAsync(MastodonGetAccountOptions options) {
        return new MastodonAccountResponse(await Raw.GetAccountAsync(options));
    }

    /// <summary>
    /// Returns information about the account with the specified username or Webfinger address.
    /// </summary>
    /// <param name="acct">The username or Webfinger address to lookup.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#lookup</cref>
    /// </see>
    public MastodonAccountResponse Lookup(string acct) {
        return new MastodonAccountResponse(Raw.Lookup(acct));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public MastodonAccountResponse Lookup(MastodonAccountLookupOptions options) {
        return new MastodonAccountResponse(Raw.Lookup(options));
    }

    /// <summary>
    /// Returns information about the account with the specified username or Webfinger address.
    /// </summary>
    /// <param name="acct">The username or Webfinger address to lookup.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#lookup</cref>
    /// </see>
    public async Task<MastodonAccountResponse> LookupAsync(string acct) {
        return new MastodonAccountResponse(await Raw.LookupAsync(acct));
    }

    /// <summary>
    /// Returns information about the account identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="MastodonAccountResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#get</cref>
    /// </see>
    public async Task<MastodonAccountResponse> LookupAsync(MastodonAccountLookupOptions options) {
        return new MastodonAccountResponse(await Raw.LookupAsync(options));
    }

    #endregion

}