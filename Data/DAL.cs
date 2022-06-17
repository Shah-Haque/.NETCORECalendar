using dotnetcoreCalendar.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoreCalendar.Data
{
    /// <summary>
    /// The interface will provide additionality to the DAL Class
    /// </summary>
    public interface IDAL
    {
        /// <summary>
        /// This will get all the events
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents();
        /// <summary>
        /// This will get all the events that are linked by userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Event> GetMyEvents(string userid);
        /// <summary>
        /// THis gets a event through the is
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetEvent(int id);
        /// <summary>
        /// this create a event through the IFormCollection
        /// </summary>
        /// <param name="form"></param>
        public void CreateEvent(IFormCollection form);
        /// <summary>
        /// This will update an existing event through the IFormCollection
        /// </summary>
        /// <param name="form"></param>
        public void UpdateEvent(IFormCollection form);
        /// <summary>
        /// This will delete an event
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEvent(int id);
        /// <summary>
        /// This grabs all the locations
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations();
        /// <summary>
        /// This gets the location associated by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Location GetLocation(int id);
        /// <summary>
        /// This creates the location
        /// </summary>
        /// <param name="location"></param>
        public void CreateLocation(Location location);
    }

    /// <summary>
    /// The code is a class that has an instance of the ApplicationDbContext.
    /// The code is then used to return a list of events from the database.
    /// The GetMyEvents method returns all events for a specific userid, while the GetEvent method returns an event with a certain ID.
    /// The code is a method that returns all events.
    /// The code is a method that returns all events for the user with the ID of "userid".
    /// </summary>
    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// This will return all the events to a list format
        /// </summary>
        /// <returns></returns>
        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }

        /// <summary>
        /// This will return the user specified events 
        /// where the userid is equal to the string id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<Event> GetMyEvents(string userid)
        {
            return db.Events.Where(x => x.User.Id == userid).ToList();
        }

        /// <summary>
        /// This will return all the events first through the id in default order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetEvent(int id)
        {
            return db.Events.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// this will create a new event and then parse it through the eventid
        /// </summary>
        /// <param name="form"></param>
        public void CreateEvent(IFormCollection form)
        {
            var locname = form["Location"].ToString();
            //This is for every new event
            var newevent = new Event(form, db.Locations.FirstOrDefault(x => x.Name ==locname));
            //This will create the event
            db.Events.Add(newevent);
            //This will save this event in the database
            db.SaveChanges();
        }

        /// <summary>
        /// The code starts by finding the first event in the database that has an Id of "Id" and then updates it.
        /// The location is updated as well.
        /// The code updates the event with a new location.
        /// </summary>
        public void UpdateEvent(IFormCollection form)
        {
            var eventid = int.Parse(form["Id"]);
            var locname = form["Location"].ToString();
            var myevent = db.Events.FirstOrDefault(x => x.Id == eventid);
            var location = db.Locations.FirstOrDefault(x => x.Name == locname);
            myevent.UpdateEvent(form, location);
            db.Entry(myevent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// The code will delete the event with an ID of 5.
        /// The code will then find the event in the database and remove it from that table.
        /// Finally, the changes are saved to make sure everything is updated properly.
        /// The first line creates a variable called myevent which stores a reference to an Event object in the Events table.
        /// This is done by using db.Events.Find(id) which finds all events with an ID of 5 and assigns them to this variable myevent .
        /// Next, we use db.Events.Remove(myevent) which removes this event from our list of events because it has been assigned to our variable myevent .
        /// After removing this event, we save any changes made by calling db.SaveChanges() .
        /// The code deletes the event with the ID of 5.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEvent(int id)
        {
            var myevent = db.Events.Find(id);
            db.Events.Remove(myevent);
            db.SaveChanges();
        }

        /// <summary>
        ///  The code returns a list of locations that the user has entered.
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return db.Locations.ToList();
        }

        /// <summary>
        ///  The code will return the location with the ID of "1"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Location GetLocation(int id)
        {
            return db.Locations.Find(id);
        }

        /// <summary>
        /// The code creates a new location and saves it to the database
        /// The code is an example of a method that creates a new location in the database.
        /// </summary>
        /// <param name="location"></param>
        public void CreateLocation(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }
    }
}