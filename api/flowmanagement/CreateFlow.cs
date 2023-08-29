using System;
using TencentCloud.Ess.V20201111;
using TencentCloud.Common;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowService
    {
        public CreateFlowResponse CreateFlow(string operatorUserId, string flowName, FlowCreateApprover[] approvers)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowRequest req = new CreateFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.Approvers = approvers;

            req.FlowName = flowName;

            CreateFlowResponse resp = client.CreateFlowSync(req);

            return resp;
        }

        // CreateFlowExtended CreateFlow接口的详细参数使用样例，前面简要调用的场景不同，此版本旨在提供可选参数的填入参考。
        // 如果您在实现基础场景外有进一步的功能实现需求，可以参考此处代码。
        // 注意事项：此处填入参数仅为样例，请在使用时更换为实际值。
        public void CreateFlowExtended()
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateFlowRequest req = new CreateFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = Configs.operatorUserId;
            req.Operator = userInfo;

            req.FlowName = "测试合同";

            // 构建签署方信息，注意这里的签署人类型、数量、顺序需要和模板中的设置保持一致

            // 企业静默签署
            FlowCreateApprover serverEnt = new FlowCreateApprover();
            serverEnt.ApproverType = 3;
            serverEnt.NotifyType = "sms";

            // 个人签署
            FlowCreateApprover person = new FlowCreateApprover();
            person.ApproverType = 1;
            person.ApproverName = "张三";
            person.ApproverMobile = "1*********8";
            person.NotifyType = "sms";

            // 企业签署
            FlowCreateApprover ent = new FlowCreateApprover();
            ent.ApproverType = 0;
            ent.ApproverName = "李四";
            ent.ApproverMobile = "1*********1";
            ent.OrganizationName = "XXXXX公司";
            ent.NotifyType = "sms";

            req.Approvers = new[] { serverEnt, ent, person };

            req.Unordered = false;

            req.UserData = "UserData";

            long now = DateTimeOffset.Now.ToUnixTimeSeconds();
            req.DeadLine = now + 7 * 24 * 3600;

            CreateFlowResponse resp = client.CreateFlowSync(req);


            // 输出json格式的字符串回包
            Console.WriteLine(AbstractModel.ToJsonString(resp));
        }
    }
}