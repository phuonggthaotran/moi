﻿
namespace DA3Last.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SanPhamList
    {
        public List<Product> SanPhams { get; set; }

        [StringLength(50)]
        public string totalCount { get; set; }

    }
}