using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CancelMultiFlowSignQRCodeTest
    {
        public static void Main1(string[] args)
        {
            string qrCodeId = "********************************";

            CancelMultiFlowSignQRCodeService service = new CancelMultiFlowSignQRCodeService();
            CancelMultiFlowSignQRCodeResponse resp = service.CancelMultiFlowSignQRCode(Configs.operatorUserId, qrCodeId);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}