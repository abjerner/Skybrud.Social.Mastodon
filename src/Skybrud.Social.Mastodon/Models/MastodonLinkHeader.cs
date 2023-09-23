using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.Mastodon.Models;

/// <summary>
/// Class representing the <c>Link</c> header of a HTTP response from the Mastodon API.
/// </summary>
public class MastodonLinkHeader {

    #region Properties

    /// <summary>
    /// Gets the URL of the next page.
    /// </summary>
    public string? NextUrl { get; }

    /// <summary>
    /// Gets the maximum ID used for fetching the next page.
    /// </summary>
    public string? MaxId { get; }

    /// <summary>
    /// Gets whether the list has a next page.
    /// </summary>
    [MemberNotNullWhen(true, "MaxId")]
    [MemberNotNullWhen(true, "NextUrl")]
    public bool HasNextPage => !string.IsNullOrWhiteSpace(NextUrl);

    /// <summary>
    /// Gets the URL of the previous page.
    /// </summary>
    public string? PreviousUrl { get; }

    /// <summary>
    /// Gets the minimum ID used for fetching the next page.
    /// </summary>
    public string? MinId { get; }

    /// <summary>
    /// Gets whether the list has a previous page.
    /// </summary>
    [MemberNotNullWhen(true, "MinId")]
    [MemberNotNullWhen(true, "PreviousUrl")]
    public bool HasPreviousPage => !string.IsNullOrWhiteSpace(PreviousUrl);

    #endregion

    #region Constructors

    private MastodonLinkHeader(string value) {

        if (string.IsNullOrWhiteSpace(value)) return;

        // Match the different URLs using REGEX
        foreach (Match match in Regex.Matches(value, "\\<(.+?)\\>; rel=\"([a-z]+)\"")) {

            string url = match.Groups[1].Value;
            string rel = match.Groups[2].Value;

            switch (rel) {

                case "prev":
                    if (!RegexUtils.IsMatch(value, "min_id=([0-9]+)", out string minId)) continue;
                    PreviousUrl = url;
                    MinId = minId;
                    break;

                case "next":
                    if (!RegexUtils.IsMatch(value, "max_id=([0-9]+)", out string maxId)) continue;
                    NextUrl = url;
                    MaxId = maxId;
                    break;

            }

        }

    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the <c>Link</c> header from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The response.</param>
    /// <returns>An instance of <see cref="MastodonLinkHeader"/>.</returns>
    public static MastodonLinkHeader Parse(IHttpResponse response) {
        return new MastodonLinkHeader(response.Headers["Link"] ?? string.Empty);
    }

    #endregion

}