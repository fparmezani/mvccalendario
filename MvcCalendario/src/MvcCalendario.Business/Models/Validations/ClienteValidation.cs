using FluentValidation;

namespace MvcCalendario.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {

        public ClienteValidation()
        {
            RuleFor(f => f.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado")
               .Length(2, 100)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Grupo)
               .NotEmpty()
               .WithMessage("O campo {PropertyName} precisa ser informado");

        }

    }
}
