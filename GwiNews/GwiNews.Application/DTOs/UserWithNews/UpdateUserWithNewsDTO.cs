﻿namespace GwiNews.Application.DTOs.UserWithNews
{
    public class UpdateUserWithNewsDTO
    {
        public Guid? Id { get; set; }
        public UserRoleDTO? Role { get; set; }
        public string? CompleteName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? Status { get; set; }
    }
}
