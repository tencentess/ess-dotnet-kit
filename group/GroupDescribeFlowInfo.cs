using api;
using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupDescribeFlowInfoService
    {
        public DescribeFlowInfoResponse DescribeFlowInfo(string operatorUserId, string flowId, string proxyOrganizationId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFlowInfoRequest req = new DescribeFlowInfoRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;
            
            // 设置集团子企业账号
            Agent agent = new Agent();
            agent.ProxyOrganizationId = proxyOrganizationId;
            req.Agent = agent;

            req.FlowIds = new string[] { flowId };

            DescribeFlowInfoResponse resp = client.DescribeFlowInfoSync(req);
            return resp;
        }

    }
}