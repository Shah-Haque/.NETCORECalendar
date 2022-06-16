using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreCalendar.Models.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }

        public List<SelectListItem> Location { get; set; }

        public string  LocationName { get; set; }


        public EventViewModel (Event myEvent, List<Location> locations)
        {
            Event = myEvent;
            LocationName = myEvent.Location.Name;

            foreach (var loc in locations)
            {
                Location.Add(new SelectListItem() {Text = loc.Name});
            }

        }

        public EventViewModel(List<Location> locations)
        { 
            foreach (var loc in locations)
            {
                Location.Add(new SelectListItem() { Text = loc.Name });
            }

        }
    }
}