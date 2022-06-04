using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            //Author name
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.AuthorShortAbout).MinimumLength(3).WithMessage("Min lenght 3!");
            // Image
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Cannot be blank !");

            // Author Skilss
            RuleFor(x => x.AuthorShortAbout).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.AuthorShortAbout).MinimumLength(2).WithMessage("Min lenght 2!");

            //About
            RuleFor(x => x.AuthorDetail).NotEmpty().WithMessage("Cannot be blank !");

            // mail
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.AuthorMail).EmailAddress().WithMessage("Please give me mail format..");

            //password
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.AuthorPassword).MaximumLength(20).WithMessage("Max Lenght 20...");
         

            // phone number
            RuleFor(x => x.AuthorPhone).NotEmpty().WithMessage("Cannot be blank !");
            RuleFor(x => x.AuthorPhone).MaximumLength(11).WithMessage("Max Lenght 11...");
        }

    }
}
