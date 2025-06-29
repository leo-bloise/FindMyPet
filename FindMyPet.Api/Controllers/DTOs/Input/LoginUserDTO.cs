using System.ComponentModel.DataAnnotations;

namespace FindMyPet.Api.Controllers.DTOs.Input;

public record LoginUserDTO(
    [Required]
    string Telephone,
    [Required]
    string Password);