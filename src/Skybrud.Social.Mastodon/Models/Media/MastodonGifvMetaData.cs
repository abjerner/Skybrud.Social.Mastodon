using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing the meta data of a GIFV <see cref="MastodonMediaAttachment"/>.
/// </summary>
public class MastodonGifvMetaData : MastodonMediaMetaData {

    #region Properties

    public string Length { get; }

    public TimeSpan Duration { get; }

    public int Fps { get; }

    public string Size { get; }

    public int Width { get; }

    public int Height { get; }

    public double Aspect { get; }

    public MastodonGifvVersion Original { get; }

    // TODO: Add support for the "small" property

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonGifvMetaData(JObject json) : base(json) {
        Length = json.GetString("length")!;
        Duration = json.GetDouble("duration", TimeSpan.FromSeconds);
        Fps = json.GetInt32("fps");
        Size = json.GetString("size")!;
        Width = json.GetInt32("width");
        Height = json.GetInt32("height");
        Aspect = json.GetDouble("aspect");
        Original = json.GetObject("original", MastodonGifvVersion.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the GIFV version.</param>
    /// <returns>An instance of <see cref="MastodonVideoMetaData"/>.</returns>
    public static MastodonGifvMetaData Parse(JObject json) {
        return new MastodonGifvMetaData(json);
    }

    #endregion

}