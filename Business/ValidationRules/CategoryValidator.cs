using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            //Category Name Validation
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Please enter at least 3 characters");
            RuleFor(x => x.CategoryName).MaximumLength(29).WithMessage("Enter up to 40 charactes");

            //Category Desc Validation
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("Please enter at least 3 characters");
            RuleFor(x => x.CategoryDescription).MaximumLength(499).WithMessage("Enter up to 40 charactes");

        }
    }
}
