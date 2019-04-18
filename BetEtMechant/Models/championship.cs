using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Class.Validators;
using Microsoft.AspNetCore.Builder;

namespace BetEtMechant.Models
{
    public class Championship : BaseModel
    {
        [Display(Name = "name", Prompt = "Name")]
        [StringLength(50)]
        [Required]
        [Unique]
        public string Name { get; set; }
    }
}
