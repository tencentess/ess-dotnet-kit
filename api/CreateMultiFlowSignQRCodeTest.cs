using System;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateMultiFlowSignQRCodeTest
    {
        // 创建一码多扫流程签署二维码调用样例
        public static void Main1(string[] args)
        {
            // 模板ID
            string templateId = "********************************";
            // 签署流程名称，最大长度不超过200字符
            string flowName = "扫码签流程";

            CreateMultiFlowSignQRCodeService service = new CreateMultiFlowSignQRCodeService();
            CreateMultiFlowSignQRCodeResponse resp = service.CreateMultiFlowSignQRCode(Configs.operatorUserId, templateId, flowName);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}