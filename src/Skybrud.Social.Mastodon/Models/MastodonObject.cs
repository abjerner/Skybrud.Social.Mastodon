using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Mastodon.Models;

/// <summary>
/// Class representing a Mastodon object.
/// </summary>
public class MastodonObject : JsonObjectBase {

    /// <summary>
    /// Gets a reference to the <see cref="JObject"/> this instance was parsed from.
    /// </summary>
    public new JObject JObject => base.JObject!;

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonObject(JObject json) : base(json) { }

}