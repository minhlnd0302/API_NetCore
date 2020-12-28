using System;

namespace WebAPI.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    using WebAPI.Models;
    using WebAPI.Controllers;
    public static class SecurityUtils
    {
        //kiểm tra token có phải là admin hay không 
        
        public static IConfiguration _config;
        public static TGDDContext _context;
        public static bool IsAdmin(TGDDContext _context, string username)
        {
            Admin admin = null;

            admin = _context.Admins.FirstOrDefault(a => a.UserName == username);

            return admin != null ? true : false;
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static string GenerateJSONWebToken(Customer userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userinfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userinfo.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        public static string GenerateJSONWebToken(Admin userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userinfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.Role, userinfo.Role.ToString()),

            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        public static Admin AuthenticateAdmin(Login loginInfo)
        {
            Admin admin = null;
            //var _context = new TGDDContext();

            admin = _context.Admins.FirstOrDefault(a => a.UserName == loginInfo.UserName && a.Password == loginInfo.Password);

            return admin;
        }
        public static Customer AuthenticateCustomer(Login loginInfo)
        {
            Customer customer = null;
            //var _context = new TGDDContext();

            customer = _context.Customers.FirstOrDefault(a => a.UserName == loginInfo.UserName && a.Password == loginInfo.Password);

            return customer;
        }

        
    }
}
