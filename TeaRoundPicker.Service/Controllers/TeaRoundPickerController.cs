using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TeaRoundPicker.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeaRoundPicker.Service.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class TeaRoundPickerController : ControllerBase
    {
        private readonly List<Session> _Sessions;

        /// <summary>
        /// Returns a list of all sessions. 
        /// </summary>
        [HttpGet]
        public IEnumerable<Session> Get()
        {
            return new Session[] 
            { 
                new Session("foo"), new Session("bar"), new Session("fred"), new Session("dave")
            };
        }


        /// <summary>
        /// Create new tea round picker session
        /// </summary>
        /// <param name=""></param>
        /// <returns>A new, empty session</returns>
        [HttpPost]
        public Session Post([FromBody] NewSessionRequest request)
        {
            return new Session(request.Title);
        }

        // GET api/<ParticipantsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<ParticipantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParticipantsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class NewSessionRequest
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public NewSessionRequest(string title)
        {
            Title = title;
        }
    }
}



/* 
 * # Get a list of all sessions
 * /session [GET]
 * 
 * # Create new tea round picker session
 * /session [POST]
 * 
 * # Add participant to a session
 * /session/{id}/participant [POST]
 * 
 * # Get participants for session
 * /session/{id}/participant [GET]
 * 
 * # Pick participant and close session (creates a pick resurce)
 *  /session/{id}/pick [POST]
 *  