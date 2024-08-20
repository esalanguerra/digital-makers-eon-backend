using Eon.Com.Api.ActionResults.ApiResponseData.FolderApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.FolderViewModel;
using Eon.Com.Domain.Models.Dto.FolderDto;
using Eon.Com.Interfaces.Controllers.FolderController;
using Eon.Com.Interfaces.Services.FolderService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.FolderMvc.Controller
{
    [ApiController]
    [Route("api/folders")]
    public class FolderController : ControllerBase, IFolderControllerInterface
    {
        private readonly IFolderServiceInterface _folderService;

        // Construtor que injeta o serviço de pasta.
        public FolderController(IFolderServiceInterface folderService)
        {
            _folderService = folderService ?? throw new ArgumentNullException(nameof(folderService));
        }

        /// <summary>
        /// Obtém todas as pastas.
        /// Retorna uma resposta com uma lista de pastas.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var folderListResponse = _folderService.GetAll();
            if (folderListResponse == null || !folderListResponse.Data.Any())
            {
                // Retorna uma resposta 404 se nenhuma pasta for encontrada.
                return NotFound(new FolderListResponse
                {
                    Message = "No folders found.",
                    Code = "404",
                    Data = new List<FolderViewModel>()
                });
            }

            return Ok(folderListResponse);
        }

        /// <summary>
        /// Obtém uma pasta pelo ID.
        /// Retorna uma resposta com os dados da pasta ou uma mensagem de erro se a pasta não for encontrada.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var folderResponse = _folderService.GetById(id);

            if (folderResponse == null)
            {
                // Retorna uma resposta 404 se a pasta não for encontrada.
                return NotFound(new SingleFolderResponse
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(folderResponse);
        }

        /// <summary>
        /// Obtém uma pasta pelo nome.
        /// Retorna uma resposta com os dados da pasta ou uma mensagem de erro se a pasta não for encontrada.
        /// </summary>
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var folderResponse = _folderService.GetByName(name);

            if (folderResponse == null)
            {
                // Retorna uma resposta 404 se a pasta não for encontrada.
                return NotFound(new SingleFolderResponse
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(folderResponse);
        }

        /// <summary>
        /// Cria uma nova pasta com base nos dados fornecidos.
        /// Retorna uma resposta com os dados da pasta criada ou uma mensagem de erro se a criação falhar.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateFolderRequestDTO folderDto)
        {
            if (folderDto == null)
            {
                // Retorna uma resposta 400 se os dados da pasta não forem fornecidos.
                return BadRequest("Folder data is required.");
            }

            var createdFolderResponse = _folderService.Save(folderDto);

            if (createdFolderResponse == null)
            {
                // Retorna uma resposta 400 se a criação da pasta falhar.
                return BadRequest(new SingleFolderResponse
                {
                    Message = "Folder could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 201 com a localização da nova pasta.
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFolderResponse.Data?.Id },
                createdFolderResponse
            );
        }

        /// <summary>
        /// Atualiza uma pasta existente com base nos dados fornecidos.
        /// Retorna uma resposta 204 se a atualização for bem-sucedida ou uma mensagem de erro se a atualização falhar.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFolderRequestDTO folderDto)
        {
            if (folderDto == null)
            {
                // Retorna uma resposta 400 se os dados da pasta não forem fornecidos.
                return BadRequest("Folder data is required.");
            }

            var existingFolderResponse = _folderService.GetById(id);

            if (existingFolderResponse == null)
            {
                // Retorna uma resposta 404 se a pasta não for encontrada.
                return NotFound(new SingleFolderResponse
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedFolderResponse = _folderService.Update(id, folderDto);
            if (updatedFolderResponse == null)
            {
                // Retorna uma resposta 400 se a atualização falhar.
                return BadRequest(new SingleFolderResponse
                {
                    Message = "Folder could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 204 indicando que a atualização foi bem-sucedida.
            return NoContent();
        }

        /// <summary>
        /// Deleta uma pasta pelo ID.
        /// Retorna uma resposta 204 se a exclusão for bem-sucedida ou uma mensagem de erro se a pasta não for encontrada.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var folderResponse = _folderService.GetById(id);

            if (folderResponse == null)
            {
                // Retorna uma resposta 404 se a pasta não for encontrada.
                return NotFound(new SingleFolderResponse
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            _folderService.Delete(id);
            // Retorna uma resposta 204 indicando que a exclusão foi bem-sucedida.
            return NoContent();
        }
    }
}
