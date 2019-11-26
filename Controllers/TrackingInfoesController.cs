using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery_Tracking_Web_API.Model;
using Delivery_Tracking_Web_API.Models;

namespace Delivery_Tracking_Web_API.Controllers
{
    //Manages the tracking information
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingInfoesController : ControllerBase
    {
        private readonly Delivery_Tracking_Web_APIDataContext _context;

        public TrackingInfoesController(Delivery_Tracking_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/TrackingInfoes\
        //Get all tracking using a linq query
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackingInfo>>> GetTrackingInfo()
        {
            return await (from track in _context.TrackingInfo select track).ToListAsync();
        }

        // GET: api/TrackingInfoes/5
        //Get tracking details using a linq query
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackingInfo>> GetTrackingInfo(int id)
        {
            var trackingInfo = await (from track in _context.TrackingInfo
                                      where track.Id == id 
                                      select track).FirstOrDefaultAsync();

            if (trackingInfo == null)
            {
                return NotFound();
            }

            return trackingInfo;
        }

        // PUT: api/TrackingInfoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates tracking info
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrackingInfo(int id, TrackingInfo trackingInfo)
        {
            if (id != trackingInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(trackingInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrackingInfoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds a tracking info
        [HttpPost]
        public async Task<ActionResult<TrackingInfo>> PostTrackingInfo(TrackingInfo trackingInfo)
        {
            _context.TrackingInfo.Add(trackingInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrackingInfo", new { id = trackingInfo.Id }, trackingInfo);
        }

        // DELETE: api/TrackingInfoes/5
        //Remove tracking
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrackingInfo>> DeleteTrackingInfo(int id)
        {
            var trackingInfo = await _context.TrackingInfo.FindAsync(id);
            if (trackingInfo == null)
            {
                return NotFound();
            }

            _context.TrackingInfo.Remove(trackingInfo);
            await _context.SaveChangesAsync();

            return trackingInfo;
        }

        //Tracking info check using a lamda query
        private bool TrackingInfoExists(int id)
        {
            return _context.TrackingInfo.Any(e => e.Id == id);
        }
    }
}
