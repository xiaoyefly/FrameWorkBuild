using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIManager : Singleton<UIManager> {
    /// <summary>
    /// UI信息
    /// </summary>
    [System.Serializable]
    public struct UIInfo
    {
        public UIType type;
        public UIBase ui;
    }
    /// <summary>
    /// UI类型
    /// </summary>
    public enum UIType
    {
        _NONE,
        _MENU,          // 进入游戏主界面
        _GAMEOVER,      // 游戏结束界面
        _INGAME,        // 答题界面
        _CHOOSELEVEL    // 选关界面
    }
    // 所有UI信息
    [SerializeField]
    private UIInfo[] m_UIInfo;
    // 保存已经显示的UI
    [SerializeField]
    private Stack<UIBase> m_UIStack;
    // 当前UI类型
    private UIType m_CurrentType = UIType._NONE;
    // 即将打开UI的类型
    private UIType m_NextType = UIType._NONE;
    void Start () {
        InitUI ();
    }
    #region private funcs
    // 初始化所有UI
    void InitUI()
    {
        foreach (var item in m_UIInfo) {
            if (item.type == UIType._MENU) {
                ShowUI (item.type);
            } else {
                item.ui.gameObject.SetActive (false);
            }
        }
    }
    // 根据UI类型获取UI实例
    UIBase GetUI(UIType type)
    {
        foreach (var item in m_UIInfo) {
            if (item.type == type)
                return item.ui;
        }
        return null;
    }
    // 根据UI实例获取UI类型
    UIType GetType(UIBase ui)
    {
        foreach (var item in m_UIInfo) {
            if (item.ui == ui)
                return item.type;
        }
        return UIType._NONE;
    }
    #endregion
    #region public funcs
    public void ShowUI(UIType type)
    {
        if (type == m_CurrentType) {
            return;
        }
        if (m_CurrentType != UIType._NONE) {
            GetUI (m_CurrentType).HideUI ();
        }
        if (type != UIType._NONE && m_NextType == UIType._NONE) {
            m_NextType = type;
            GetUI (m_NextType).ShowUI ();
        }
        m_CurrentType = m_NextType;
        m_NextType = UIType._NONE;
    }
    public void HideUI(UIType type){ }
    #endregion
}