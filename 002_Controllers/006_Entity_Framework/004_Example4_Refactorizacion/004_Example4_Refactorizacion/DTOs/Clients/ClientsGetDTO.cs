﻿namespace _004_Example4_Refactorizacion.DTOs.Clients
{
    public class ClientsGetDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}