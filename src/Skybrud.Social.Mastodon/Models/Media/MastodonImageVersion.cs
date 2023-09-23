using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing a version of a <see cref="MastodonImageMetaData"/>.
/// </summary>
public class MastodonImageVersion : MastodonObject {

    #region Properties

    /// <summary>
    /// Gets the width of the version.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of the version.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the size of the version.
    /// </summary>
    public string Size { get; }

    /// <summary>
    /// Gets the aspect ratio of the version.
    /// </summary>
    public double Aspect { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonImageVersion(JObject json) : base(json) {
        Width = json.GetInt32("width");
        Height = json.GetInt32("height");
        Size = json.GetString("size")!;
        Aspect = json.GetDouble("aspect");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the image version.</param>
    /// <returns>An instance of <see cref="MastodonImageVersion"/>.</returns>
    public static MastodonImageVersion Parse(JObject json) {
        return new MastodonImageVersion(json);
    }

    #endregion

}