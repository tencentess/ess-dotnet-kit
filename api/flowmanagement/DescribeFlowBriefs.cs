using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFlowBriefsService
    {
        public DescribeFlowBriefsResponse DescribeFlowBriefs(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFlowBriefsRequest req = new DescribeFlowBriefsRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.FlowIds = new string[] { flowId };

            DescribeFlowBriefsResponse resp = client.DescribeFlowBriefsSync(req);
            return resp;
        }

    }
}