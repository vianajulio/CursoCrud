using FluentValidation.Results;

namespace DemoCrud.Api.Exceptions;

public class ValidateException : Exception
{
	public IReadOnlyCollection<ValidationFailure> Errors { get; }

	public ValidateException(ValidationResult validationResult)
	{
		Errors = validationResult.Errors;
	}
}
