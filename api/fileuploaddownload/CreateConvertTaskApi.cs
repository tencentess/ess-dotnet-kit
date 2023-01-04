using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// CreateConvertTaskApi 创建文件转换任务
//
// 官网文档：https://cloud.tencent.com/document/product/1323/78149
//
// 此接口用于创建文件转换任务
// 适用场景：将doc/docx文件转化为pdf文件
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

            // 资源Id，由UploadFiles接口返回
            req.ResourceId = resourceId;

            // 资源类型，2-doc 3-docx
            req.ResourceType = resourceType;

            // 资源名称
            req.ResourceName = resourceName;

            CreateConvertTaskApiResponse resp = client.CreateConvertTaskApiSync(req);
            return resp;
        }
    }
}