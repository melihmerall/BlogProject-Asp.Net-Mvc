using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            //Blog Title
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Cannot Blank!!");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Please enter at least 3 characters");
           
            //Blog Content
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Cannot Blank!!");
            RuleFor(x => x.BlogContent).MinimumLength(100).WithMessage("Enter up to 100 charactes");

            //Image
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Cannot Blank!!");

            //Date
            RuleFor(x => x.BlogDate).NotEmpty().WithMessage("Cannot Blank!!");


        }
    }
}
