using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CZKJ.Logger
{

    public static class InitRepository
    {
        public static ILoggerRepository loggerRepository { get; set; }
    }

    public static class LogHelper
    {
        public static readonly ILog logerror = LogManager.GetLogger(InitRepository.loggerRepository.Name, "logerror");

        public static readonly ILog loginfo = LogManager.GetLogger(InitRepository.loggerRepository.Name, "loginfo");

        #region 全局异常错误记录持久化
        /// <summary>
        /// 全局异常错误记录持久化
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        public static void ErrorLog(string throwMsg, Exception ex)
        {
            string errorMsg = string.Format("【抛出信息】：{0} \n【异常类型】：{1} \n【异常信息】：{2} \n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });

            logerror.Error(errorMsg);
        }
        #endregion

        #region 自定义操作记录
        /// <summary>
        /// 自定义操作记录，与仓储中的增删改的日志是记录同一张表
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string throwMsg, Exception ex)
        {
            string errorMsg = string.Format("【抛出信息】：{0} \n【异常类型】：{1} \n【异常信息】：{2} \n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });

            logerror.Error(errorMsg);
        }
        #endregion
    }
}
