using System;
using System.ComponentModel.DataAnnotations;
using Shared.Dtos.Base;

namespace Shared.Dtos
{
    public class ProductDto : DtoBase<string>
    {
        public ProductDto()
        {
            Id = Guid.NewGuid().ToString();
        }

        public ProductDto(ProductDto productDto)
        {
            Id = productDto.Id;
            EAN = productDto.EAN;
            Description = productDto.Description;
            Name = productDto.Name;
        }

        [Required]
        [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
        public string Name { get; set; }

        [Required] public string EAN { get; set; }
        [Required] public string Description { get; set; }
    }
}