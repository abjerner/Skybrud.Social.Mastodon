using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591

namespace Skybrud.Social.Mastodon.Models.Media;

/// <summary>
/// Class representing the meta data of an audio <see cref="MastodonMediaAttachment"/>.
/// </summary>
public class MastodonAudioMetaData : MastodonMediaMetaData {

    #region Properties

    public string Length { get; }

    public TimeSpan Duration { get; }

    public double Aspect { get; }

    public string AudioEncode { get; }

    public string AudioBitrate { get; }

    public string AudioChannels { get; }

    public MastodonAudioVersion Original { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonAudioMetaData(JObject json) : base(json) {
        Length = json.GetString("length")!;
        Duration = json.GetDouble("duration", TimeSpan.FromSeconds);
        Aspect = json.GetDouble("aspect");
        AudioEncode = json.GetString("audio_encode")!;
        AudioBitrate = json.GetString("audio_bitrate")!;
        AudioChannels = json.GetString("audio_channels")!;
        Original = json.GetObject("original", MastodonAudioVersion.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the audio meta data.</param>
    /// <returns>An instance of <see cref="MastodonAudioMetaData"/>.</returns>
    public static MastodonAudioMetaData Parse(JObject json) {
        return new MastodonAudioMetaData(json);
    }

    #endregion

}