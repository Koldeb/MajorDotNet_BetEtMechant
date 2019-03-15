using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BetEtMechant.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Nom", Prompt = "Votre nom")]
        [Required(ErrorMessage = "{0} obligatoire")]
        public string Name { get; set; }

        [Display(Name = "Prenom", Prompt = "Votre prénom")]
        public string Firstname { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.DateTime)]
        [Age(18, ErrorMessage ="Vous n'avez pas {1} ans")]
        public DateTime BirthDate { get; set; }

        [Display(Name="Email address", Prompt="exemple@exemple.com")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="{0} obligatoire")]
        [EmailAddress(ErrorMessage ="{0} n'est pas au bon format")]
        public string Email{ get; set; }

        [Display(Name = "Password", Prompt = "password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} obligatoire")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "{0} doit contenit entre {2} et {1} caractères")]
        public string Password { get; set; }

        [Display(Name = "Confirmation mot de passe", Prompt = "password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="{0} n'est pas identique au password")]
        public string ConfirmPassword { get; set; }
    }
}
