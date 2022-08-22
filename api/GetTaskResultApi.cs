using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

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