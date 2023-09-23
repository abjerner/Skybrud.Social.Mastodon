using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Mastodon.Options.Timeline;

/// <summary>
/// Options for getting a public timeline.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/timelines/#public</cref>
/// </see>
public class MastodonGetPublicTimelineOptions : MastodonHttpRequestOptions {

    #region Properties

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
    public int? Limit { get; set; }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest(MastodonHttpClient client) {

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
        return HttpRequest.Get("/api/v1/timelines/public", query);

    }

    #endregion

}