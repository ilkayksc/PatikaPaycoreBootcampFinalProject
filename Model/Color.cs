﻿using System;
namespace PatikaPaycoreBootcampFinalProject.Model
{
    public class Color
    {
        public virtual long Id { get; set; }
        public virtual string ColorName { get; set; }
        public virtual string ColorCode { get; set; }
        public Color()
        {
        }
    }
}

