using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Class.Validators;
using Microsoft.AspNetCore.Builder;

namespace BetEtMechant.Models
{
    public class Team : BaseModel
    {
        [Display(Name = "name", Prompt = "Name")]
        [StringLength(50)]
        [Required]
        [Unique]
        public string Name { get; set; }

        [Display(Name = "score", Prompt = "Score")]
        [Required]
        public int Score { get; set; }

        [Display(Name = "logo", Prompt = "Logo")]
        public byte[] Logo { get; set; }

        public int ChampionshipID { get; set; }

        [ForeignKey("ChampionshipID")]
        public Championship Championship { get; set; }
    }
}
