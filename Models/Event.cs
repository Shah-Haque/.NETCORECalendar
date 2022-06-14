using Microsoft.AspNetCore.Http;
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
        /// <summary>
        /// THis gets the events to display itself to the user in a many to one basis
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// This stores all instructions for what the form will do the event
        /// </summary>
        /// <param name="form"></param>
        public Event(IFormCollection form, Location location)
        {
            //This will parse the new event by the event id
            Id = int.Parse(form["Id"]);
            //This will display the name of the event
            Name = form["Name"];
            //This will display the description of the event
            Description = form["Description"];
            //This will parse the starting time of the event
            StartTime = DateTime.Parse(form["StartTime"]);
            //This will parse the ending time of the event
            EndTime = DateTime.Parse(form["EndTime"]);
            //This will look for the locations and returns it by the first or default value
            Location = location;
        }


        /// <summary>
        /// This will do the exact same thing as the event constructor but instead will update 
        /// any existing event
        /// </summary>
        /// <param name="form"></param>
        public void UpdateEvent(IFormCollection form, Location location)
        {
            //This will parse the new event by the event id
            Id = int.Parse(form["Id"]);
            //This will display the name of the event
            Name = form["Name"];
            //This will display the description of the event
            Description = form["Description"];
            //This will parse the starting time of the event
            StartTime = DateTime.Parse(form["StartTime"]);
            //This will parse the ending time of the event
            EndTime = DateTime.Parse(form["EndTime"]);
            //This will look for the locations and returns it by the first or default value
            Location = location;
        }
    
        public Event ()
        {
        }
    }
}
