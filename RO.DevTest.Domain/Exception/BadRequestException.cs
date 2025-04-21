using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace RO.DevTest.Domain.Exception;

/// <summary>
/// Returns a <see cref="HttpStatusCode.BadRequest"/> to
/// the request
/// </summary>
public class BadRequestException : ApiException {
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public BadRequestException() 
        : base("A requisição não pôde ser processada.") { }

    public BadRequestException(string error) 
        : base(error) { }

    public BadRequestException(IEnumerable<string> errors) 
        => Errors = errors.ToList();

    public BadRequestException(ValidationResult validationResult) 
        : base(validationResult) { }

    public BadRequestException(IdentityResult identityResult) 
        : base(identityResult) { }
}
