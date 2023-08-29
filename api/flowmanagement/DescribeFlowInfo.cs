using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFlowInfoService
    {
        public DescribeFlowInfoResponse DescribeFlowInfo(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFlowInfoRequest req = new DescribeFlowInfoRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.FlowIds = new string[] { flowId };

            DescribeFlowInfoResponse resp = client.DescribeFlowInfoSync(req);
            return resp;
        }

    }
}