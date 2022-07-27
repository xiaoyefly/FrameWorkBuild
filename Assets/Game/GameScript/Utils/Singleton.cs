// 版权所有[成都尼毕鲁科技股份有限公司]
// 根据《保密信息使用许可证》获得许可;
// 除非符合许可，否则您不得使用此文件。
// 您可以在以下位置获取许可证副本，链接地址：
// https://wiki.tap4fun.com/pages/viewpage.action?pageId=29818250
// 除非适用法律要求或书面同意，否则保密信息按照使用许可证要求使用， 不附带任何明示或暗示的保证或条件。
// 有关管理权限的特定语言，请参阅许可证副本。


/// <summary>
/// Singleton.cs
/// Created by wangxw 2014-10-22
/// 单件模板
/// </summary>

using System;

public class Singleton<T> where T : new()
{
    // 单件实例对象
    protected static T mInstance = default;

    /// <summary>
    /// 获取单件对象
    /// </summary>
    /// <value>单件实例</value>
    public static T Instance
    {
        get
        {
            // 没有单件，则立即创建一个
            // Thread Unsafe
            if (mInstance == null)
                mInstance = ((default(T) == null) ? Activator.CreateInstance<T>() : default);

            return mInstance;
        }
    }

    /// <summary>
    /// 清理单件对象
    /// </summary>
    public void CleanInstance()
    {
        mInstance = default;
    }
}