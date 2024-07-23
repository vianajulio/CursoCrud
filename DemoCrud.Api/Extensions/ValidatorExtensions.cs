using FluentValidation;

namespace DemoCrud.Api.Extensions;

public static class ValidatorExtensions
{
	public static void ValidateCommand<TCommand>(this IValidator<TCommand> validator, TCommand command)
	{
		ArgumentNullException.ThrowIfNull(nameof(command));

		var validationResult = validator.Validate(command);
		if (!validationResult.IsValid)
			throw new ValidateException(validationResult);
	}
}
