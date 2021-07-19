using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Constants.Tickets;
using TicketSales.Core.Entities.Concrete;
using TicketSales.Core.Security.Jwt;
using TicketSales.Core.Utilites.Results;
using TicketSales.Core.Utilities.Security.Hashing;
using TicketSales.Entities.Dtos.Users;

namespace TicketSales.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
        public User Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return _mapper.Map<User,User>(user);
          
        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                throw new ErrorHandler(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Result.PasswordHash, userToCheck.Result.PasswordSalt))
            {
                throw new ErrorHandler(Messages.PasswordError);
            }
            return _mapper.Map<User,User>(userToCheck.Result);       
        }

       public async Task<IResult> UserExists(string email)
        {
            if (await _userService.GetByMail(email) != null)
            {
                throw new ErrorHandler(Messages.UserAlreadyExists);
            }
            return new Result(Messages.Successful);
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;           
        }
    }
}
