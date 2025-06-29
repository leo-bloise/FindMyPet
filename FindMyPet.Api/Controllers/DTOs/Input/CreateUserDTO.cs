using System.ComponentModel.DataAnnotations;

namespace FindMyPet.Api.Controllers.DTOs.Input;

public record CreateUserDTO(
    [Required]
    [Length(11, 11)]
    string Telephone,
    [Required]
    [MinLength(3)]
    string Password,
    [Required]
    [MinLength(3)]
    string Name);