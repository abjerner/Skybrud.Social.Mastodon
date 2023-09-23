using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing a version of a <see cref="MastodonAudioMetaData"/>.
/// </summary>
public class MastodonAudioVersion {

    #region Properties

    /// <summary>
    /// Gets the duration of the audio clip.
    /// </summary>
    public TimeSpan Duration { get; }

    /// <summary>
    /// Gets the bit rate of the audio clip.
    /// </summary>
    public int BitRate { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonAudioVersion(JObject json) {
        Duration = json.GetDouble("duration", TimeSpan.FromSeconds);
        BitRate = json.GetInt32("bitrate");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the video meta data.</param>
    /// <returns>An instance of <see cref="MastodonAudioVersion"/>.</returns>
    public static MastodonAudioVersion Parse(JObject json) {
        return new MastodonAudioVersion(json);
    }

    #endregion

}