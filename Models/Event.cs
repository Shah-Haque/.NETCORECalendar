using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreCalendar.Models
{
    public class Event
    {
        /// <summary>
        /// Id for event
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of Event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Starting time of event
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Ending time of event
        /// </summary>
        public DateTime EndTime { get; set; }

        //Relational Data
        /// <summary>
        /// This gets the location through a 1:many basis
        /// </summary>
        public virtual Location Location { get; set; }

    }
}
