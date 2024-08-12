using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Tags;
using Eon.DTOs.TagDTO;

namespace Eon.Data.Factories
{
    public class TagFactory : ITagFactoryInterface
    {
        public void ValidateCreateTagRequest(CreateTagRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Tag name is required.");
        }

        public void ValidateUpdateTagRequest(UpdateTagRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Tag name is required.");
        }

        public Tag CreateTag(CreateTagRequestDTO dto)
        {
            return new Tag(dto.Name, dto.Description);
        }

        public Tag UpdateTag(Tag existingTag, UpdateTagRequestDTO dto)
        {
            existingTag.Name = dto.Name;
            existingTag.Description = dto.Description;
            return existingTag;
        }
    }
}
