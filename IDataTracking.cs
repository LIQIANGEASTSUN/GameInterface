using System.Collections.Generic;

namespace GameInterface
{
    /// <summary>
    /// 提供数据分析服务的初始化、事件上报和追踪标识查询能力。
    /// </summary>
    public interface IDataTrackingCommon
    {
        /// <summary>
        /// 启动数据分析服务的初始化；方法返回不表示异步初始化已经完成。
        /// </summary>
        void Init();

        /// <summary>
        /// 向数据分析服务记录事件。
        /// </summary>
        /// <param name="eventName">事件名称。</param>
        /// <param name="parameters">事件的附加属性；为 <c>null</c> 时不提供附加属性。</param>
        void Log(string eventName, Dictionary<string, object> parameters = null);

        /// <summary>
        /// 获取当前数据分析服务使用的追踪标识。
        /// </summary>
        /// <returns>由具体服务定义的追踪标识，不一定是游戏账号 ID；不可用时的返回值由具体实现约定。</returns>
        string GetID();
    }

    /// <summary>
    /// 管理游戏账号与数据分析服务追踪身份的关联。
    /// </summary>
    public interface IDataTrackingLogin
    {
        /// <summary>
        /// 将后续数据分析行为关联到指定游戏账号；此操作本身不表示上报登录事件。
        /// </summary>
        /// <param name="gameId">游戏账号的标识。</param>
        void Login(string gameId);

        /// <summary>
        /// 清除数据分析服务中当前关联的游戏账号。
        /// </summary>
        void Logout();
    }

    /// <summary>
    /// 提供首次设置用户属性和首次事件上报能力。
    /// </summary>
    public interface IDataTrackingLog
    {
        /// <summary>
        /// 设置用户尚未赋值的属性，已设置的属性保持原值。
        /// </summary>
        /// <param name="properties">待首次设置的用户属性；为 <c>null</c> 时不提供属性。</param>
        void UserSetOnce(Dictionary<string, object> properties = null);

        /// <summary>
        /// 按数据分析服务的首次事件规则记录事件，去重范围由具体实现约定。
        /// </summary>
        /// <param name="eventName">首次事件的名称。</param>
        /// <param name="parameters">事件的附加属性；为 <c>null</c> 时不提供附加属性。</param>
        /// <param name="checkID">可选的首次事件去重标识；是否使用及空字符串的含义由具体实现约定。</param>
        void LogFirstEvent(string eventName, Dictionary<string, object> parameters = null, string checkID = "");
    }
}
