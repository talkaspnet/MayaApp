/*
 * Code Generator v1.0
 * 2014-11-11 23:08:31
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Maya.Services.VO 
{
    public class BaseVO 
    {
		[ScriptIgnore]
		public DateTime CreatedDate { get; internal set; }
		[ScriptIgnore]
		public string CreatedBy { get; internal set; }
		[ScriptIgnore]
		public DateTime UpdatedDate { get; internal set; }
		[ScriptIgnore]
		public string UpdatedBy { get; internal set; }
		[ScriptIgnore]
		public DateTime ActionDate { get; set; }
		[ScriptIgnore]
		public string ActionBy { get; set; }

		//public T To<T>() {
		//	Type origin = GetType();
		//	Type destination = typeof(T);

		//	T obj = Activator.CreateInstance<T>();
		//	foreach (PropertyInfo p1 in origin.GetProperties()) {
		//		foreach (PropertyInfo p2 in destination.GetProperties()) {
		//			if (p1.Name == p2.Name) {
		//				//p2.SetValue( obj, Convert.ChangeType( p1.GetValue( this ), p1.PropertyType ) );
		//				//p2.SetValue( obj, "abc", null );
		//				p2.SetValue( obj, p1.GetValue( this ), null );
		//				break;
		//			}
		//		}
		//	}

		//	return obj; 
		//}
    }
}