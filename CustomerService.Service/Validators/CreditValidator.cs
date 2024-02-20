using CustomerService.Domain.Dto;
using CustomerService.Domain.Entities;
using CustomerService.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Service.Validators
{
    public class CreditValidator : AbstractValidator<ClientEntity>
    {
        public CreditValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Favor preencher o campo Nome.")
                .NotNull().WithMessage("Favor preencher o campo Nome.");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Favor preencher o campo CPF.")
                .NotNull().WithMessage("Favor preencher o campo CPF.");

            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("Favor preencher o campo UF.")
                .NotNull().WithMessage("Favor preencher o campo UF.");


            RuleFor(c => c.Cellphone)
                .NotEmpty().WithMessage("Favor preencher o campo TELEFONE.")
                .NotNull().WithMessage("Favor preencher o campo TELEFONE.");
        }
    }
}
