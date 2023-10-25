using System;
namespace Jca.Sigmuni.Core.Security.Entities
{
	public class SecurityEntity
	{
        public string TokenType { get; set; }
        public string AccesToken { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}

