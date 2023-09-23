using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Mastodon.Models.Accounts;

/// <summary>
/// Class representing a Mastodon account.
/// </summary>
/// <see>
///     <cref>https://docs.joinmastodon.org/entities/Account/</cref>
/// </see>
public class MastodonAccount : MastodonObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#id</cref>
    /// </see>
    public string Id { get; }

    /// <summary>
    /// Gets the username of the account, not including domain.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#username</cref>
    /// </see>
    public string Username { get; }

    /// <summary>
    /// Gets the Webfinger account URI. Equal to <see cref="Username"/> for local users, or <code>username@domain</code> for remote users.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#acct</cref>
    /// </see>
    public string Acct { get; }

    /// <summary>
    /// Gets the location of the user’s profile page.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#url</cref>
    /// </see>
    public string Url { get; }

    /// <summary>
    /// Gets the profile’s display name.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#display_name</cref>
    /// </see>
    public string DisplayName { get; }

    /// <summary>
    /// Gets when the account was created.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#created_at</cref>
    /// </see>
    public EssentialsTime CreatedTime { get; }

    /// <summary>
    /// Gets the profile’s bio or description.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#note</cref>
    /// </see>
    public string Note { get; }

    /// <summary>
    /// Gets the reported followers of this profile.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#followers_count</cref>
    /// </see>
    public int FollowersCount { get; }

    /// <summary>
    /// Gets the reported follows of this profile.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#following_count</cref>
    /// </see>
    public int FollowingCount { get; }

    /// <summary>
    /// Gets how many statuses are attached to this account.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#statuses_count</cref>
    /// </see>
    public int StatusesCount { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The JSON object representing the instance.</param>
    protected MastodonAccount(JObject json) : base(json) {
        Id = json.GetString("id")!;
        Username = json.GetString("username")!;
        Acct = json.GetString("acct")!;
        Url = json.GetString("url")!;
        DisplayName = json.GetString("display_name")!;
        CreatedTime = json.GetString("created_at", EssentialsTime.Parse)!;
        Note = json.GetString("note")!;
        FollowersCount = json.GetInt32("followers_count");
        FollowingCount = json.GetInt32("following_count");
        StatusesCount = json.GetInt32("statuses_count");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The JSON object representing the account.</param>
    /// <returns>An instance of <see cref="MastodonAccount"/>.</returns>
    public static MastodonAccount Parse(JObject json) {
        return new MastodonAccount(json);
    }

    #endregion

}