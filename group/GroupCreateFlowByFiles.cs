using api;
using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupCreateFlowByFilesService
    {
        public CreateFlowByFilesResponse CreateFlowByFiles(string operatorUserId, string flowName,
            ApproverInfo[] approvers, string fileId, string proxyOrganizationId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowByFilesRequest req = new CreateFlowByFilesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 设置集团子企业账号
            Agent agent = new Agent();
            agent.ProxyOrganizationId = proxyOrganizationId;
            req.Agent = agent;

            req.FileIds = new string[] { fileId };

            // 签署流程参与者信息
            req.Approvers = approvers;

            req.FlowName = flowName;

            CreateFlowByFilesResponse resp = client.CreateFlowByFilesSync(req);

            return resp;
        }
    }
}