using TencentCloud.Ess.V20201111;
using TencentCloud.Ess.V20201111.Models;

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

            req.BusinessType = "DOCUMENT";

            // 上传文件内容
            UploadFile file = new UploadFile();
            file.FileBody = fileBase64;
            file.FileName = filename;

            req.FileInfos = new UploadFile[] { file };

            UploadFilesResponse resp = client.UploadFilesSync(req);
            return resp;
        }

    }
}