using TencentCloud.Ess.V20201111.Models;

// 通过文件base64直接发起签署流程，返回flowid
namespace api
{
    public class CreateFlowByFileDirectlyResponse
    {
        public string FlowId;
        public string SchemeUrl;
    }

    public class CreateFlowByFileDirectlyService
    {
        // 通过文件base64直接发起签署流程，返回flowid
        public CreateFlowByFileDirectlyResponse CreateFlowByFileDirectly(string operatorUserId, string fileBase64, string flowName, ApproverInfo[] approvers)
        {

            // 上传文件获取fileId
            UploadFilesResponse uploadResponse = new UploadFilesService().UploadFiles(operatorUserId, fileBase64, flowName);
            string fileId = uploadResponse.FileIds[0];

            // 创建签署流程
            CreateFlowByFilesResponse createFlowResp = new CreateFlowByFilesService().CreateFlowByFiles(operatorUserId, flowName, approvers, fileId);
            string flowId = createFlowResp.FlowId;

            // 获取签署链接
            CreateSchemeUrlResponse schemeResp = new CreateSchemeUrlService().CreateSchemeUrl(operatorUserId, flowId);
            string schemeUrl = schemeResp.SchemeUrl;

            CreateFlowByFileDirectlyResponse resp = new CreateFlowByFileDirectlyResponse();
            resp.SchemeUrl = schemeUrl;
            resp.FlowId = flowId;

            return resp;
        }

    }
}