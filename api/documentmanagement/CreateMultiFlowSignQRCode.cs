using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// CreateMultiFlowSignQRCode 创建一码多扫流程签署二维码
//
// 官网文档：https://cloud.tencent.com/document/product/1323/75450
//
//
// 此接口（CreateMultiFlowSignQRCode）用于创建一码多扫流程签署二维码。
// 适用场景：无需填写签署人信息，可通过模板id生成签署二维码，签署人可通过扫描二维码补充签署信息进行实名签署。常用于提前不知道签署人的身份信息场景，例如：劳务工招工、大批量员工入职等场景。
// 适用的模板仅限于B2C（1、无序签署，2、顺序签署时B静默签署，3、顺序签署时B非首位签署）、单C的模板，且模板中发起方没有填写控件。
namespace api
{
    public class CreateMultiFlowSignQRCodeService
    {
        public CreateMultiFlowSignQRCodeResponse CreateMultiFlowSignQRCode(string operatorUserId, string templateId, string flowName)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateMultiFlowSignQRCodeRequest req = new CreateMultiFlowSignQRCodeRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 模板ID
            req.TemplateId = templateId;

            // 签署流程名称,最大长度200个字符
            req.FlowName = flowName;

            CreateMultiFlowSignQRCodeResponse resp = client.CreateMultiFlowSignQRCodeSync(req);
            return resp;
        }

    }
}