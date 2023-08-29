using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class DescribeThirdPartyAuthCodeService
    {
        public DescribeThirdPartyAuthCodeResponse DescribeThirdPartyAuthCode(string operatorUserId, string templateId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            DescribeThirdPartyAuthCodeRequest req = new DescribeThirdPartyAuthCodeRequest();

            req.AuthCode = "********************************";

            DescribeThirdPartyAuthCodeResponse resp = client.DescribeThirdPartyAuthCodeSync(req);
            return resp;
        }

    }
}