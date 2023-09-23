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
    /// Gets the URI of the account. <strong>This property is not documented by the Mastodon API documentation.</strong>
    /// </summary>
    public string Uri { get; }

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
    /// An image icon that is shown next to statuses and in the profile.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#avatar</cref>
    /// </see>
    public string Avatar { get; }

    /// <summary>
    /// A static version of the avatar. Equal to <see cref="Avatar"/> if its value is a static image; different if <see cref="Avatar"/> is an animated GIF.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#avatar_static</cref>
    /// </see>
    public string AvatarStatic { get; }

    /// <summary>
    /// An image banner that is shown above the profile and in profile cards.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#header</cref>
    /// </see>
    public string Header { get; }

    /// <summary>
    /// A static version of the header. Equal to header if its value is a static image; different if header is an animated GIF.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#header_static</cref>
    /// </see>
    public string HeaderStatic { get; }


    /// <summary>
    /// Gets whether the account manually approves follow requests.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#locked</cref>
    /// </see>
    public bool IsLocked { get; }

    /// <summary>
    /// Gets whether the account may perform automated actions, may not be monitored, or identifies as a robot.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#bot</cref>
    /// </see>
    public bool IsBot { get; }

    /// <summary>
    /// Gets whether the account has opted into discovery features such as the profile directory.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#discoverable</cref>
    /// </see>
    public bool? IsDiscoverable { get; }

    /// <summary>
    /// Gets whether the account represents a group actor.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#group</cref>
    /// </see>
    public bool IsGroup { get; }

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

    /// <summary>
    /// Gets when the most recent status was posted, or <see langword="null"/> if the account hasn't posted yet.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.joinmastodon.org/entities/Account/#last_status_at</cref>
    /// </see>
    public EssentialsDate? LastStatusAt { get; }

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
        Uri = json.GetString("uri")!;
        DisplayName = json.GetString("display_name")!;
        CreatedTime = json.GetString("created_at", EssentialsTime.Parse)!;
        Note = json.GetString("note")!;
        Avatar = json.GetString("avatar")!;
        AvatarStatic = json.GetString("avatar_static")!;
        Header = json.GetString("header")!;
        HeaderStatic = json.GetString("hedder_static")!;
        IsLocked = json.GetBoolean("locked");
        IsBot = json.GetBoolean("bot");
        IsDiscoverable = json.GetBooleanOrNull("discoverable");
        IsGroup = json.GetBoolean("group");
        FollowersCount = json.GetInt32("followers_count");
        FollowingCount = json.GetInt32("following_count");
        StatusesCount = json.GetInt32("statuses_count");
        LastStatusAt = json.GetString("last_status_at", EssentialsDate.Parse);
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