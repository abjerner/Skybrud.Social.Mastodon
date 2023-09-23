using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http;
using System.Diagnostics.CodeAnalysis;

namespace Skybrud.Social.Mastodon.Options.Accounts;

/// <summary>
/// Options class for looking up an account from a useranem or Webfinger address.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/accounts/#lookup</cref>
/// </see>
public class MastodonAccountLookupOptions : MastodonHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the username or Webfinger address to lookup.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/methods/accounts/#query-parameters-6</cref>
    /// </see>
#if NET7_0_OR_GREATER
    public required string Acct { get; set; }
#else
    public string? Acct { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public MastodonAccountLookupOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified username or Webfinger address.
    /// </summary>
    /// <param name="acct">The username or Webfinger address to lookup.</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonAccountLookupOptions(string acct) {
        Acct = acct;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest(MastodonHttpClient client) {

        // Validate required properties
        if (string.IsNullOrWhiteSpace(Acct)) throw new PropertyNotSetException(nameof(Acct));

        // Construct the query string
        HttpQueryString query = new() {
            { "Acct", Acct }
        };

        // Initialize a new HTTP request
        return HttpRequest.Get("/api/v1/accounts/lookup", query);

    }

    #endregion

}