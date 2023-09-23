using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Mastodon.Models.Preview;

/// <summary>
/// Represents a rich preview card that is generated using OpenGraph tags from a URL.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/PreviewCard/</cref>
/// </see>
public class MastodonPreviewCard : MastodonObject {

    #region Properties

    /// <summary>
    /// Gets the location of linked resource.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/PreviewCard/#url</cref>
    /// </see>
    public string Url { get; }

    /// <summary>
    /// Gets the title of linked resource.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/PreviewCard/#title</cref>
    /// </see>
    public string Title { get; }

    /// <summary>
    /// Gets the description of preview.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/PreviewCard/#description</cref>
    /// </see>
    public string Description { get; }

    /// <summary>
    /// Gets the the type of the preview card.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/PreviewCard/#type</cref>
    /// </see>
    public MastodonPreviewType Type { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonPreviewCard(JObject json) : base(json) {
        Url = json.GetString("url")!;
        Title = json.GetString("title")!;
        Description = json.GetString("description")!;
        Type = json.GetEnum<MastodonPreviewType>("type");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the card.</param>
    /// <returns>An instance of <see cref="MastodonPreviewCard"/>.</returns>
    public static MastodonPreviewCard Parse(JObject json) {
        return new MastodonPreviewCard(json);
    }

    #endregion

}