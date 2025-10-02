using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("lütfen müşteri adını boş geçmeyiniz");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("lütfen en az 5 karakter giriniz");
            RuleFor(x => x.RatıngValue).NotEmpty().WithMessage("lütfen puan değerini giriniz giriniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("lütfen yorumu giriniz giriniz");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("lütfen resmi giriniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("lütfen en az 50 karakter giriniz");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("lütfen en fazla 500 karakter giriniz");
        }
    }
}
