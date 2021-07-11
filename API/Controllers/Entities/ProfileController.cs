using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Entities
{
    public class ProfileController : ControllerBase {

                /*[HttpDelete]
        [Route("delete/{username}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string username){
            
            await _service.DeleteAsync(username);

            if (responseHandler.HasErrors){

                var errors = responseHandler.JsonErrors;

                if(responseHandler.ErrorFromType(ErrorType.ENTITY_NOT_FOUND) != null)
                    return NotFound(errors);

                return BadRequest(errors);
            }

            return Ok(new { message = $"{username}, a sua conta foi deletada com sucesso" } );

        } */
        
    }
}