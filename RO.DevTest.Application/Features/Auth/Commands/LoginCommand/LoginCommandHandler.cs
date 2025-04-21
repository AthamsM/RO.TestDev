using System.Data;
using MediatR;
using RO.DevTest.Application.Contracts.Infrastructure; 
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse> {
    private readonly IIdentityAbstractor _identityAbstractor;

    public LoginCommandHandler(IIdentityAbstractor identityAbstractor){
        _identityAbstractor = identityAbstractor;
    }
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken) {
        // verfic if user exist wiht email
        var user = await _identityAbstractor.FindUserByEmailAsync(request.Email);
        if(user == null){
            throw new BadRequestException("Usuario não existe");
        }
       
        // confirm login wiht password
        var result = await _identityAbstractor.PasswordSignInAsync(user, request.Password);
        if(!result.Succeeded){
            throw new BadRequestException("Usuario ou senha inválidas");
        }

        var role = await _identityAbstractor.GetUserRolesAsync(user);
        
        // generet token
        string accessToken = "teste-access-token";
        string refreshToken = "teste-refresh-token";

        var now = DateTime.UtcNow;
        var reponse = new LoginResponse{
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            IssuedAt = now,
            ExpirationDate = now.AddMinutes(60),
            Roles = role
        };
        return reponse;
    }
}
