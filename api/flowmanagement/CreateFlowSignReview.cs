using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateFlowSignReviewService
    {
        public CreateFlowSignReviewResponse CreateFlowSignReview(string operatorUserId, string flowId, string reviewType, string reviewMessage) {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            // 构造请求体
            CreateFlowSignReviewRequest request = new CreateFlowSignReviewRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            request.Operator = userInfo;

            request.FlowId = flowId;

            request.ReviewType = reviewType;

            request.ReviewMessage = reviewMessage;

            CreateFlowSignReviewResponse resp = client.CreateFlowSignReviewSync(request);
        
            return resp;
        }
        
    }
}