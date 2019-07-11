using System.Collections.Generic;
using System.Linq;

namespace TamTech.Monshaat.POS.UploadService.Settings
{
    public class FileTypeSettings
    {
        // This is the file type based on the client "avatars", "chat-item", ...
        public string Type { get; set; }

      //  public string HardcodedEnum { get; set; }

        public string AllowedExtensions { get; set; }
        
        public long MaxSize { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public string FileNamePrefix { get; set; }
         

        public List<string> GetAllowedExtensions()
        {
            return AllowedExtensions.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries).Select(s => s.ToLowerInvariant()).ToList();
        }
    }
}
