using System.Collections.Generic;

namespace GameInterface
{
    /// <summary>
    /// 提供平台设备标识、广告标识和广告跟踪可用状态。
    /// </summary>
    /// <remarks>
    /// 实例由 Unity 主线程创建。普通方法由调用方保证在 Unity 主线程执行，
    /// 不承诺任意线程安全；Android 广告方法须在工作线程调用，并拒绝创建线程和 Java UI 线程。
    /// 平台访问失败抛出 InvalidOperationException，iOS 设备参数错误抛出参数异常。
    /// 不缓存查询结果、不请求权限，也不记录标识内容。
    /// </remarks>
    public interface IDevice
    {
        /// <summary>
        /// 读取当前平台的设备标识；其连续性取决于平台、签名与配置，不保证永久唯一。
        /// </summary>
        /// <param name="parameters">
        /// iOS 必须提供 account、service、identifier 字符串，description 可省略；
        /// 本次调用解析后不保存字典，调用期间不得并发修改。其他平台忽略该参数。
        /// </param>
        string GetDeviceId(Dictionary<string, object> parameters = null);

        /// <summary>
        /// 读取当前可用的广告标识；受限、无有效标识或不支持时返回空字符串。
        /// Android 必须在工作线程调用；服务访问失败抛出异常。
        /// </summary>
        string GetAdvertisingId();

        /// <summary>
        /// 查询当前是否允许广告跟踪且具有有效广告标识。
        /// Android 必须在工作线程调用；与独立的标识查询不构成原子快照。
        /// </summary>
        bool GetAdvertisingTrackingEnabled();

        /// <summary>
        /// 删除本次参数定位的 iOS 持久标识；不存在视为成功，非 iOS 无副作用。
        /// 删除失败抛出异常，成功后下次读取创建新标识。
        /// </summary>
        /// <param name="parameters">
        /// iOS 使用与目标项一致的 account、service、identifier 字符串，description 可省略；
        /// 调用期间不得并发修改。其他平台忽略该参数。
        /// </param>
        void DeleteIosDeviceId(Dictionary<string, object> parameters = null);
    }
}
