using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// CreateBatchCancelFlowUrl 获取批量撤销签署流程链接
//
// 官网地址：https://cloud.tencent.com/document/product/1323/78262
//
// 电子签企业版：指定需要批量撤回的签署流程Id，获取批量撤销链接
// 客户指定需要撤回的签署流程Id，最多100个，超过100不处理；接口调用成功返回批量撤回合同的链接，通过链接跳转到电子签小程序完成批量撤回
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

            // 需要执行撤回的签署流程id数组，最多100个
            request.FlowIds = flowIds;
            
            CreateBatchCancelFlowUrlResponse resp = client.CreateBatchCancelFlowUrlSync(request);
        
            return resp;
        }
        
    }
}