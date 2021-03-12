using UnityEngine;

public class FileDesignationAttribute : PropertyAttribute
{
    public enum FILEEXTENSION
    {
        NONE = 0,
        CSV = 1,
    }
    // 拡張子フィルター
    public FILEEXTENSION _extensionFilter;
}