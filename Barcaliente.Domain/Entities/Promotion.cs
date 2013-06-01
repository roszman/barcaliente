﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcaliente.Domain.Entities
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
