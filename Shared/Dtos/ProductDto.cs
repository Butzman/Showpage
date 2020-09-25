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
        [Required] 
        [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
        public string Name { get; set; }
        [Required] public string EAN { get; set; }
        [Required] public string Description { get; set; }
    }
}