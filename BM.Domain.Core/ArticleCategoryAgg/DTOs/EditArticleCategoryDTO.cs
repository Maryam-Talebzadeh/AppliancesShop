using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Domain.Core.ArticleCategoryAgg.DTOs
{
    public class EditArticleCategoryDTO : CreateArticleCategoryDTO
    {
        public long Id { get; set; }
    }
}
