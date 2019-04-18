using BetEtMechant.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Class.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string saisie = (string)value;
            var dbContext = validationContext.GetService(typeof(BetDbContext)) as BetDbContext;

            var propertyName = validationContext.MemberName;
            var classType = validationContext.ObjectType;

            if (dbContext != null)
            {
                dynamic dbset = dbContext.GetType().GetProperties().SingleOrDefault(x => x.PropertyType.FullName.Contains(classType.FullName));

                var query = (IQueryable)dbset.GetValue(dbContext);

                foreach (var item in query)
                {
                    dynamic temp = Convert.ChangeType(item, classType);
                    if (saisie.Equals(temp.GetType().GetProperty(propertyName).GetValue(temp, null)))
                        return new ValidationResult("L'élement existe déjà");
                }

                return ValidationResult.Success;
            }
            return new ValidationResult("Impossible de faire le test unique.");
        }
    }
}
