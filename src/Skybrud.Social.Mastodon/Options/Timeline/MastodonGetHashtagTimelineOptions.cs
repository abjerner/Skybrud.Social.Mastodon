using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Mastodon.Options.Timeline;

/// <summary>
/// Class with options for getting public statuses containing the given hashtag.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/timelines/#tag</cref>
/// </see>
public class MastodonGetHashtagTimelineOptions : MastodonHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the name of the hashtag (not including the # symbol).
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Hashtag { get; set; }
#else
    public string? Hashtag { get; set; }
#endif

    /// <summary>
    /// Show only local statuses?
    /// </summary>
    public bool Local { get; set; }

    /// <summary>
    /// Show only remote statuses?
    /// </summary>
    public bool Remote { get; set; }

    /// <summary>
    /// Show only statuses with media attached?
    /// </summary>
    public bool OnlyMedia { get; set; }

    /// <summary>
    /// All results returned will be lesser than this ID. In effect, sets an upper bound on results.
    /// </summary>
    public string? MaxId { get; set; }

    /// <summary>
    /// All results returned will be greater than this ID. In effect, sets a lower bound on results.
    /// </summary>
    public string? SinceId { get; set; }

    /// <summary>
    /// Returns results immediately newer than this ID. In effect, sets a cursor at this ID and paginates forward.
    /// </summary>
    public string? MinId { get; set; }

    /// <summary>
    /// Maximum number of results to return. Defaults to 20 statuses. Max 40 statuses.
    /// </summary>
    [ValueRange(1, 40)]
    public int? Limit { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public MastodonGetHashtagTimelineOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified hashtag.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonGetHashtagTimelineOptions(string hashtag) {
        Hashtag = hashtag;
    }

    /// <summary>
    /// Initializes a new instance based on the specified hashtag.
    /// </summary>
    /// <param name="hashtag">The name of the hashtag (not including the # symbol).</param>
    /// <param name="limit">The maximum number of results to return.</param>
    /// <param name="maxId">All results returned will be lesser than this ID. In effect, sets an upper bound on results.</param>
#if NET7_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public MastodonGetHashtagTimelineOptions(string hashtag, [ValueRange(1, 40)] int? limit, string? maxId) {
        Hashtag = hashtag;
        Limit = limit;
        MaxId = maxId;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest(MastodonHttpClient client) {

        if (string.IsNullOrWhiteSpace(Hashtag)) throw new PropertyNotSetException(nameof(Hashtag));

        // Construct the query string
        HttpQueryString query = new();
        if (Local) query.Add("local", "true");
        if (Remote) query.Add("remote", "true");
        if (OnlyMedia) query.Add("only_media", "true");
        if (!string.IsNullOrWhiteSpace(MaxId)) query.Add("max_id", MaxId);
        if (!string.IsNullOrWhiteSpace(SinceId)) query.Add("since_id", SinceId);
        if (!string.IsNullOrWhiteSpace(MinId)) query.Add("min_id", MinId);
        if (Limit is not null) query.Add("limit", Limit);

        // Initialize a new HTTP request
        return HttpRequest.Get($"/api/v1/timelines/tag/{Hashtag}", query);

    }

    #endregion

}