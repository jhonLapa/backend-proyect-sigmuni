using System;
using Jca.Sigmuni.Core.Security.Entities;

namespace Jca.Sigmuni.Core.Security.Services.Abstractions
{
	public interface ISecurityService
	{
		string HashPassword(string userName, string hashedPassword);
		bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword);
		SecurityEntity JwtSecurity(string jwtSecrectKey);
    }
}

