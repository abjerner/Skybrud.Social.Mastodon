namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Enum class representing the type of an attachment.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/MediaAttachment/#type</cref>
/// </see>
public enum MastodonMediaType {

    /// <summary>
    /// Unsupported or unrecognized file type
    /// </summary>
    Unknown,

    /// <summary>
    /// Static image.
    /// </summary>
    Image,

    /// <summary>
    /// Looping, soundless animation.
    /// </summary>
    Gifv,

    /// <summary>
    /// Video clip.
    /// </summary>
    Video,

    /// <summary>
    /// Audio track
    /// </summary>
    Audio

}