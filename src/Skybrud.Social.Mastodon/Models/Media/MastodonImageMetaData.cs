using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing the meta data of an image <see cref="MastodonMediaAttachment"/>.
/// </summary>
public class MastodonImageMetaData : MastodonMediaMetaData {

    #region Properties

    /// <summary>
    /// Gets an object describing the original version of the image.
    /// </summary>
    public MastodonImageVersion Original { get; }

    /// <summary>
    /// Gets an object describing a small version of the image.
    /// </summary>
    public MastodonImageVersion Small { get; }

    /// <summary>
    /// Gets an object describing the focus point of the image.
    /// </summary>
    public MastodonImageFocus Focus { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonImageMetaData(JObject json) : base(json) {
        Original = json.GetObject("original", MastodonImageVersion.Parse)!;
        Small = json.GetObject("small", MastodonImageVersion.Parse)!;
        Focus = json.GetObject("focus", MastodonImageFocus.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the image meta data.</param>
    /// <returns>An instance of <see cref="MastodonImageMetaData"/>.</returns>
    public static MastodonImageMetaData Parse(JObject json) {
        return new MastodonImageMetaData(json);
    }

    #endregion

}