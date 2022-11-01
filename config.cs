// 基础配置，调用API之前必须填充的参数
public class Configs
{
    // 调用API的密钥对，通过腾讯云控制台获取
    public static string secretId = "**********************";
    public static string secretKey = "**********************";

    // operatorUserId: 经办人Id，电子签控制台获取
    public static string operatorUserId = "**********************";

    // 企业方静默签用的印章Id，电子签控制台获取
    public static string serverSignSealId = "****************";

    // 模板Id，电子签控制台获取，仅在通过模板发起时使用
    public static string templateId = "****************";

    // API域名，现网使用 ess.tencentcloudapi.com
    public static string endPoint = "ess.test.ess.tencent.cn";

    // 文件服务域名，现网使用 file.ess.tencent.cn
    public static string fileServiceEndPoint = "file.test.ess.tencent.cn";


}