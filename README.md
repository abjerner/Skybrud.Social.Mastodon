# Skybrud.Social.Mastodon

.NET API wrapper and implementation of the Mastodon API.




## Examples

### Getting a public timeline

The example below shows how to get the 40 most recent status from the public timeline of the [**umbracocommunity.social**](https://umbracocommunity.social/) server.

By the default the API will return statuses from all Mastodon servers, but the `Local = true` will ensure that only statuses from the [**umbracocommunity.social**](https://umbracocommunity.social/) server are returned.

```cshtml
@using Skybrud.Social.Mastodon
@using Skybrud.Social.Mastodon.Options.Timeline
@using Skybrud.Social.Mastodon.Responses.Statuses

@{

    // Initialize a new HTTP service (basically the API wrapper)
    MastodonHttpService mastodon = MastodonHttpService.CreateFromDomain("umbracocommunity.social");

    // Initialize the options for the request to the API
    MastodonGetPublicTimelineOptions options = new() {
        Limit = 40,
        Local = true
    };

    // Make the request to the API
    MastodonStatusListResponse response = await mastodon
        .Timelines
        .GetPublicTimelineAsync(options);

    // Iterate through the first 40 statuses
    foreach (var status in response.Body) {

        <pre>@status.Account.DisplayName - @status.Content</pre>

    }

}
```

### Getting a hashtag timeline

The example below shows how to get the 40 most recent status from the [#Umbraco](https://umbracocommunity.social/tags/Umbraco) hashtag.

Although this example uses the [**umbracocommunity.social**](https://umbracocommunity.social/), the returned status may also come from other Mastodon servers. To only return local statuses, you can add `Local = true` to the options.

```cshtml
@using Skybrud.Social.Mastodon
@using Skybrud.Social.Mastodon.Options.Timeline
@using Skybrud.Social.Mastodon.Responses.Statuses

@{

    // Initialize a new HTTP service (basically the API wrapper)
    MastodonHttpService mastodon = MastodonHttpService.CreateFromDomain("umbracocommunity.social");

    // Initialize the options for the request to the API
    MastodonGetHashtagTimelineOptions options = new() {
        Hashtag = "umbraco",
        Limit = 40,
        //Local = true
    };

    // Make the request to the API
    MastodonStatusListResponse response = await mastodon
        .Timelines
        .GetHashtagTimelineAsync(options);

    // Iterate through the first 40 statuses
    foreach (var status in response.Body) {

        <pre>@status.CreatedAt - @status.Account.DisplayName - @status.Content</pre>

    }

}
```
