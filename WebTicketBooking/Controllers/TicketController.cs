using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTicketBooking.DAL;
using WebTicketBooking.DAL.Models;
using WebTicketBooking.Models.Ticket;

namespace WebTicketBooking.Controllers
{
    [Controller]
    public class TicketController : HomeController
    {
        private ApplicationContext _context;
        public TicketController(ApplicationContext context)
        {
            _context = context;
        }

        // Method of displaying the form for adding a new ticket
        [HttpGet]
        public IActionResult AddNewTicket()
        {
            return View();
        }

        // Method for adding a new ticket
        [HttpPost]
        public async Task<IActionResult> AddNewTicket(TicketModel model)
        {
            Ticket ticket = new Ticket();
            if (ModelState.IsValid)
            {
                ticketEquals(model, ticket);

                if (ticket != null)
                {
                    if (getTicket(ticket))
                        TempData["fail"] = "That ticket is already taken";
                    
                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ShowAllTickets_Admin", "Ticket");
                }
                TempData["failTicket"] = "Invalid ticket";
            }
            return View(model);
        }

        // Method for deleting ticket
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ShowAllTickets_Admin", "Ticket");
        }

        // Update ticket form display method
        [HttpGet]
        public IActionResult UpdateTicket(int id)
        {
            UpdateTicketModel model = new UpdateTicketModel();
            Ticket ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            
            model.Origin = ticket.Origin;
            model.Origin_name = ticket.Origin_name;
            model.Destination = ticket.Destination;
            model.Destination_name = ticket.Destination_name;
            model.Departure_date = ticket.Departure_date;
            model.Arrival_date = ticket.Arrival_date;
            model.Carrier = ticket.Carrier;
            model.Stops = ticket.Stops;
            model.Price = ticket.Price;
            model.Count = ticket.Count;

            return View(model);
        }

        // Update ticket method
        [HttpPost]
        public async Task<IActionResult> UpdateTicket(UpdateTicketModel model, int id)
        {
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ModelState.IsValid)
            {
                if (ticket != null)
                {
                    if (ticket.Origin != model.Origin)
                        ticket.Origin = model.Origin;
                    if (ticket.Origin_name != model.Origin_name)
                        ticket.Origin_name = model.Origin_name;
                    if (ticket.Destination != model.Destination)
                        ticket.Destination = model.Destination;
                    if (ticket.Destination_name != model.Destination_name)
                        ticket.Destination_name = model.Destination_name;
                    if (model.Departure_date != new DateTime())
                        ticket.Departure_date = model.Departure_date;
                    if (ticket.Arrival_date != model.Arrival_date)
                        ticket.Arrival_date = model.Arrival_date;
                    if (ticket.Carrier != model.Carrier)
                        ticket.Carrier = model.Carrier;
                    if (ticket.Price != model.Price)
                        ticket.Price = model.Price;
                    if (ticket.Count != model.Count)
                        ticket.Count = model.Count;

                    if (getTicket(ticket))
                        TempData["fail"] = "That ticket is already taken";

                    _context.Tickets.Update(ticket);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("ShowAllTickets_Admin", "Ticket");
                }
                TempData["failTicket"] = "Invalid ticket";
            }
            return View(model);
        }

        // Book ticket by user method 
        [HttpGet]
        public async Task<IActionResult> BookTicket(int id)
        {
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            
            User user = await _context.Users
                .Include(u => u.RoleName)
                .FirstOrDefaultAsync(u => u.Username == GetUser());

            if (ticket != null && user != null)
            {
                if (user.ticketlist.Contains(ticket))
                    return View();
                else
                {
                    user.ticketlist.Add(ticket);
                    ticket.Count -= 1;

                    _context.Users.Update(user);
                    _context.Tickets.Update(ticket);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("ShowActiveTickets_OfUser", "Ticket");
        }

        // Cancel ticket by user method
        [HttpGet]
        public async Task<IActionResult> CancelTicket(int id)
        {
            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            
            User user = await _context.Users
                .Include(u => u.RoleName)
                .FirstOrDefaultAsync(u => u.Username == GetUser());

            if (ticket != null && user != null)
            {
                TimeSpan intervalOfDays = ticket.Departure_date - DateTime.UtcNow;
                
                if (intervalOfDays.TotalDays < 1)
                    return View();

                user.ticketlist.Remove(ticket);
                ticket.Count += 1;

                _context.Users.Update(user);
                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ShowActiveTickets_OfUser", "Ticket");
        }

        // Method for showing active tickets of current user
        [HttpGet]
        public IActionResult ShowActiveTickets_OfUser()
        {
            User user = _context.Users
                .Include(u => u.RoleName)
                .Include(u => u.ticketlist)
                .FirstOrDefault(u => u.Username == GetUser());

            var tickets = user.ticketlist.OrderByDescending(a=>a.Departure_date);

            List<Ticket> activeTickets = new List<Ticket>();
            foreach (var item in tickets)
                if (item.Arrival_date >= DateTime.UtcNow)
                    activeTickets.Add(item);

            if (activeTickets.Count == 0)
                TempData["failHave"] = "You have no active tickets";

            return View(activeTickets);
        }

        // Method for showing all tickets user can book
        [HttpGet]
        public IActionResult ShowAllTickets_User()
        {
            var tickets = _context.Tickets
                .Where(t => t.Departure_date > DateTime.UtcNow)
                .Where(t => t.Count > 0)
                .ToList().OrderByDescending(a => a.Departure_date);

            if (tickets == null)
                TempData["failAll"] = "There are no tickets";

            return View(tickets);
        }

        // Method for showing all tickets in database
        [HttpGet]
        public IActionResult ShowAllTickets_Admin()
        {
            var tickets = _context.Tickets
                .ToList().OrderByDescending(a => a.Departure_date);

            if(tickets == null)
                TempData["failAll"] = "There are no tickets";

            return View(tickets);
        }

        // Method of displaying a specific ticket
        [HttpGet]
        public IActionResult GetTicketById(int id)
        {
            Ticket ticket = _context.Tickets.FirstOrDefault(u => u.Id == id);
            return View(ticket);
        }

        // Method for checking if ticket is in database
        private bool getTicket(Ticket ticket)
        {
            var getTicket = _context.Tickets.All(t => t.Origin == ticket.Origin &&
                                          t.Destination == ticket.Destination &&
                                          t.Carrier == ticket.Carrier &&
                                          t.Departure_date == ticket.Departure_date &&
                                          t.Arrival_date == ticket.Arrival_date &&
                                          t.Stops == ticket.Stops &&
                                          t.Price == ticket.Price);
            if (getTicket) return true;
            return false;
        }

        // Method for assigning data from a TicketModel
        private void ticketEquals(TicketModel model, Ticket ticket)
        {
            ticket.Origin = model.Origin;
            ticket.Origin_name = model.Origin_name;
            ticket.Destination = model.Destination;
            ticket.Destination_name = model.Destination_name;
            ticket.Departure_date = model.Departure_date;
            ticket.Arrival_date = model.Arrival_date;
            ticket.Carrier = model.Carrier;
            ticket.Stops = model.Stops;
            ticket.Price = model.Price;
            ticket.Count = model.Count;
        }
    }
}
