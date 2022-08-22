using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeFileUrlsService
    {
        // 查询文件下载URL
        // 适用场景：通过传参合同流程编号，下载对应的合同PDF文件流到本地。
        public DescribeFileUrlsResponse DescribeFileUrls(string operatorUserId, string flowId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeFileUrlsRequest req = new DescribeFileUrlsRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 文件对应的业务类型，目前支持：
            // - 模板 "TEMPLATE"
            // - 文档 "DOCUMENT"
            // - 印章 “SEAL”
            // - 流程 "FLOW"
            req.BusinessType = "FLOW";

            // 业务编号的数组，如模板编号、文档编号、印章编号
            // 最大支持20个资源
            req.BusinessIds = new string[] { flowId };

            DescribeFileUrlsResponse resp = client.DescribeFileUrlsSync(req);
            return resp;
        }

    }
}