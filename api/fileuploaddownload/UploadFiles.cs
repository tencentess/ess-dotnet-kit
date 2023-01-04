using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

// UploadFiles 此接口（UploadFiles）用于文件上传。
//
// 官网文档：https://cloud.tencent.com/document/api/1323/73066
//
// 适用场景：用于生成pdf资源编号（FileIds）来配合“用PDF创建流程”接口使用，使用场景可详见“用PDF创建流程”接口说明。
// 调用是请注意此处的 Endpoint 和其他接口不同
namespace api
{
    public class UploadFilesService
    {
        public UploadFilesResponse UploadFiles(string operatorUserId, string fileBase64, string filename)
        {
            // 构造客户端调用实例
            EssClient client = Common.GetClientInstance(Configs.secretId, Configs.secretKey, Configs.fileServiceEndPoint);

            UploadFilesRequest req = new UploadFilesRequest();

            // 调用方用户信息，参考通用结构
            Caller caller = new Caller();
            caller.OperatorId = operatorUserId;
            req.Caller = caller;

            // 文件对应业务类型，用于区分文件存储路径：
            // 1. TEMPLATE - 模板； 文件类型：.pdf/.html
            // 2. DOCUMENT - 签署过程及签署后的合同文档 文件类型：.pdf/.html
            // 3. SEAL - 印章； 文件类型：.jpg/.jpeg/.png
            req.BusinessType = "DOCUMENT";

            // 上传文件内容
            UploadFile file = new UploadFile();
            // Base64编码后的文件内容
            file.FileBody = fileBase64;
            // 文件名，最大长度不超过200字符
            file.FileName = filename;

            req.FileInfos = new UploadFile[] { file };

            UploadFilesResponse resp = client.UploadFilesSync(req);
            return resp;
        }

    }
}