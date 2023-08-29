using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

namespace api
{
    public class CreateConvertTaskApiService
    {
        public CreateConvertTaskApiResponse CreateConvertTaskApi(string operatorUserId, string resourceId, string resourceType, string resourceName)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.endPoint);

            CreateConvertTaskApiRequest req = new CreateConvertTaskApiRequest();

            // 调用方用户信息，参考通用结构
            UserInfo userInfo = new UserInfo();
            userInfo.UserId = operatorUserId;
            req.Operator = userInfo;

            req.ResourceId = resourceId;

            req.ResourceType = resourceType;

            req.ResourceName = resourceName;

            CreateConvertTaskApiResponse resp = client.CreateConvertTaskApiSync(req);
            return resp;
        }
    }
}