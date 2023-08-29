using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateBatchCancelFlowUrlService
    {
        public CreateBatchCancelFlowUrlResponse CreateBatchCancelFlowUrl(string operatorUserId, string[] flowIds) {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            // 构造请求体
            CreateBatchCancelFlowUrlRequest request = new CreateBatchCancelFlowUrlRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            request.Operator = userInfo;

            request.FlowIds = flowIds;
            
            CreateBatchCancelFlowUrlResponse resp = client.CreateBatchCancelFlowUrlSync(request);
        
            return resp;
        }
        
    }
}