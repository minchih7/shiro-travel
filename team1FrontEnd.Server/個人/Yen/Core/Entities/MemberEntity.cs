﻿namespace team1FrontEnd.Server.個人.Yen.Core.Entities
{
	public class MemberEntity
	{
		public int Id { get; set; }

		public string? Account { get; set; }

		public string? EncryptedPassword { get; set; }

		public DateTime? RegistrationDate { get; set; }

		public bool ActiveStatus { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public bool IsEmailVerified { get; set; }
	}
}
