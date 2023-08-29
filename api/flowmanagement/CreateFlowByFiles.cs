using System;
using TencentCloud.Ess.V20201111;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowByFilesService
    {
        public CreateFlowByFilesResponse CreateFlowByFiles(string operatorUserId, string flowName,
            ApproverInfo[] approvers, string fileId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowByFilesRequest req = new CreateFlowByFilesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.FileIds = new string[] { fileId };

            req.Approvers = approvers;

            req.FlowName = flowName;

            CreateFlowByFilesResponse resp = client.CreateFlowByFilesSync(req);

            return resp;
        }


        // CreateFlowByFilesExtended CreateFlowByFiles接口的详细参数使用样例，前面简要调用的场景不同，此版本旨在提供可选参数的填入参考。
        // 如果您在实现基础场景外有进一步的功能实现需求，可以参考此处代码。
        // 注意事项：此处填入参数仅为样例，请在使用时更换为实际值。
        public void CreateFlowByFilesExtended()
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowByFilesRequest req = new CreateFlowByFilesRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = Configs.operatorUserId;
            req.Operator = userInfo;

            req.FlowName = "测试合同";

            // 构建签署方信息
            // 注意：文件发起时，签署方不能进行控件填写！！！如果有填写需求，请设置为发起方填写，或者使用模板发起！！！

            // 企业静默签署
            ApproverInfo serverEnt = new ApproverInfo();
            serverEnt.ApproverType = 3;

            // 这里可以设置企业方自动签章，分别可以使用坐标、表单域、关键字进行定位
            serverEnt.SignComponents = new[]
            {
                // 坐标定位，印章类型，并传入印章Id
                buildComponentNormal("SIGN_SEAL", "*************"),
                // 表单域定位，印章类型，并传入印章Id
                buildComponentField("SIGN_SEAL", "*************"),
                // 关键字定位，印章类型，并传入印章Id
                buildComponentKeyword("SIGN_SEAL", "*************")
            };

            // 个人签署
            ApproverInfo person = new ApproverInfo();
            person.ApproverType = 1;
            person.ApproverName = "张三";
            person.ApproverMobile = "1*********8";
            person.SignComponents = new[]
            {
                // 坐标定位，手写签名类型
                buildComponentNormal("SIGN_SIGNATURE", ""),
                // 表单域定位，手写签名类型
                buildComponentField("SIGN_SIGNATURE", ""),
                // 关键字定位，手写签名类型
                buildComponentKeyword("SIGN_SIGNATURE", "")
            };

            // 企业签署
            ApproverInfo ent = new ApproverInfo();
            ent.ApproverType = 0;
            ent.ApproverName = "李四";
            ent.ApproverMobile = "1*********1";
            ent.OrganizationName = "XXXXX公司";
            ent.SignComponents = new[]
            {
                // 坐标定位，印章类型
                buildComponentNormal("SIGN_SEAL", ""),
                // 表单域定位，印章类型
                buildComponentField("SIGN_SEAL", ""),
                // 关键字定位，印章类型
                buildComponentKeyword("SIGN_SEAL", "")
            };

            req.Approvers = new[] { serverEnt, ent, person };

            req.FileIds = new[] { "*************************" };

            req.FlowType = "销售合同";

            req.Components = new[]
            {
                // 坐标定位，单行文本类型
                buildComponentNormal("TEXT", "单行文本"),
                // 表单域定位，单行文本类型
                buildComponentField("TEXT", "单行文本"),
                // 关键字定位，单行文本类型
                buildComponentKeyword("TEXT", "单行文本")
            };

            req.PreviewType = 0;

            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            req.Deadline = now + 7 * 24 * 3600;

            req.Unordered = false;

            req.UserData = "UserData";


            CreateFlowByFilesResponse resp = client.CreateFlowByFilesSync(req);

            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }

        // buildSignComponentNormal 使用坐标模式进行控件定位
        public Component buildComponentNormal(string componentType, string componentValue)
        {
            Component component = new Component();
            component.ComponentPosX = 146.15625f;
            component.ComponentPosY = 472.78125f;
            component.ComponentWidth = 112f;
            component.ComponentHeight = 40f;

            component.FileIndex = 0;

            component.ComponentPage = 1;

            component.ComponentType = componentType;

            if (componentValue != "")
            {
                component.ComponentValue = componentType;
            }

            return component;
        }

        // buildComponentKeyword 使用关键字模式进行控件定位
        public Component buildComponentKeyword(string componentType, string componentValue)
        {
            Component component = new Component();

            component.GenerateMode = "KEYWORD";

            component.ComponentId = "签名";

            component.ComponentWidth = 112;
            component.ComponentHeight = 40;

            component.FileIndex = 0;

            component.OffsetX = 10.5f;
            component.OffsetY = 10.5f;

            component.KeywordOrder = "Reverse";

            component.KeywordIndexes = new long?[] { 1 };

            component.ComponentType = componentType;

            if (componentValue != "")
            {
                component.ComponentValue = componentType;
            }

            return component;
        }

        // buildComponentField 使用表单域模式进行控件定位
        public Component buildComponentField(string componentType, string componentValue)
        {
            Component component = new Component();

            component.GenerateMode = "FIELD";

            component.ComponentName = "表单";

            component.FileIndex = 0;

            component.ComponentType = componentType;

            if (componentValue != "")
            {
                component.ComponentValue = componentType;
            }

            return component;
        }
    }
}