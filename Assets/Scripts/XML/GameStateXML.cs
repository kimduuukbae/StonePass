using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text;


/// <summary>
/// 주의사항
/// 1. 맥에서 작업시 (아이폰을 선택하셔야 System.IO.fileinfo관련 에러가 안납니다 주의하세요
///     : _FileLocation = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/"; -->
///     : 끝에 "/Documents/"를 꼭넣어줘야합니다(핸드폰에 올릴때에는)
///     : 맥은 맥이지만 PC에서 사용하실때에는 /Document/부분을 삭제 해줘야 저장되 로딩이 가능합니다.
/// </summary>

public class GameStateXML: MonoBehaviour {

   /* The following metods came from the referenced URL */ 
   public static string UTF8ByteArrayToString(byte[] characters) 
   {      
      UTF8Encoding encoding = new UTF8Encoding(); 
      string constructedString = encoding.GetString(characters); 
      return (constructedString); 
   } 
    
   public static byte[] StringToUTF8ByteArray(string pXmlString) 
   { 
      UTF8Encoding encoding = new UTF8Encoding(); 
      byte[] byteArray = encoding.GetBytes(pXmlString); 
      return byteArray; 
   } 
    
   // Here we serialize our UserData object of myData 
   public static string SerializeObject(object pObject,string typeName) 
   { 
      System.Type type = System.Type.GetType(typeName);
	  string XmlizedString = null; 
      MemoryStream memoryStream = new MemoryStream(); 
      XmlSerializer xs = new XmlSerializer(type); 
      XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
      xs.Serialize(xmlTextWriter, pObject); 
      memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
      XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
      return XmlizedString; 
   } 
    
   // Here we deserialize it back into its original form 
   public static object DeserializeObject(string pXmlizedString,string myType) 
   { 
      System.Type type = System.Type.GetType(myType);
	  XmlSerializer xs = new XmlSerializer(type); 
      MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString)); 
//      XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
      return xs.Deserialize(memoryStream); 
   } 
      
	
   public static void CreateXML(string _FileName,string _data)
   {
       string _FileLocation = string.Empty;
       string fileNameBase = string.Empty;
       StreamWriter writer;

#if UNITY_IPHONE
  				fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
    			_FileLocation = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/";                      
                FileInfo t = new FileInfo(_FileLocation+ _FileName);
#else
       _FileLocation = Application.persistentDataPath;// Application.dataPath;       
       FileInfo t = new FileInfo(_FileLocation + "\\" + _FileName);
       
#endif
     	  

      if(!t.Exists) 
      { 
         writer = t.CreateText(); 
      } 
      else 
      { 
         t.Delete(); 
         writer = t.CreateText(); 
      } 
      writer.Write(_data); 
      writer.Close(); 
   } 
	
   public static string LoadXML(string _FileName ) 
   {
       string _FileLocation = string.Empty;
       string fileNameBase = string.Empty;
       StreamReader r; 

#if UNITY_IPHONE
            fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
            _FileLocation = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/";                      
            r = File.OpenText(_FileLocation+ _FileName); 
#else
            _FileLocation = Application.persistentDataPath;// Application.dataPath;
            r = File.OpenText(_FileLocation + "\\" + _FileName); 
#endif
	  
      string _info = r.ReadToEnd();
      r.Close(); 
	  return _info;
   } 
} 