namespace coursesApi.Dtos;

// Records are immutable
public record class CourseDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);

