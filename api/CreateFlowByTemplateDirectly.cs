using TencentCloud.Ess.V20201111.Models;
using System.Threading;

namespace api
{
    public class CreateFlowByTemplateDirectlyResponse
    {
        public string FlowId;
        public string SchemeUrl;
    }

    public class CreateFlowByTemplateDirectlyService
    {
        // 通过模板发起签署流程，并查询签署链接
        public CreateFlowByTemplateDirectlyResponse CreateFlowByTemplateDirectly(string operatorUserId, string flowName, FlowCreateApprover[] approvers)
        {
            // 创建流程
            CreateFlowResponse createFlowResponse = new CreateFlowService().CreateFlow(operatorUserId, flowName, approvers);
            string flowId = createFlowResponse.FlowId;

            // 创建电子文档
            new CreateDocumentService().CreateDocument(operatorUserId, flowId, Configs.templateId, flowName);

            // 等待文档异步合成
            Thread.Sleep(3000);

            // 开启流程
            new StartFlowService().StartFlow(operatorUserId, flowId);

            // 获取签署链接
            CreateSchemeUrlResponse schemeResp = new CreateSchemeUrlService().CreateSchemeUrl(operatorUserId, flowId);
            string schemeUrl = schemeResp.SchemeUrl;

            CreateFlowByTemplateDirectlyResponse resp = new CreateFlowByTemplateDirectlyResponse();
            resp.SchemeUrl = schemeUrl;
            resp.FlowId = flowId;

            return resp;
        }
    }
}