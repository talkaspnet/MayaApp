/*
 * Code Generator v1.0
 * 2014-11-24 23:23:51
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maya.Services.VO 
{
    public class CurrencyVO : BaseVO {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}