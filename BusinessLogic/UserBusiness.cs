﻿using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _res;
        private string secret;

        public UserBusiness(IUserRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public Accounts Login(string taikhoan, string matkhau)
        {
            var user = _res.Login(taikhoan, matkhau);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.username.ToString()),
                    new Claim(ClaimTypes.Role, user.level.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);
            return user;
        }

        public bool Register(string taikhoan, string matkhau)
        {
            return _res.Register(taikhoan,matkhau);
        }

        public bool Update(string fullname,string address, string phone , string username)
        {
            return _res.Update(fullname,address,phone,username);
        }

        public Accounts GetInfo(string username)
        {
            return _res.GetInfo(username);
        }

        public List<Accounts> GetAll()
        {
            return _res.GetAll();
        }

        public bool DeleteById(string id)
        {
            return _res.DeleteById(id);
        }

        public bool UpdateByAdmin(UpdateModelByAdmin model)
        {
            return _res.UpdateByAdmin(model);
        }
    }
}