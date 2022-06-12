using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreCalendar.Models
{
    /// <summary>
    /// This class will inherit items from the identityuser class
    /// </summary>
    public class ApplicationUser: IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }

    }
}