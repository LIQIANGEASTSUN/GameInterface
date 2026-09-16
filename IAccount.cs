using System;
using System.Collections.Generic;

namespace GameInterface
{
    /// <summary>
    /// 提供账号服务的初始化、登录、登出和事件记录能力。
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// 启动账号服务的初始化；方法返回不表示异步初始化已经完成。
        /// </summary>
        void Init();

        /// <summary>
        /// 发起账号登录。
        /// </summary>
        /// <param name="successCallback">用于接收登录成功通知的回调。</param>
        /// <param name="failureCallback">用于接收登录失败通知的回调。</param>
        void Login(Action successCallback, Action failureCallback);

        /// <summary>
        /// 发起当前账号的登出。
        /// </summary>
        /// <param name="successCallback">用于接收登出成功通知的回调。</param>
        void Logout(Action successCallback);

        /// <summary>
        /// 通过账号服务记录应用事件；是否支持事件上报由具体实现决定。
        /// </summary>
        /// <param name="eventName">事件名称。</param>
        /// <param name="parameters">事件的附加属性；为 <c>null</c> 时不提供附加属性。</param>
        void Log(string eventName, Dictionary<string, string> parameters = null);
    }
}
