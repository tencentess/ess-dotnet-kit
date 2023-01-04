using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// CreateFlowApprovers 补充签署流程本企业签署人信息
//
// 官网文档：https://cloud.tencent.com/document/product/1323/80033
//
//适用场景：在通过模版或者文件发起合同时，若未指定本企业签署人信息，则流程发起后，可以调用此接口补充签署人。
//同一签署人可以补充多个员工作为候选签署人,最终签署人取决于谁先领取合同完成签署。
//
//注：目前暂时只支持补充来源于企业微信的员工作为候选签署人
namespace api
{
    public class CreateFlowApproversService
    {
        public CreateFlowApproversResponse CreateFlowApprovers(string operatorUserId, string flowId, FillApproverInfo[] approvers)  {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            // 构造请求体
            CreateFlowApproversRequest request = new CreateFlowApproversRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            request.Operator = userInfo;

            // 签署流程编号
            request.FlowId = flowId;

            request.Approvers = approvers;

            CreateFlowApproversResponse resp = client.CreateFlowApproversSync(request); 
        
            return resp;
        }
        
    }
}