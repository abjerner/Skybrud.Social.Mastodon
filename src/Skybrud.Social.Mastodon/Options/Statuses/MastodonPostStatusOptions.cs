using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.Mastodon.Models.Statuses;

namespace Skybrud.Social.Mastodon.Options.Statuses;

/// <summary>
/// Class with options for publishing a new status.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/methods/statuses/#create</cref>
/// </see>
public class MastodonPostStatusOptions : MastodonHttpRequestOptions {

    #region Member methods

    /// <summary>
    /// Gets or sets the text content of the status.
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the ID of the status being replied to, if status is a reply.
    /// </summary>
    public string? InReplyTo { get; set; }

    /// <summary>
    /// Mark status and attached media as sensitive? Defaults to <see langword="false"/>.
    /// </summary>
    public bool IsSensitive { get; set; }

    /// <summary>
    /// Gets or sets the ext to be shown as a warning or subject before the actual content. Statuses are generally collapsed behind this field.
    /// </summary>
    public string? SpoilerText { get; set; }

    /// <summary>
    /// Gets or sets the the visibility of the status to be created.
    /// </summary>
    public MastodonStatusVisibility? Visibility { get; set; }

    /// <summary>
    /// ISO 639 language code for this status.
    /// </summary>
    public string? Language { get; set; }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest(MastodonHttpClient client) {

        // Validate required properties
        if (string.IsNullOrWhiteSpace(Status)) throw new PropertyNotSetException(nameof(Status));

        HttpPostData form = new();
        if (!string.IsNullOrWhiteSpace(Status)) form.Add("status", Status!);
        if (!string.IsNullOrWhiteSpace(InReplyTo)) form.Add("in_reply_to_id", InReplyTo!);
        if (IsSensitive) form.Add("sensitive", "true");
        if (!string.IsNullOrWhiteSpace(SpoilerText)) form.Add("spoiler_text", SpoilerText!);
        if (Visibility is not null) form.Add("visibility", Visibility.ToLower());
        if (!string.IsNullOrWhiteSpace(Language)) form.Add("language", Language!);

        // Initialize a new POST request
        return HttpRequest.Post("/api/v1/statuses", form);

    }

    #endregion

}