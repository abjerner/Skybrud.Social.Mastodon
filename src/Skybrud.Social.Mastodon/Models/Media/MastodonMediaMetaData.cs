using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing the meta data of a <see cref="MastodonMediaAttachment"/>.
/// </summary>
public class MastodonMediaMetaData : MastodonObject {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    public MastodonMediaMetaData(JObject json) : base(json) { }

}