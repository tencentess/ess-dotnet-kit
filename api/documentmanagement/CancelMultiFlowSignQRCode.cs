using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CancelMultiFlowSignQRCodeService
    {
        public CancelMultiFlowSignQRCodeResponse CancelMultiFlowSignQRCode(string operatorUserId, string qrCodeId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CancelMultiFlowSignQRCodeRequest req = new CancelMultiFlowSignQRCodeRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.QrCodeId = qrCodeId;

            CancelMultiFlowSignQRCodeResponse resp = client.CancelMultiFlowSignQRCodeSync(req);

            return resp;
        }
    }
}