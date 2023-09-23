using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Mastodon.Models.Accounts;
using Skybrud.Social.Mastodon.Models.Media;
using Skybrud.Social.Mastodon.Models.Preview;

namespace Skybrud.Social.Mastodon.Models.Statuses;

/// <summary>
/// Represents a Mastodon status.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/Status/</cref>
/// </see>
public class MastodonStatus : MastodonObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the status.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#id</cref>
    /// </see>
    public string Id { get; }

    /// <summary>
    /// Gets the date when this status was created.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#created_at</cref>
    /// </see>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets the ID of the status being replied to.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#in_reply_to_id</cref>
    /// </see>
    public string? InReplyToId { get; }

    /// <summary>
    /// Gets the ID of the account that authored the status being replied to.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#in_reply_to_account_id</cref>
    /// </see>
    public string? InReplyToAccountId { get; }

    /// <summary>
    /// Gets whether the status is status marked as sensitive content.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#sensitive</cref>
    /// </see>
    public bool IsSensitive { get; }

    /// <summary>
    /// Gets or sets a subject or summary line, below which status content is collapsed until expanded.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#spoiler_text</cref>
    /// </see>
    public string SpoilerText { get; }

    /// <summary>
    /// Gets the visibility of this status.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#visibility</cref>
    /// </see>
    public MastodonStatusVisibility Visibility { get; }

    ///  <summary>
    /// Gets the primary language of the status.
    ///  </summary>
    ///  <see>
    ///      <cref>https://docs.joinmastodon.org/entities/Status/#language</cref>
    ///  </see>
    public string? Language { get; }

    /// <summary>
    /// Gets the URI of the status. <strong>This property is not documented by the Mastodon API documentation.</strong>
    /// </summary>
    public string? Uri { get; }

    /// <summary>
    /// A link to the status’s HTML representation.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#url</cref>
    /// </see>
    public string? Url { get; }

    /// <summary>
    /// How many replies this status has received.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#replies_count</cref>
    /// </see>
    public int RepliesCount { get; }

    /// <summary>
    /// How many boosts this status has received.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#reblogs_count</cref>
    /// </see>
    public int ReblogsCount { get; }

    /// <summary>
    /// Gets a timestamp for when the status was last edited, or <see langword="null"/> if the status hasn't been edited.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#edited_at</cref>
    /// </see>
    public EssentialsTime? EditedAt { get; }

    /// <summary>
    /// Gets how many favourites this status has received.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#favorites_count</cref>
    /// </see>
    public int FavouritesCount { get; }

    /// <summary>
    /// Gets the HTML-encoded content of the status.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#content</cref>
    /// </see>
    public string Content { get; }

    ///  <summary>
    /// Gets information about the account that authored this status.
    ///  </summary>
    ///  <see>
    ///      <cref>https://docs.joinmastodon.org/entities/Status/#account</cref>
    ///  </see>
    public MastodonAccount Account { get; }

    /// <summary>
    /// Gets information about the media that is attached to this status.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#media_attachments</cref>
    /// </see>
    public IReadOnlyList<MastodonMediaAttachment> MediaAttachments { get; }

    /// <summary>
    /// Gets the hashtags used within the status content.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#tags</cref>
    /// </see>
    public IReadOnlyList<MastodonStatusTag> Tags { get; }

    /// <summary>
    /// Preview card for links included within status content.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#card</cref>
    /// </see>
    public MastodonPreviewCard? Card { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonStatus(JObject json) : base(json) {
        Id = json.GetString("id")!;
        CreatedAt = json.GetString("created_at", EssentialsTime.Parse)!;
        InReplyToId = json.GetString("in_reply_to_id");
        InReplyToAccountId = json.GetString("in_reply_to_account_id");
        IsSensitive = json.GetBoolean("sensitive");
        SpoilerText = json.GetString("spoiler_text")!;
        Visibility = json.GetEnum<MastodonStatusVisibility>("visibility");
        Language = json.GetString("language");
        Uri = json.GetString("uri");
        Url = json.GetString("url");
        RepliesCount = json.GetInt32("replies_count");
        ReblogsCount = json.GetInt32("reblogs_count");
        FavouritesCount = json.GetInt32("favourites_count");
        EditedAt = json.GetString("edited_at", EssentialsTime.Parse);
        Content = json.GetString("content")!;
        Account = json.GetObject("account", MastodonAccount.Parse)!;
        MediaAttachments = json.GetArrayItems("media_attachments", MastodonMediaAttachment.Parse);
        Tags = json.GetArrayItems("tags", MastodonStatusTag.Parse);
        Card = json.GetObject("card", MastodonPreviewCard.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the status.</param>
    /// <returns>An instance of <see cref="MastodonStatus"/>.</returns>
    public static MastodonStatus Parse(JObject json) {
        return new MastodonStatus(json);
    }

    #endregion

}