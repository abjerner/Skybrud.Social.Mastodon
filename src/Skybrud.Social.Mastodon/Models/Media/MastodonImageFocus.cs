using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class with information about the focus point of a <see cref="MastodonImageMetaData"/>.
/// </summary>
public class MastodonImageFocus : MastodonObject {

    #region Properties

    public float X { get; }

    public float Y { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>

    protected MastodonImageFocus(JObject json) : base(json) {
        X = json.GetFloat("x");
        Y = json.GetFloat("y");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the focus point.</param>
    /// <returns>An instance of <see cref="MastodonImageFocus"/>.</returns>
    public static MastodonImageFocus Parse(JObject json) {
        return new MastodonImageFocus(json);
    }

    #endregion

}