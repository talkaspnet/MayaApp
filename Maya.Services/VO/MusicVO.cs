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
    public class MusicVO : BaseVO {
        public int MusicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkTo { get; set; }
        public int SortOrder { get; set; }
        public int DistrictId { get; set; }
    }
}