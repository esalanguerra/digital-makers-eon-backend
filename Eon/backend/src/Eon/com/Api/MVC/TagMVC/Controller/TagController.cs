using Eon.Com.Api.ActionResults.ApiResponseData.TagApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.TagViewModel;
using Eon.Com.Domain.Models.Dto.TagDto;
using Eon.Com.Interfaces.Controllers.TagController;
using Eon.Com.Interfaces.Services.TagService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.TagMvc.Controller
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase, ITagControllerInterface
    {
        private readonly ITagServiceInterface _tagService;

        // Construtor que injeta o serviço de tag
        public TagController(ITagServiceInterface tagService)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        /// <summary>
        /// Obtém todas as tags.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var tagListResponse = _tagService.GetAll();
            if (tagListResponse == null || !tagListResponse.Data.Any())
            {
                return NotFound(new TagListResponse
                {
                    Message = "No tags found.",
                    Code = "404",
                    Data = new List<TagViewModel>()
                });
            }

            return Ok(tagListResponse);
        }

        /// <summary>
        /// Obtém uma tag pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tagResponse = _tagService.GetById(id);

            if (tagResponse == null)
            {
                return NotFound(new SingleTagResponse
                {
                    Message = "Tag not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(tagResponse);
        }

        /// <summary>
        /// Cria uma nova tag.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateTagRequestDTO tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Tag data is required.");
            }

            var createdTagResponse = _tagService.Save(tagDto);

            if (createdTagResponse == null)
            {
                return BadRequest(new SingleTagResponse
                {
                    Message = "Tag could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTagResponse.Data?.Id },
                createdTagResponse
            );
        }

        /// <summary>
        /// Atualiza uma tag existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTagRequestDTO tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Tag data is required.");
            }

            var existingTagResponse = _tagService.GetById(id);

            if (existingTagResponse == null)
            {
                return NotFound(new SingleTagResponse
                {
                    Message = "Tag not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedTagResponse = _tagService.Update(id, tagDto);
            if (updatedTagResponse == null)
            {
                return BadRequest(new SingleTagResponse
                {
                    Message = "Tag could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta uma tag pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tagResponse = _tagService.GetById(id);

            if (tagResponse == null)
            {
                return NotFound(new SingleTagResponse
                {
                    Message = "Tag not found.",
                    Code = "404",
                    Data = null
                });
            }

            _tagService.Delete(id);
            return NoContent();
        }
    }
}
