using System.Collections.Generic;
using System.Text.Json.Serialization;

public record ImageInformation(
    [property: JsonPropertyName("base_url")] string BaseUrl,
    [property: JsonPropertyName("secure_base_url")] string SecureBaseUrl,
    [property: JsonPropertyName("backdrop_sizes")] IReadOnlyList<string> BackdropSizes,
    [property: JsonPropertyName("logo_sizes")] IReadOnlyList<string> LogoSizes,
    [property: JsonPropertyName("poster_sizes")] IReadOnlyList<string> PosterSizes,
    [property: JsonPropertyName("profile_sizes")] IReadOnlyList<string> ProfileSizes,
    [property: JsonPropertyName("still_sizes")] IReadOnlyList<string> StillSizes
);

public record ConfigurationRoot(
    [property: JsonPropertyName("images")] ImageInformation? ImageInformation,
    [property: JsonPropertyName("change_keys")] IReadOnlyList<string> ChangeKeys
);