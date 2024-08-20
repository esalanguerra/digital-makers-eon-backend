using Eon.Com.Api.ActionResults.ApiResponseData.TagApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.TagViewModel;
using Eon.Com.Domain.Models.Dto.TagDto;
using Eon.Com.Interfaces.Factories.TagFactory;
using Eon.Com.Interfaces.Repositories.TagRepository;
using Eon.Com.Interfaces.Services.TagService;

namespace Eon.Com.Api.Mvc.TagMvc.Service
{
    public class TagService : ITagServiceInterface
    {
        private readonly ITagRepositoryInterface _tagRepository;
        private readonly ITagFactoryInterface _tagFactory;

        // Construtor que injeta as dependências necessárias
        public TagService(ITagRepositoryInterface tagRepository, ITagFactoryInterface tagFactory)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
            _tagFactory = tagFactory ?? throw new ArgumentNullException(nameof(tagFactory));
        }

        /// <summary>
        /// Obtém todas as tags e retorna uma resposta com uma lista de tags.
        /// </summary>
        public TagListResponse GetAll()
        {
            var tags = _tagRepository.GetAll();
            var tagDtos = tags.Select(tag => new TagViewModel(
                tag.Id, 
                tag.Name, 
                tag.Description, 
                tag.SectorId
            )).ToList();
            
            return new TagListResponse("Success", "200", tagDtos);
        }

        /// <summary>
        /// Obtém uma tag pelo ID e retorna uma resposta com os dados da tag.
        /// </summary>
        public SingleTagResponse? GetById(int id)
        {
            try
            {
                var tag = _tagRepository.GetById(id);
                if (tag == null)
                {
                    return new SingleTagResponse("Tag not found", "404", null);
                }

                var tagDto = new TagViewModel(
                    tag.Id, 
                    tag.Name, 
                    tag.Description, 
                    tag.SectorId
                );

                return new SingleTagResponse("Success", "200", tagDto);
            }
            catch (Exception ex)
            {
                // Log exception and return error response
                // _logger.LogError(ex, "Error fetching tag by id.");
                return new SingleTagResponse("An error occurred", "500", null);
            }
        }

        /// <summary>
        /// Obtém uma tag pelo nome e retorna uma resposta com os dados da tag.
        /// </summary>
        public SingleTagResponse? GetByName(string name)
        {
            try
            {
                var tag = _tagRepository.GetByName(name);
                if (tag == null)
                {
                    return new SingleTagResponse("Tag not found", "404", null);
                }

                var tagDto = new TagViewModel(
                    tag.Id, 
                    tag.Name, 
                    tag.Description, 
                    tag.SectorId
                );

                return new SingleTagResponse("Success", "200", tagDto);
            }
            catch (Exception ex)
            {
                // Log exception and return error response
                // _logger.LogError(ex, "Error fetching tag by name.");
                return new SingleTagResponse("An error occurred", "500", null);
            }
        }

        /// <summary>
        /// Cria uma nova tag com base nos dados fornecidos e retorna uma resposta com a tag criada.
        /// </summary>
        public SingleTagResponse Save(CreateTagRequestDTO tagDto)
        {
            // Valida os dados da tag usando TagFactory
            _tagFactory.ValidateCreateTagRequest(tagDto);

            // Cria uma nova tag a partir do DTO
            var tag = _tagFactory.CreateTag(tagDto);

            // Salva a tag no repositório
            var savedTag = _tagRepository.Add(tag);

            // Cria e retorna a resposta
            var responseDto = new TagViewModel(
                savedTag.Id, 
                savedTag.Name, 
                savedTag.Description, 
                savedTag.SectorId
            );
            
            return new SingleTagResponse("Tag created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza uma tag existente com base nos dados fornecidos e retorna uma resposta com a tag atualizada.
        /// </summary>
        public SingleTagResponse Update(int id, UpdateTagRequestDTO tagDto)
        {
            // Valida os dados da tag usando TagFactory
            _tagFactory.ValidateUpdateTagRequest(tagDto);

            // Recupera a tag existente
            var existingTag = _tagRepository.GetById(id);
            if (existingTag == null)
            {
                return new SingleTagResponse("Tag not found", "404", null);
            }

            // Atualiza a tag com os dados do DTO
            var updatedTag = _tagFactory.UpdateTag(existingTag, tagDto);

            // Salva a tag atualizada no repositório
            var savedTag = _tagRepository.Update(updatedTag);

            // Cria e retorna a resposta
            var responseDto = new TagViewModel(
                savedTag.Id, 
                savedTag.Name, 
                savedTag.Description, 
                savedTag.SectorId
            );
            
            return new SingleTagResponse("Tag updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta uma tag pelo ID e retorna uma resposta com a tag deletada.
        /// </summary>
        public SingleTagResponse Delete(int id)
        {
            // Deleta a tag do repositório
            var deletedTag = _tagRepository.Delete(id);
            if (deletedTag == null)
            {
                return new SingleTagResponse("Tag not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new TagViewModel(
                deletedTag.Id, 
                deletedTag.Name, 
                deletedTag.Description, 
                deletedTag.SectorId
            );

            return new SingleTagResponse("Tag deleted successfully", "200", responseDto);
        }
    }
}
