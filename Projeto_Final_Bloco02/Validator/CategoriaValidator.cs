using FluentValidation;
using Projeto_Final_Bloco02.Model;

namespace Projeto_Final_Bloco02.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(p => p.Tipo)
                    .NotEmpty();
        }
    }
}
