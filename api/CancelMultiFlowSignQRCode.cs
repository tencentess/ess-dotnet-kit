using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CancelMultiFlowSignQRCodeService
    {
        // 此接口（CancelMultiFlowSignQRCode）用于取消一码多扫二维码。该接口对传入的二维码ID，若还在有效期内，可以提前失效。
        public CancelMultiFlowSignQRCodeResponse CancelMultiFlowSignQRCode(string operatorUserId, string qrCodeId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CancelMultiFlowSignQRCodeRequest req = new CancelMultiFlowSignQRCodeRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 二维码id
            req.QrCodeId = qrCodeId;

            CancelMultiFlowSignQRCodeResponse resp = client.CancelMultiFlowSignQRCodeSync(req);

            return resp;
        }
    }
}