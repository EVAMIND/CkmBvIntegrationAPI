using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CkmBvIntegration.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ILogger _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
        protected async Task<ActionResult<TO>> ExecuteAsync<TO>(Func<Task<TO>> action)
        {
            try
            {
                var result = await action();
                return Ok(result); // Aqui, ActionResult<T> permite retornar T diretamente.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred."); // Loga o erro com a exceção

                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message); // 400 Bad Request
                }
                else if (ex is UnauthorizedAccessException)
                {
                    return Unauthorized(); // 401 Unauthorized
                }
                // Adicione outros tipos de exceção conforme necessário.
                return StatusCode(500, "An unexpected error occurred."); // 500 Internal Server Error
            }
        }
    }
}

