using api;
using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// DescribeFlowInfo 查询合同详情
//
// 官网文档：https://cloud.tencent.com/document/product/1323/80032
//
// 查询合同详情
// 适用场景：可用于主动查询某个合同详情信息。
//
// tips: 如果仅需查询合同摘要，需要使用查询合同摘要接口 https://cloud.tencent.com/document/product/1323/70358
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

            // 需要查询的流程ID列表
            req.FlowIds = new string[] { flowId };

            DescribeFlowInfoResponse resp = client.DescribeFlowInfoSync(req);
            return resp;
        }

    }
}