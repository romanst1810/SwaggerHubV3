/*
 * Calculator API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;
using IO.Swagger.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BL.Services;
using Core.Interfaces;
using Core.Models;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public LoginApiController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        /// <summary>
        /// Logs in a user and returns a JWT token
        /// </summary>
        /// <param name="body">The user&#x27;s login information</param>
        /// <response code="200">Successful operation</response>

        [AllowAnonymous]
        [HttpPost]
        [Route("/RONAN1810_1/CalculatorV2/1.0.0/api/Login")]
        [ValidateModelState]
        [SwaggerOperation("Login")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse200), description: "Successful operation")]
        public virtual IActionResult Login([FromBody] UserModel body)
        {
            IActionResult response = Unauthorized();
            var user = _userService.AuthenticateUser(body);
            string jwtKey = _config["Jwt:Key"];
            string jwtIssuer = _config["Jwt:Issuer"];
            if (user != null && !string.IsNullOrEmpty(jwtKey) && !string.IsNullOrEmpty(jwtIssuer))
            {
                var tokenString = _userService.GenerateJSONWebToken(user,jwtKey, jwtIssuer);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

       
    }
}