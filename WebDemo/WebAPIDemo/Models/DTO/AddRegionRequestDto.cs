using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be minimum 3 characters")]
        [MaxLength(3, ErrorMessage = "Code can only be maximum 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(3, ErrorMessage = "Name can only be maximum 100 characters")]
        public string Name { get; set; }
        public string? RegionImgUrl { get; set; }
    }
}
