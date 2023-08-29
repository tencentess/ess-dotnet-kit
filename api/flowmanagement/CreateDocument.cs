using System;
using TencentCloud.Ess.V20201111;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateDocumentService
    {
        public CreateDocumentResponse CreateDocument(string operatorUserId, string flowId, string templateId,
            string fileName)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateDocumentRequest req = new CreateDocumentRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.FileNames = new string[] { fileName };

            req.FlowId = flowId;

            req.TemplateId = templateId;

            CreateDocumentResponse resp = client.CreateDocumentSync(req);
            return resp;
        }

        // CreateDocumentExtended CreateDocument接口的详细参数使用样例，前面简要调用的场景不同，此版本旨在提供可选参数的填入参考。
        // 如果您在实现基础场景外有进一步的功能实现需求，可以参考此处代码。
        // 注意事项：此处填入参数仅为样例，请在使用时更换为实际值。
        public void CreateDocumentExtended()
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateDocumentRequest req = new CreateDocumentRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = Configs.operatorUserId;
            req.Operator = userInfo;

            req.FlowId = "**********************";

            req.FileNames = new[] { "**********************" };
            
            FormField formField1 = new FormField();
            formField1.ComponentName = "单行文本";
            formField1.ComponentValue = "文本内容";
            FormField formField2 = new FormField();
            formField2.ComponentName = "勾选框";
            formField2.ComponentValue = "true";
            req.FormFields = new[] { formField1, formField2 };
            
            req.NeedPreview = true;

            req.PreviewType = 1;

            req.ClientToken = "*********token*******";

            CreateDocumentResponse resp = client.CreateDocumentSync(req);
            
            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}