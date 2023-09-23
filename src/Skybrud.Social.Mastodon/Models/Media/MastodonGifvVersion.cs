using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing a version of a <see cref="MastodonGifvMetaData"/>.
/// </summary>
public class MastodonGifvVersion : MastodonObject {

    #region Properties

    public int Width { get; }

    public int Height { get; }

    public string FrameRate { get; }

    public TimeSpan Duration { get; }

    public int BitRate { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonGifvVersion(JObject json) : base(json) {
        Width = json.GetInt32("width");
        Height = json.GetInt32("height");
        FrameRate = json.GetString("frame_rate")!;
        Duration = json.GetDouble("duration", TimeSpan.FromSeconds);
        BitRate = json.GetInt32("bitrate");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the GIFV version.</param>
    /// <returns>An instance of <see cref="MastodonGifvVersion"/>.</returns>
    public static MastodonGifvVersion Parse(JObject json) {
        return new MastodonGifvVersion(json);
    }

    #endregion

}