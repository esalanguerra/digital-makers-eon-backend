using Eon.Com.Api.ActionResults.ApiResponseData.FlowSharedApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.FlowSharedViewModel;
using Eon.Com.Domain.Models.Dto.FlowSharedDto;
using Eon.Com.Interfaces.Factories.FlowSharedFactory;
using Eon.Com.Interfaces.Repositories.FlowSharedRepository;
using Eon.Com.Interfaces.Services.FlowSharedService;

namespace Eon.Com.Api.Mvc.FlowSharedMvc.Service
{
    public class FlowSharedService : IFlowSharedServiceInterface
    {
        private readonly IFlowSharedRepositoryInterface _flowSharedRepository;
        private readonly IFlowSharedFactoryInterface _flowSharedFactory;

        // Construtor que injeta as dependências necessárias
        public FlowSharedService(IFlowSharedRepositoryInterface flowSharedRepository, IFlowSharedFactoryInterface flowSharedFactory)
        {
            _flowSharedRepository = flowSharedRepository;
            _flowSharedFactory = flowSharedFactory;
        }

        /// <summary>
        /// Obtém todos os fluxos compartilhados e retorna uma resposta com uma lista de fluxos compartilhados.
        /// </summary>
        public FlowSharedListResponse GetAll()
        {
            var flowsShared = _flowSharedRepository.GetAll();
            var flowSharedDtos = flowsShared.Select(flowShared => new FlowSharedViewModel(
                flowShared.Id,
                flowShared.FlowId, 
                flowShared.UserId, 
                flowShared.Link, 
                flowShared.Status
            )).ToList(); // Convert to List for better performance in case of large datasets
            
            return new FlowSharedListResponse("Success", "200", flowSharedDtos);
        }

        /// <summary>
        /// Obtém um fluxo compartilhado pelo ID e retorna uma resposta com os dados do fluxo compartilhado.
        /// </summary>
        public SingleFlowSharedResponse? GetById(int id)
        {
            var flowShared = _flowSharedRepository.GetById(id);
            if (flowShared == null)
            {
                return new SingleFlowSharedResponse("FlowShared not found", "404", null);
            }

            var flowSharedDto = new FlowSharedViewModel(
                flowShared.Id, 
                flowShared.FlowId,
                flowShared.UserId, 
                flowShared.Link, 
                flowShared.Status
            );

            return new SingleFlowSharedResponse("Success", "200", flowSharedDto);
        }

        /// <summary>
        /// Obtém um fluxo compartilhado pelo link e retorna uma resposta com os dados do fluxo compartilhado.
        /// </summary>
        public SingleFlowSharedResponse? GetByLink(string link)
        {
            var flowShared = _flowSharedRepository.GetByLink(link);
            if (flowShared == null)
            {
                return new SingleFlowSharedResponse("FlowShared not found", "404", null);
            }

            var flowSharedDto = new FlowSharedViewModel(
                flowShared.Id, 
                flowShared.FlowId,
                flowShared.UserId, 
                flowShared.Link, 
                flowShared.Status
            );

            return new SingleFlowSharedResponse("Success", "200", flowSharedDto);
        }

        /// <summary>
        /// Cria um novo fluxo compartilhado com base nos dados fornecidos e retorna uma resposta com o fluxo compartilhado criado.
        /// </summary>
        public SingleFlowSharedResponse Save(CreateFlowSharedRequestDTO flowSharedDto)
        {
            // Valida os dados do fluxo compartilhado usando FlowSharedFactory
            _flowSharedFactory.ValidateCreateFlowSharedRequest(flowSharedDto);

            // Cria um novo fluxo compartilhado a partir do DTO
            var flowShared = _flowSharedFactory.CreateFlowShared(flowSharedDto);

            // Salva o fluxo compartilhado no repositório
            var savedFlowShared = _flowSharedRepository.Add(flowShared);

            // Cria e retorna a resposta
            var responseDto = new FlowSharedViewModel(
                savedFlowShared.Id, 
                savedFlowShared.FlowId, 
                savedFlowShared.UserId, 
                savedFlowShared.Link, 
                savedFlowShared.Status
            );
            
            return new SingleFlowSharedResponse("FlowShared created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza um fluxo compartilhado existente com base nos dados fornecidos e retorna uma resposta com o fluxo compartilhado atualizado.
        /// </summary>
        public SingleFlowSharedResponse Update(int id, UpdateFlowSharedRequestDTO flowSharedDto)
        {
            // Valida os dados do fluxo compartilhado usando FlowSharedFactory
            _flowSharedFactory.ValidateUpdateFlowSharedRequest(flowSharedDto);

            // Recupera o fluxo compartilhado existente
            var existingFlowShared = _flowSharedRepository.GetById(id);
            if (existingFlowShared == null)
            {
                return new SingleFlowSharedResponse("FlowShared not found", "404", null);
            }

            // Atualiza o fluxo compartilhado com os dados do DTO
            var updatedFlowShared = _flowSharedFactory.UpdateFlowShared(existingFlowShared, flowSharedDto);

            // Salva o fluxo compartilhado atualizado no repositório
            var savedFlowShared = _flowSharedRepository.Update(updatedFlowShared);

            // Cria e retorna a resposta
            var responseDto = new FlowSharedViewModel(
                savedFlowShared.Id, 
                savedFlowShared.FlowId, 
                savedFlowShared.UserId, 
                savedFlowShared.Link, 
                savedFlowShared.Status
            );
            
            return new SingleFlowSharedResponse("FlowShared updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta um fluxo compartilhado pelo ID e retorna uma resposta com o fluxo compartilhado deletado.
        /// </summary>
        public SingleFlowSharedResponse Delete(int id)
        {
            // Deleta o fluxo compartilhado do repositório
            var deletedFlowShared = _flowSharedRepository.Delete(id);
            if (deletedFlowShared == null)
            {
                return new SingleFlowSharedResponse("FlowShared not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new FlowSharedViewModel(
                deletedFlowShared.Id,
                deletedFlowShared.FlowId, 
                deletedFlowShared.UserId, 
                deletedFlowShared.Link, 
                deletedFlowShared.Status
            );

            return new SingleFlowSharedResponse("FlowShared deleted successfully", "200", responseDto);
        }
    }
}
