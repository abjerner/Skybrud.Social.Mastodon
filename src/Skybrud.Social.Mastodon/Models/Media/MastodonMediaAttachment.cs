using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Represents a file or media attachment that can be added to a status.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/</cref>
/// </see>
public class MastodonMediaAttachment : MastodonObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the attachment.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#id</cref>
    /// </see>
    public string Id { get; }

    /// <summary>
    /// Gets the type of the attachment.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#type</cref>
    /// </see>
    public MastodonMediaType Type { get; }

    /// <summary>
    /// Gets the location of the original full-size attachment.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#url</cref>
    /// </see>
    public string Url { get; }

    /// <summary>
    /// Gets the location of a scaled-down preview of the attachment.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#preview_url</cref>
    /// </see>
    public string PreviewUrl { get; }

    /// <summary>
    /// Gets the location of the full-size original attachment on the remote website.
    /// </summary>
    public string? RemoteUrl { get; }

    /// <summary>
    /// Metadata returned by Paperclip.
    /// </summary>
    public MastodonMediaMetaData Meta { get; }

    /// <summary>
    /// Gets an alternate text that describes what is in the media attachment, to be used for the visually impaired or when media attachments do not load.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#description</cref>
    /// </see>
    public string? Description { get; }

    /// <summary>
    /// A hash computed by the <a href="https://github.com/woltapp/blurhash" target="_blank">BlurHash algorithm</a>, for generating colorful preview thumbnails when media has not been downloaded yet.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#blurhash</cref>
    /// </see>
    public string BlurHash { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonMediaAttachment(JObject json) : base(json) {
        Id = json.GetString("id")!;
        Type = json.GetEnum<MastodonMediaType>("type");
        Url = json.GetString("url")!;
        PreviewUrl = json.GetString("preview_url")!;
        RemoteUrl = json.GetString("remote_url");
        Meta = json.GetObject("meta", ParseMetaData)!;
        Description = json.GetString("description");
        BlurHash = json.GetString("blurhash")!;
    }

    #endregion

    #region Member methods

    private MastodonMediaMetaData ParseMetaData(JObject json) {
        return Type switch {
            MastodonMediaType.Image => MastodonImageMetaData.Parse(json),
            MastodonMediaType.Video => MastodonVideoMetaData.Parse(json),
            MastodonMediaType.Gifv => MastodonGifvMetaData.Parse(json),
            MastodonMediaType.Audio => MastodonAudioMetaData.Parse(json),
            _ => new MastodonMediaMetaData(json)
        };
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the tag.</param>
    /// <returns>An instance of <see cref="MastodonMediaAttachment"/>.</returns>
    public static MastodonMediaAttachment Parse(JObject json) {
        return new MastodonMediaAttachment(json);
    }

    #endregion

}