# Skybrud.Social.Mastodon

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/abjerner/Skybrud.Social.Mastodon/blob/v1/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/vpre/Skybrud.Social.Mastodon.svg)](https://www.nuget.org/packages/Skybrud.Social.Mastodon)
[![NuGet](https://img.shields.io/nuget/dt/Skybrud.Social.Mastodon.svg)](https://www.nuget.org/packages/Skybrud.Social.Mastodon)


.NET API wrapper and implementation of the [**Mastodon API**](https://docs.joinmastodon.org/client/intro/).

<table>
  <tr>
    <td><strong>License:</strong></td>
    <td><a href="https://github.com/abjerner/Skybrud.Social.Mastodon/blob/v1/main/LICENSE.md"><strong>MIT License</strong></a></td>
  </tr>
  <tr>
    <td><strong>Target Framework:</strong></td>
    <td>
      .NET Standard 2.0, .NET 6 and .NET 7
    </td>
  </tr>
</table>





<br /><br />

## Installation

The package is only available via [**NuGet**](https://www.nuget.org/packages/Skybrud.Social.Mastodon/1.0.0-alpha001). To install the package, you can either use the .NET CLI:

```
dotnet add package Skybrud.Social.Mastodon --version 1.0.0-alpha001
```

or the NuGet Package Manager:

```
Install-Package Skybrud.Social.Mastodon -Version 1.0.0-alpha001
```




<br /><br />

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
