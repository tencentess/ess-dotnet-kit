using api;
using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupCreateSchemeUrlService
    {
        public CreateSchemeUrlResponse CreateSchemeUrl(string operatorUserId, string flowId, string proxyOrganizationId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateSchemeUrlRequest req = new CreateSchemeUrlRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;
            
            // 设置集团子企业账号
            Agent agent = new Agent();
            agent.ProxyOrganizationId = proxyOrganizationId;
            req.Agent = agent;


            req.FlowId = flowId;

            req.PathType = 1;

            CreateSchemeUrlResponse resp = client.CreateSchemeUrlSync(req);
            return resp;
        }

    }
}