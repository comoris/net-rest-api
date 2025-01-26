using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace coursesApi.Dtos;

public record class CreateCourseDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
