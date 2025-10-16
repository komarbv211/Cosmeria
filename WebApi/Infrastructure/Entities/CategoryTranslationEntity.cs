using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    [Table("tblCategoryTranslations")]
    public class CategoryTranslationEntity : BaseEntity<long>
    {
        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        [Required, StringLength(2)]
        public string Language { get; set; } = "uk"; // "uk", "en"

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(4000)]
        public string? Description { get; set; }

        public virtual CategoryEntity Category { get; set; } = null!;
    }
}
