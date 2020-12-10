using Microsoft.VisualStudio.Modeling.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.NHModelingLanguage
{
    [ValidationState(ValidationState.Enabled)]
    partial class Property
    {
        public string GetDisplayNameValue()
        {
            return this.Name + " : " + this.Type.ToString();
        }

        [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save)]
        public void CheckFirstLetter(ValidationContext context)
        {
            if (!char.IsUpper(this.Name.First()))
                context.LogWarning("First name char should be upper letter",
                    "UP101", this);
        }
    }
}
