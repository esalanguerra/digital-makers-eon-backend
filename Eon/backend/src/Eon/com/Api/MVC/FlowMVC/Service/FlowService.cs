using Eon.Com.Api.ActionResults.ApiResponseData.FlowApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.FlowViewModel;
using Eon.Com.Domain.Models.Dto.FlowDto;
using Eon.Com.Interfaces.Factories.FlowFactory;
using Eon.Com.Interfaces.Repositories.FlowRepository;
using Eon.Com.Interfaces.Services.FlowService;

namespace Eon.Com.Api.Mvc.FlowMvc.Service
{
    public class FlowService : IFlowServiceInterface
    {
        private readonly IFlowRepositoryInterface _flowRepository;
        private readonly IFlowFactoryInterface _flowFactory;

        // Construtor que injeta as dependências necessárias
        public FlowService(IFlowRepositoryInterface flowRepository, IFlowFactoryInterface flowFactory)
        {
            _flowRepository = flowRepository;
            _flowFactory = flowFactory;
        }

        /// <summary>
        /// Obtém todos os fluxos e retorna uma resposta com uma lista de fluxos.
        /// </summary>
        public FlowListResponse GetAll()
        {
            var flows = _flowRepository.GetAll();
            var flowDtos = flows.Select(flow => new FlowViewModel(
                flow.Id,
                flow.Name,
                flow.FolderId
            )).ToList(); // Convert to List for better performance in case of large datasets
            
            return new FlowListResponse("Success", "200", flowDtos);
        }

        /// <summary>
        /// Obtém um fluxo pelo ID e retorna uma resposta com os dados do fluxo.
        /// </summary>
        public SingleFlowResponse? GetById(int id)
        {
            var flow = _flowRepository.GetById(id);
            if (flow == null)
            {
                return new SingleFlowResponse("Flow not found", "404", null);
            }

            var flowDto = new FlowViewModel(
                flow.Id,
                flow.Name,
                flow.FolderId
            );

            return new SingleFlowResponse("Success", "200", flowDto);
        }

        /// <summary>
        /// Obtém fluxos pelo nome e retorna uma resposta com os dados dos fluxos.
        /// </summary>
        public SingleFlowResponse GetByName(string name)
        {
            var flow = _flowRepository.GetByName(name);

            if (flow == null)
            {
                return new SingleFlowResponse("Flow not found", "404", null);
            }

            var flowDto = new FlowViewModel(
                flow.Id,
                flow.Name,
                flow.FolderId
            );

            return new SingleFlowResponse("Success", "200", flowDto);
        }

        /// <summary>
        /// Cria um novo fluxo com base nos dados fornecidos e retorna uma resposta com o fluxo criado.
        /// </summary>
        public SingleFlowResponse Save(CreateFlowRequestDTO flowDto)
        {
            // Valida os dados do fluxo usando FlowFactory
            _flowFactory.ValidateCreateFlowRequest(flowDto);

            // Cria um novo fluxo a partir do DTO
            var flow = _flowFactory.CreateFlow(flowDto);

            // Salva o fluxo no repositório
            var savedFlow = _flowRepository.Add(flow);

            // Cria e retorna a resposta
            var responseDto = new FlowViewModel(
                savedFlow.Id,
                savedFlow.Name,
                savedFlow.FolderId
            );
            
            return new SingleFlowResponse("Flow created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza um fluxo existente com base nos dados fornecidos e retorna uma resposta com o fluxo atualizado.
        /// </summary>
        public SingleFlowResponse Update(int id, UpdateFlowRequestDTO flowDto)
        {
            // Valida os dados do fluxo usando FlowFactory
            _flowFactory.ValidateUpdateFlowRequest(flowDto);

            // Recupera o fluxo existente
            var existingFlow = _flowRepository.GetById(id);
            if (existingFlow == null)
            {
                return new SingleFlowResponse("Flow not found", "404", null);
            }

            // Atualiza o fluxo com os dados do DTO
            var updatedFlow = _flowFactory.UpdateFlow(existingFlow, flowDto);

            // Salva o fluxo atualizado no repositório
            var savedFlow = _flowRepository.Update(updatedFlow);

            // Cria e retorna a resposta
            var responseDto = new FlowViewModel(
                savedFlow.Id,
                savedFlow.Name,
                savedFlow.FolderId
            );
            
            return new SingleFlowResponse("Flow updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta um fluxo pelo ID e retorna uma resposta com o fluxo deletado.
        /// </summary>
        public SingleFlowResponse Delete(int id)
        {
            // Deleta o fluxo do repositório
            var deletedFlow = _flowRepository.Delete(id);
            if (deletedFlow == null)
            {
                return new SingleFlowResponse("Flow not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new FlowViewModel(
                deletedFlow.Id,
                deletedFlow.Name,
                deletedFlow.FolderId
            );

            return new SingleFlowResponse("Flow deleted successfully", "200", responseDto);
        }
    }
}
