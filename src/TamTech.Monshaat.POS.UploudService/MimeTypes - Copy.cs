using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

public class MimeTypes
{     

    [DllImport("urlmon.dll", CharSet = CharSet.Auto)]
    private static extern UInt32 FindMimeFromData(
        UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)]
        string pwzUrl, [MarshalAs(UnmanagedType.LPArray)]
        byte[] pBuffer, UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)]
        string pwzMimeProposed, UInt32 dwMimeFlags, ref UInt32 ppwzMimeOut, UInt32 dwReserverd
    );
               
    public static string ScanFileForMimeType(Stream stream)
    {

        var fileName = Path.GetTempFileName();     
        try
        {
            using (var fileStream = File.Create(fileName))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }

            byte[] buffer = new byte[256];
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                int readLength = Convert.ToInt32(Math.Min(256, fs.Length));
                fs.Read(buffer, 0, readLength);
            }
            
            UInt32 mimeType = default(UInt32);
            var result =  FindMimeFromData(0, null, buffer, 256, null, 0, ref mimeType, 0);
            IntPtr mimeTypePtr = new IntPtr(mimeType);
            if (result != 0)
            {
                Marshal.FreeCoTaskMem(mimeTypePtr);    
            }
       
            string mime = Marshal.PtrToStringUni(mimeTypePtr);
            Marshal.FreeCoTaskMem(mimeTypePtr);
            if (string.IsNullOrEmpty(mime))
                mime = "application/octet-stream";
            return mime;
        }
        catch (Exception ex)
        {
            return "application/octet-stream";
        }
        finally
        {
            File.Delete(fileName);
        }
    }
   

    }