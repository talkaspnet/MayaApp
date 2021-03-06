/*
 * Code Generator v1.0
 * 2014-11-07 23:46:10
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maya.Services.VO 
{
    public class UserVO : BaseVO {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public int EmailStatus { get; set; }
        public int Role { get; set; }
    }
}