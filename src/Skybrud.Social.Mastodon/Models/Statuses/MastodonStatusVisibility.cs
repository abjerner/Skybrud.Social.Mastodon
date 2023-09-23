#pragma warning disable CS1591


namespace Skybrud.Social.Mastodon.Models.Statuses;

/// <summary>
/// Enum class representing the visibility of a <see cref="MastodonStatus"/>.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/Status/#visibility</cref>
/// </see>
public enum MastodonStatusVisibility {

    Public,

    Unlisted,

    Private,

    Direct

}