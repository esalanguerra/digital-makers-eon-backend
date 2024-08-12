using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.TagDTO;

namespace Eon.Api.Services.TagService
{
    public class TagService : ITagServiceInterface
    {
        private readonly ITagRepositoryInterface _tagRepository;
        private readonly ITagFactoryInterface _tagFactory;

        public TagService(ITagRepositoryInterface tagRepository, ITagFactoryInterface tagFactory)
        {
            _tagRepository = tagRepository;
            _tagFactory = tagFactory;
        }

        public TagListResponseDTO GetAll()
        {
            var tags = _tagRepository.GetAll();
            var tagDtos = tags.Select(tag => new TagViewModelDTO(tag.Id, tag.Name));
            return new TagListResponseDTO("Success", "200", tagDtos);
        }

        public SingleTagResponseDTO? GetById(int id)
        {
            var tag = _tagRepository.GetById(id);
            if (tag == null)
            {
                return new SingleTagResponseDTO("Tag not found", "404", null);
            }
            var tagDto = new TagViewModelDTO(tag.Id, tag.Name);
            return new SingleTagResponseDTO("Success", "200", tagDto);
        }

        public SingleTagResponseDTO? GetByName(string name)
        {
            var tag = _tagRepository.GetByName(name);
            if (tag == null)
            {
                return new SingleTagResponseDTO("Tag not found", "404", null);
            }
            var tagDto = new TagViewModelDTO(tag.Id, tag.Name);
            return new SingleTagResponseDTO("Success", "200", tagDto);
        }

        public SingleTagResponseDTO Save(CreateTagRequestDTO tagDto)
        {
            _tagFactory.ValidateCreateTagRequest(tagDto);
            var tag = _tagFactory.CreateTag(tagDto);
            var savedTag = _tagRepository.Save(tag);
            var responseDto = new TagViewModelDTO(savedTag.Id, savedTag.Name);
            return new SingleTagResponseDTO("Tag created successfully", "201", responseDto);
        }

        public SingleTagResponseDTO Update(int id, UpdateTagRequestDTO tagDto)
        {
            _tagFactory.ValidateUpdateTagRequest(tagDto);
            var existingTag = _tagRepository.GetById(id);
            if (existingTag == null)
            {
                return new SingleTagResponseDTO("Tag not found", "404", null);
            }
            var updatedTag = _tagFactory.UpdateTag(existingTag, tagDto);
            var savedTag = _tagRepository.Update(id, updatedTag);
            var responseDto = new TagViewModelDTO(savedTag.Id, savedTag.Name);
            return new SingleTagResponseDTO("Tag updated successfully", "200", responseDto);
        }

        public SingleTagResponseDTO Delete(int id)
        {
            var deletedTag = _tagRepository.Delete(id);
            if (deletedTag == null)
            {
                return new SingleTagResponseDTO("Tag not found", "404", null);
            }
            var responseDto = new TagViewModelDTO(deletedTag.Id, deletedTag.Name);
            return new SingleTagResponseDTO("Tag deleted successfully", "200", responseDto);
        }
    }
}
