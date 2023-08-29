using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFileUrlsService
    {
        public DescribeFileUrlsResponse DescribeFileUrls(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFileUrlsRequest req = new DescribeFileUrlsRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.BusinessType = "FLOW";

            req.BusinessIds = new string[] { flowId };

            DescribeFileUrlsResponse resp = client.DescribeFileUrlsSync(req);
            return resp;
        }

    }
}