using GwiNews.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GwiNews.API.Controllers
{
    [Route("GwiNewsAPI/Streaming-de-Dados-Firestore-para-SQL-Server")]
    [ApiController]
    public class FirestoreToSqlServerDataStreamingController : ControllerBase
    {
        private readonly IFirestoreToSqlServerDataStreamingService _firestoreToSqlServerDataStreamingService;
        public FirestoreToSqlServerDataStreamingController(IFirestoreToSqlServerDataStreamingService firestoreToSqlServerDataStreamingService)
        {
            _firestoreToSqlServerDataStreamingService = firestoreToSqlServerDataStreamingService;
        }

        [HttpGet("Iniciar-Streaming-de-Dados")]
        public async Task<IActionResult> DataStreamingCaller()
        {
            var response = await _firestoreToSqlServerDataStreamingService.DataStreamingCaller();
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
