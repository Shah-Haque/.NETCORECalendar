using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreCalendar.Models
{
    public class Location
    {
        /// <summary>
        /// Id of location
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of Location
        /// </summary>
        public string Name { get; set; }

        //Relational Data
        /// <summary>
        /// This connects with the Event model
        /// </summary>
        public virtual ICollection<Event> Events { get; set; }
    }
}
