using Microsoft.AspNetCore.Http;

namespace Common.SaveFile
{
    public static class UploadFileExtension
    {
        public static void AddImageAjaxToServer(this IFormFile file, string fileName, string OrginalPath)
        {
            if (file != null)
            {
                if (!Directory.Exists(OrginalPath))
                {
                    Directory.CreateDirectory(OrginalPath);
                }

                string orginalpath = OrginalPath + fileName;

                using (var stream = new FileStream(orginalpath, FileMode.Create))
                {
                    if (!Directory.Exists(orginalpath))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
        }
    }
}
