/*
 * Code Generator v1.0
 * 2014-11-11 23:08:31
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maya.Services.VO 
{
    public class BaseVO 
    {
        public DateTime CreatedDate { get; internal set; }
        public string CreatedBy { get; internal set; }
        public DateTime UpdatedDate { get; internal set; }
        public string UpdatedBy { get; internal set; }
        public DateTime ActionDate { get; set; }
        public string ActionBy { get; set; }
    }
}