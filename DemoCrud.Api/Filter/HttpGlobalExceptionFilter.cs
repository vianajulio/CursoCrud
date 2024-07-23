using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace DemoCrud.Api.Filter;

public class HttpGlobalExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if (context.Exception is ValidateException exception)
		{
			var problemDetails = new ValidationProblemDetails
			{
				Instance = context.HttpContext.Request.Path,
				Status = StatusCodes.Status400BadRequest,
				Detail = "Please refer to the errors property for additional details."
			};

			if (exception.Errors.Count != 0)
			{
				foreach (var error in exception.Errors.GroupBy(x => x.PropertyName))
					problemDetails.Errors.Add(error.Key.ToLower(), error.Select(x => x.ErrorMessage).ToArray());
			}

			context.Result = new BadRequestObjectResult(problemDetails);
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
		}
		else if (context.Exception is DomainException domainException)
		{
			var problemDetails = new ValidationProblemDetails
			{
				Instance = context.HttpContext.Request.Path,
				Status = StatusCodes.Status400BadRequest,
				Detail = "Please refer to the errors property for additional details."
			};

			problemDetails.Errors.Add("domainException", [domainException.Message]);

			context.Result = new BadRequestObjectResult(problemDetails);
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
		}
		else if (context.Exception is NotFoundException)
		{
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
		}
		else
		{
			var json = new JsonErrorResponse(["An error occur. Try it again."]);

			context.Result = new InternalServerErrorObjectResult(json);
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
		}

		context.ExceptionHandled = true;
	}
}

internal class JsonErrorResponse(string[] messages)
{
	public string[] Messages { get; } = messages;

	public string? DeveloperMessage { get; set; }
}

public class InternalServerErrorObjectResult : ObjectResult
{
	public InternalServerErrorObjectResult(object error)
		: base(error)
	{
		StatusCode = StatusCodes.Status500InternalServerError;
	}
}
