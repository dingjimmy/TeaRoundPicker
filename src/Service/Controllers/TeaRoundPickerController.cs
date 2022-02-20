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
        private static readonly List<Session> _Sessions = new()
        {
            new Session("Test Session 1"),
            new Session("Test Session 2"),
            new Session("Test Session 3"),
            new Session("Test Session 4"),
            new Session("Test Session 5"),
        };

        /// <summary>
        /// Returns a list of all sessions. 
        /// </summary>
        [HttpGet]
        public IActionResult GetSessions()
        {
            return Ok(new GetSessionsResponse(_Sessions.ToArray()));
        }

        /// <summary>
        /// Returns the session specified by the given id. 
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetSession(Guid id)
        {
            return Ok(new GetSessionResponse(_Sessions.First(x => x.Id == id)));
        }

        /// <summary>
        /// Create new tea round picker session
        /// </summary>
        /// <param name=""></param>
        /// <returns>A new, empty session</returns>
        [HttpPost]
        public IActionResult CreateSession([FromBody] NewSessionRequest request)
        {
            var session = new Session(request.Title);

            _Sessions.Add(session);

            return Created($"{Request.Path}/{session.Id}",  new NewSessionResponse() 
            {
                Session = session
            });
        }

        /// <summary>
        /// Add participant to an existing session.
        /// </summary>
        /// <param name="id">Id of an existing session.</param>
        /// <returns></returns>
        [HttpPost("{id}/participant")]
        public IActionResult CreateParticipant(Guid sessionId, string participantName)
        {
            var session = _Sessions
                .First(x => x.Id == sessionId);

            session.Participants
                .Add(new Participant(participantName));

            return Created($"{Request.Path}/{sessionId}/{participantName}", null); 
        }
    }
/*
 * # Get participants for session
 * /session/{id}/participant [GET]
 * 
 * # Pick participant and close session (creates a pick resurce)
 *  /session/{id}/pick [POST]
 */

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

    public enum SessionError
    {
        None = 0,
        SessionDoesNotExist = 1
    }

    public class SessionResponseBase
    {
        public SessionError ErrorCode { get; set; } = SessionError.None;
    }

    public class GetSessionResponse
    {
        public Session Session { get; set; }

        public GetSessionResponse(Session session)
        {
            Session = session;
        }
    }

    public class GetSessionsResponse
    {
        public Session[] Sessions { get; set; }

        public GetSessionsResponse(Session[] sessions)
        {
            Sessions = sessions;
        }
    }

    public class NewSessionResponse : SessionResponseBase
    {
        public Session? Session { get; set; }
    }

    public class AddParticipantResponse : SessionResponseBase
    {

    }


}