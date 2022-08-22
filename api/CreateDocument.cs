using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateDocumentService
    {
        // 创建电子文档
        // 适用场景：见创建签署流程接口。注：该接口需要给对应的流程指定一个模板id，并且填充该模板中需要补充的信息。是“发起流程”接口的前置接口。
        public CreateDocumentResponse CreateDocument(string operatorUserId, string flowId, string templateId, string fileName)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateDocumentRequest req = new CreateDocumentRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 文件名列表,单个文件名最大长度200个字符
            req.FileNames = new string[] { fileName };

            // 签署流程编号,由CreateFlow接口返回
            req.FlowId = flowId;

            // 用户上传的模板ID,在控制台模版管理中可以找到
            // 单个个人签署模版
            req.TemplateId = templateId;

            CreateDocumentResponse resp = client.CreateDocumentSync(req);
            return resp;
        }
    }
}