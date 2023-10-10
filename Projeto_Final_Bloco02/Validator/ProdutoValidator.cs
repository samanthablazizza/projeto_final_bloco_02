using FluentValidation;
using Projeto_Final_Bloco02.Model;

namespace Projeto_Final_Bloco02.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty();

            RuleFor(p => p.Descricao)
                .NotEmpty();

            RuleFor(p => p.Preco)
                .NotNull()
                .GreaterThan(0)
                .PrecisionScale(20, 2, false); 
        }

    }
}
