﻿namespace Wetr.Domain
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString() =>
            $"[{PermissionId}] {Name} {Description}";

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Permission temp = (Permission)obj;
                return ((this.PermissionId == temp.PermissionId) && (this.Name == temp.Name) && (this.Description == temp.Description));
            }
        }
    }
}