using System.Collections.Generic;
using System.Text.Json.Serialization;

// https://json2csharp.com/
public record SearchResultKnownFor(
    [property: JsonPropertyName("adult")] bool Adult,
    [property: JsonPropertyName("genre_ids")] IReadOnlyList<int> GenreIds,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("media_type")] string MediaType,
    [property: JsonPropertyName("original_language")] string OriginalLanguage,
    [property: JsonPropertyName("original_title")] string OriginalTitle,
    [property: JsonPropertyName("overview")] string Overview,
    [property: JsonPropertyName("poster_path")] string PosterPath,
    [property: JsonPropertyName("release_date")] string ReleaseDate,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("video")] bool Video,
    [property: JsonPropertyName("vote_average")] int VoteAverage,
    [property: JsonPropertyName("vote_count")] int VoteCount
);

public record SearchResult(
    [property: JsonPropertyName("backdrop_path")] string BackdropPath,
    [property: JsonPropertyName("first_air_date")] string FirstAirDate,
    [property: JsonPropertyName("genre_ids")] IReadOnlyList<int> GenreIds,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("media_type")] string MediaType,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("origin_country")] IReadOnlyList<string> OriginCountry,
    [property: JsonPropertyName("original_language")] string OriginalLanguage,
    [property: JsonPropertyName("original_name")] string OriginalName,
    [property: JsonPropertyName("overview")] string Overview,
    [property: JsonPropertyName("popularity")] double Popularity,
    [property: JsonPropertyName("poster_path")] string PosterPath,
    [property: JsonPropertyName("vote_average")] double VoteAverage,
    [property: JsonPropertyName("vote_count")] int VoteCount,
    [property: JsonPropertyName("adult")] bool? Adult,
    [property: JsonPropertyName("original_title")] string OriginalTitle,
    [property: JsonPropertyName("release_date")] string ReleaseDate,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("video")] bool? Video,
    [property: JsonPropertyName("gender")] int? Gender,
    [property: JsonPropertyName("known_for")] IReadOnlyList<SearchResultKnownFor> KnownFor,
    [property: JsonPropertyName("known_for_department")] string KnownForDepartment,
    [property: JsonPropertyName("profile_path")] object ProfilePath
);

public record SearchResultRoot(
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("results")] IReadOnlyList<SearchResult> Results,
    [property: JsonPropertyName("total_pages")] int TotalPages,
    [property: JsonPropertyName("total_results")] int TotalResults
);

