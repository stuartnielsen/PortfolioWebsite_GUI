﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Shared.ViewModels
{
    public class PlatformViewModel
    {
        public PlatformViewModel() { }
        public PlatformViewModel(Platform platform)
        {
            Id = platform.Id;
            Name = platform.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

