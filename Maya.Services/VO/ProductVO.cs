/*
 * Code Generator v1.0
 * 2014-11-07 23:46:07
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Maya.Services.VO 
{
    public class ProductVO : BaseVO {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkTo { get; set; }
        public string Pic { get; set; }
		[ScriptIgnore]
		public int SortOrder { get; set; }
		[ScriptIgnore]
		public int DistrictId { get; set; }
    }
}