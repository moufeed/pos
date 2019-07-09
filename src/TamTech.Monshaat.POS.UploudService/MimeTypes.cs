//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.IO;
//using Microsoft.AspNetCore.StaticFiles;

//public class MimeTypes
//{
//    private static List<string> knownTypes;

//    private static IDictionary<string, string> mimeTypes;

//    [DllImport("urlmon.dll", CharSet = CharSet.Auto)]
//    private static extern UInt32 FindMimeFromData(
//        UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)]
//        string pwzUrl, [MarshalAs(UnmanagedType.LPArray)]
//        byte[] pBuffer, UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)]
//        string pwzMimeProposed, UInt32 dwMimeFlags, ref UInt32 ppwzMimeOut, UInt32 dwReserverd
//    );

//    public static string GetContentType(string fileName)
//    {
//        if (  mimeTypes == null)
//            mimeTypes = new FileExtensionContentTypeProvider().Mappings;
//        if (knownTypes == null )
//             InitializeMimeTypeLists();
//        string contentType = "";
//        string extension = System.IO.Path.GetExtension(fileName).Replace(".", "").ToLower();
//        mimeTypes.TryGetValue(extension, out contentType);
//        if (string.IsNullOrEmpty(contentType) || knownTypes.Contains(contentType))
//        {
//            string headerType = ScanFileForMimeType(fileName);
//            if (headerType != "application/octet-stream" || string.IsNullOrEmpty(contentType))
//                contentType = headerType;
//        }
//        return contentType;
//    }

//    private static string ScanFileForMimeType(string fileName)
//    {
//        try
//        {
//            byte[] buffer = new byte[256];
//            using (FileStream fs = new FileStream(fileName, FileMode.Open))
//            {
//                int readLength = Convert.ToInt32(Math.Min(256, fs.Length));
//                fs.Read(buffer, 0, readLength);
//            }

//            UInt32 mimeType = default(UInt32);
//            FindMimeFromData(0, null, buffer, 256, null, 0, ref mimeType, 0);
//            IntPtr mimeTypePtr = new IntPtr(mimeType);
//            string mime = Marshal.PtrToStringUni(mimeTypePtr);
//            Marshal.FreeCoTaskMem(mimeTypePtr);
//            if (string.IsNullOrEmpty(mime))
//                mime = "application/octet-stream";
//            return mime;
//        }
//        catch (Exception ex)
//        {
//            return "application/octet-stream";
//        }
//    }
//    private static void InitializeMimeTypeLists()
//    {
//        knownTypes = new string[] {
//        "text/plain",
//        "text/html",
//        "text/xml",
//        "text/richtext",
//        "text/scriptlet",
//        "audio/x-aiff",
//        "audio/basic",
//        "audio/mid",
//        "audio/wav",
//        "image/gif",
//        "image/jpeg",
//        "image/pjpeg",
//        "image/png",
//        "image/x-png",
//        "image/tiff",
//        "image/bmp",
//        "image/x-xbitmap",
//        "image/x-jg",
//        "image/x-emf",
//        "image/x-wmf",
//        "video/avi",
//        "video/mpeg",
//        "application/octet-stream",
//        "application/postscript",
//        "application/base64",
//        "application/macbinhex40",
//        "application/pdf",
//        "application/xml",
//        "application/atom+xml",
//        "application/rss+xml",
//        "application/x-compressed",
//        "application/x-zip-compressed",
//        "application/x-gzip-compressed",
//        "application/java",
//        "application/x-msdownload"
//    }.ToList();
//    }

//    }