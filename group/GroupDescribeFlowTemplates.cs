using api;
using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace group
{
    public class GroupDescribeFlowTemplatesService
    {
        public DescribeFlowTemplatesResponse DescribeFlowTemplates(string operatorUserId, string templateId, string proxyOrganizationId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFlowTemplatesRequest req = new DescribeFlowTemplatesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 设置集团子企业账号
            Agent agent = new Agent();
            agent.ProxyOrganizationId = proxyOrganizationId;
            req.Agent = agent;
            
            // 需要查询的模板ID列表
            Filter filter = new Filter();
            filter.Key = "template-id";  // 查询过滤条件的Key
            filter.Values = new string[] { templateId }; // 查询过滤条件的Value列表

            req.Filters = new Filter[] { filter };

            DescribeFlowTemplatesResponse resp = client.DescribeFlowTemplatesSync(req);
            return resp;
        }

    }
}