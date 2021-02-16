using System.Collections.Generic;
using UnityEngine;
using System.IO;    // File読み込み用

/// <summary>
/// CSVを読み込むためのクラス
/// </summary>
public class CSVReader : MonoBehaviour
{
    private TextAsset _csvFile;
    private List<string[]> _csvDatas = new List<string[]>(); // CSVの中身を格納するリスト
    [Tooltip("ファイルパスを格納する変数"),FileDesignation,SerializeField] private string _filePath;

    void Start()
    {
        LoadCSV();
        string[] csvLine = GetCsvLine(0);
        List<string[]> csvDatas = GetCsvDatas();
        #if UNITY_EDITOR
        for(int i = 0; i< csvLine.Length; ++i)
        {
            Debug.Log(csvLine[i]);   // 一列目のデータを呼び出し
        }
        for(int i = 0; i < csvDatas.Count; ++i)
        {
            for(int j = 0; j<csvDatas[i].Length; ++j)
                Debug.Log(csvDatas[i][j]);
        }
        #endif

    }

    /// <summary>
    /// CSVファイルの読み込みを行う関数
    /// </summary>
    private void LoadCSV()
    {
        _filePath = Path.GetFileNameWithoutExtension(_filePath);
        _csvFile = Resources.Load(_filePath)as TextAsset;
        StringReader csvReader = new StringReader(_csvFile.text);

        while(csvReader.Peek() > -1)
        {
            string cell = csvReader.ReadLine();
            _csvDatas.Add(cell.Split(','));  // ','を目安にリストに格納していく   
        }
        csvReader.Close();
    }
    
    /// <summary>
    /// 読み込んだCSVのデータをすべて受け渡す関数
    /// </summary>
    /// <returns>CSVデータの中身全ての文字列</returns>
    public List<string[]> GetCsvDatas()
    {
        return _csvDatas;
    }

    /// <summary>
    /// 読み込んだCSVデータの指定列を受け渡す関数
    /// </summary>
    /// <param name="lineNum">行番号</param>
    /// <returns>CSVデータの指定列の文字列</returns>
    public string[] GetCsvLine(int lineNum)
    {
        return _csvDatas[lineNum];
    }

    /// <summary>
    /// 読み込んだCSVの指定されたセルの文字列を受け渡す関数
    /// </summary>
    /// <param name="lineNum">行番号</param>
    /// <param name="columnNum">列番号</param>
    /// <returns></returns>
    public string GetCsvCell(int lineNum, int columnNum)
    {
        return _csvDatas[lineNum][columnNum];
    }
}