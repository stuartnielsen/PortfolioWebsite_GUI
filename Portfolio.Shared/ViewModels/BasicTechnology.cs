using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class BasicTechnology
    {
        public BasicTechnology() { }
        public BasicTechnology(Technology technology)
        {
            Id = technology.Id;
            Name = technology.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

