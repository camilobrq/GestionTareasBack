using BusinessLayer.ResponseModels;
using BussinesLayer.AuthLogic.Abstracts;
using CommonsLayer.DTO.Auth;
using DataLayer.Repositories.Abstracts;
using EntityLayer.AuthModels;
using BCrypt.Net;
using Microsoft.AspNet.Identity;

namespace BussinesLayer.AuthLogic.Implements
{
    public class SingInManagement:ISingInManagement
    {
        private readonly ISingInRepository repository;
        private readonly IJwtTokenProvider jwtTokenProvider;
        public SingInManagement(ISingInRepository repository, IJwtTokenProvider jwtTokenProvider)
        {
            this.repository = repository;
            this.jwtTokenProvider = jwtTokenProvider;
        }

        public async Task<Response<SessionData>> SingIn(UserCredentials user)
        {
            try
            {
                var userVerify = await repository.ValidateUsername(user.Username);

                if (userVerify.Count() >0)
                {
                    bool passwordMatches = BCrypt.Net.BCrypt.Verify(user.Password, userVerify[0].password);
                    if (passwordMatches)
                    {
                        var userInfo = new UserData()
                        {
                            UserId = userVerify[0].idUser.ToString(),
                            Username = userVerify[0].email!,
                            State = UserState.Active,
                            Role = userVerify[0].role,
                        };

                        var sessionData = new SessionData()
                        {
                            Token = jwtTokenProvider.GetJwtToken(userInfo),
                            UserInfo = userInfo
                        };
                        return sessionData.BuildSuccess("Crendeciales validas");
                    }
                    
                }
                
                return Response<SessionData>.Error("Credenciales invalidas");
               
            }
            catch (Exception)
            {
                return Response<SessionData>.Error("Ha ocurrido un error, no se ha podido Iniciar Sesion.");
            }
        }

        public async Task<Response> RegisterUser(UserRegister userRegister)
        {
            try
            {
                var username = await repository.ValidateUsername(userRegister.Email);

                if (username.Count() > 0 )
                {
                    return Response.Error("Esta dirección de correo ya esta registrada");
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRegister.Password);

                TUser users = new TUser();
                users.idUser = Guid.NewGuid();
                users.email = userRegister.Email;
                users.name = userRegister.FirstName;
                users.lastName = userRegister.LastName;
                users.identification = userRegister.Identification;
                users.telephone = userRegister.Telephone;
                users.address = userRegister.Address;
                users.role = userRegister.Role;
                users.password = hashedPassword;

                await repository.RegisterUser(users);


                return Response.Successful("Registro exitoso");
            }
            catch (Exception)
            {
                return Response.Error("Error al registrar usuario");
            }
        }

    }
}
