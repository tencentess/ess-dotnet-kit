using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// CreatePrepareFlow 创建快速发起流程
//
// 官网文档：https://cloud.tencent.com/document/product/1323/83412
//
// 适用场景：用户通过API 合同文件及签署信息，并可通过我们返回的URL在页面完成签署控件等信息的编辑与确认，快速发起合同.
// 注：该接口文件的resourceId 是通过上传文件之后获取的。
namespace api
{
    public class CreatePrepareFlowService
    {
        public CreatePrepareFlowResponse CreatePrepareFlow(string operatorUserId, string flowName, string resourceId, FlowCreateApprover[] approvers)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreatePrepareFlowRequest req = new CreatePrepareFlowRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 签署流程参与者信息
            req.Approvers = approvers;

            // 签署流程名称,最大长度200个字符
            req.FlowName = flowName;
            
            // 资源Id,通过上传UploadFiles接口获得
            req.ResourceId = resourceId;

            CreatePrepareFlowResponse resp = client.CreatePrepareFlowSync(req);

            return resp;
        }

    }
}