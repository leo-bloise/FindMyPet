using System.ComponentModel.DataAnnotations;

namespace FindMyPet.Api.Controllers.DTOs.Input;

public record CreateHomeDTO(
    [Required]
    double Latitude,
    [Required]
    double Longitude
    );