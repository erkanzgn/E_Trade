﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DtoLayer.CatalogDtos.FeatureSliderDtos
{
    public class CreateFeatureSliderDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string CategoryId { get; set; }
    }
}
