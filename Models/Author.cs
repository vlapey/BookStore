﻿namespace Models
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}