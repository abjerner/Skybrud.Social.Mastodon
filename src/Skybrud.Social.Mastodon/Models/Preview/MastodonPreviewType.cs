namespace Skybrud.Social.Mastodon.Models.Preview;

/// <summary>
/// Enum class representing the type of a <see cref="MastodonPreviewCard"/>.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/PreviewCard/#type</cref>
/// </see>
public enum MastodonPreviewType {

    /// <summary>
    /// Link OEmbed.
    /// </summary>
    Link,

    /// <summary>
    /// Photo OEmbed.
    /// </summary>
    Photo,

    /// <summary>
    /// Video OEmbed.
    /// </summary>
    Video,

    /// <summary>
    /// iframe OEmbed. Not currently accepted, so won’t show up in practice.
    /// </summary>
    Rich

}
