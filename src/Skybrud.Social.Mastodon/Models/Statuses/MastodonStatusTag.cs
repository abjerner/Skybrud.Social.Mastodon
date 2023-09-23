using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Mastodon.Models.Statuses;

/// <summary>
/// Class representing a tag in a <see cref="MastodonStatus"/>.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/Status/#Tag</cref>
/// </see>
public class MastodonStatusTag : MastodonObject {

    #region Properties

    /// <summary>
    /// Gets the value of the hashtag after the # sign.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#Tag-name</cref>
    /// </see>
    public string Name { get; }

    /// <summary>
    /// Gets a link to the hashtag on the instance.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Status/#Tag-url</cref>
    /// </see>
    public string Url { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonStatusTag(JObject json) : base(json) {
        Name = json.GetString("name")!;
        Url = json.GetString("url")!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the tag.</param>
    /// <returns>An instance of <see cref="MastodonStatusTag"/>.</returns>
    public static MastodonStatusTag Parse(JObject json) {
        return new MastodonStatusTag(json);
    }

    #endregion

}