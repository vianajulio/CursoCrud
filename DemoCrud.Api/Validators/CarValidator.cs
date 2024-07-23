using FluentValidation;

namespace DemoCrud.Api.Validators;

public class CarValidator : AbstractValidator<BaseCarRequest>
{
	public CarValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("O nome do veículo é obrigatório.");

		RuleFor(x => x.Price)
			.GreaterThanOrEqualTo(0).WithMessage("O valor não pode ser negativo.");
	}
}
