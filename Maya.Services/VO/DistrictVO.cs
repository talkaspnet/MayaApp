/*
 * Code Generator v1.0
 * 2014-11-11 23:08:30
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maya.Services.VO 
{
    public class DistrictVO : BaseVO {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Lft { get; set; }
        public int Rgt { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public int SortOrder { get; set; }
    }
}