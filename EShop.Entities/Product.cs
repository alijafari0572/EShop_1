﻿using System;

namespace EShop.Entities
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }

    }
}
