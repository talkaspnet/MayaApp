/*
 * Code Generator v1.0
 * 2014-11-07 23:46:08
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maya.Services.VO 
{
    public class CategoryVO : BaseVO {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}