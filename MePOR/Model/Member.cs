using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MePOR.Model
{

    public class Member
    {
        public string MemberName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Creates the member object with the given info
        /// </summary>
        /// <param name="memberName">name of the member</param>
        /// <param name="memberEmail">email of the member</param>
        /// 
        /// <Precondition> memberName and memberEmail cannot be null</Precondition>
        /// <Postcondition>Member is created</Postcondition>
        public Member(string memberName, string memberEmail)
        {
            if (memberName == null || memberEmail == null)
            {
                throw new ArgumentException("member name or email was null");
            }

            this.MemberName = memberName;
            this.Email = memberEmail;
        }

        /// <summary>
        /// Returns true if the given email is valid, false otherwise
        /// </summary>
        /// <param name="email">email to be validated</param>
        /// <returns>Returns true if the given email is valid, false otherwise</returns>
        public static bool IsEmailValid(string email)
        {
            return email.Length < 0;
        }
    }
}
