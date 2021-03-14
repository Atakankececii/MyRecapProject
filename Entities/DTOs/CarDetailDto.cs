﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
    }
}
