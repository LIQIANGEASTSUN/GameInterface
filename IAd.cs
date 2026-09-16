using System;

namespace GameInterface
{
    /// <summary>
    /// 提供广告服务的初始化、展示可用性检查、展示请求和调试入口。
    /// </summary>
    public interface IAd
    {
        /// <summary>
        /// 启动广告服务的初始化；方法返回不表示广告已经加载或可以展示。
        /// </summary>
        void Init();

        /// <summary>
        /// 检查指定类型的广告当前是否可以展示；具体实现也可能在检查时触发加载。
        /// </summary>
        /// <param name="adType">要检查的广告类型。</param>
        /// <returns>当前可以展示时为 <c>true</c>，否则为 <c>false</c>。</returns>
        bool EnableDisplay(ADType adType);

        /// <summary>
        /// 尝试发起指定类型广告的展示请求。
        /// </summary>
        /// <param name="adType">要展示的广告类型。</param>
        /// <param name="successCallback">广告成功开始展示时的通知回调，不表示观看完成或获得奖励。</param>
        /// <param name="errorCallback">用于接收广告展示失败通知的回调。</param>
        /// <returns>已发起展示请求时为 <c>true</c>，未发起时为 <c>false</c>；返回值不表示广告已经展示成功。</returns>
        bool Display(ADType adType, Action successCallback, Action errorCallback);

        /// <summary>
        /// 打开广告服务提供的调试或诊断界面。
        /// </summary>
        void ShowDebugger();
    }
}
