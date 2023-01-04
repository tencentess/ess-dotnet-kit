using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// GetTaskResultApi 查询转换任务状态
//
// 官网文档：https://cloud.tencent.com/document/product/1323/78148
//
// 此接口用于查询转换任务状态
// 适用场景：将doc/docx文件转化为pdf文件
// 注：该接口是“创建文件转换任务”接口的后置接口，用于查询转换任务的执行结果
namespace api
{
    public class GetTaskResultApiService
    {
        // 通过AuthCode查询用户是否实名
        public GetTaskResultApiResponse GetTaskResultApi(string operatorUserId, string taskId)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            GetTaskResultApiRequest req = new GetTaskResultApiRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            // 任务Id，“创建文件转换任务”接口返回
            req.TaskId = taskId;

            GetTaskResultApiResponse resp = client.GetTaskResultApiSync(req);
            return resp;
        }

    }
}