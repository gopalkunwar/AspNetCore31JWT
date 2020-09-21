# AspNetCore31JWT

## Token generation from controller
##[HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var authClaims = new[]
                { 
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecureKeyTestKeyHo"));
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44347/",
                audience: "https://localhost:44347/",
                expires:DateTime.Now.AddMinutes(15),
                claims:authClaims,
                signingCredentials:new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
                );

                return Ok(new { 
                    token=new JwtSecurityTokenHandler().WriteToken(token),
                    expiration=token.ValidTo
                });
            }
            return Unauthorized();
        }
