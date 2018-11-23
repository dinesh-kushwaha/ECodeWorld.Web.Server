using ECodeWorld.Web.API.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECodeWorld.Web.API.DataMapping
{
    public class FolderDataMapping
    {
        private static Dictionary<DocumentTypesEnum, string[]> GetFoldersDic()
        {
            return new Dictionary<DocumentTypesEnum, string[]>
            {
                {DocumentTypesEnum.AVTAR, new string []{"static","images","avtars" } },
                {DocumentTypesEnum.LOGO,  new string []{"static","images","logos" }},
                {DocumentTypesEnum.BANNER, new string []{"static","images","banners" }},
            };
        }

        public static string GetFolder(DocumentTypesEnum documentTypesEnum)
        {
            var foldersDic = GetFoldersDic();
            var folderParts = foldersDic[documentTypesEnum];
            return Path.Combine(folderParts);
        }

    }
}
