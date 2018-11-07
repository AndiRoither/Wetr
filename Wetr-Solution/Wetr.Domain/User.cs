﻿using System;

namespace Wetr.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public override bool Equals(object o)
        {

            if (o == null || !(o is User))
                return false;

            User u = o as User;

            return u.UserId == UserId &&
               u.FirstName.Equals(FirstName) &&
               u.LastName.Equals(LastName) &&
               u.Password.Equals(Password) &&
               u.Email.Equals(Email);
        }

        public override string ToString() =>
            $"[{UserId}] {FirstName} {LastName} {Password} {Email}";
    }
}