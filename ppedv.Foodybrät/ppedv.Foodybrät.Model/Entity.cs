﻿using System;

namespace ppedv.Foodybrät.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
