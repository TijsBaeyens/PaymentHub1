﻿using DomainLayer.Interfaces;

namespace DomainLayer.Objects
{
    public class Bank : IBank
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string TelefoonNummer { get; set; }
        public string Email { get; set; }
        public User ContactPersoon { get; set; }

        public Bank(string naam, string telefoonNummer, string email, User contactPersoon)
        {
            Naam = naam;
            TelefoonNummer = telefoonNummer;
            Email = email;
            ContactPersoon = contactPersoon;
        }

        public Bank() {
        }
    }
}
