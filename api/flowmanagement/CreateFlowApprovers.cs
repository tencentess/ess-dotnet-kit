using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

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

            request.FlowId = flowId;

            request.Approvers = approvers;

            CreateFlowApproversResponse resp = client.CreateFlowApproversSync(request); 
        
            return resp;
        }
        
    }
}