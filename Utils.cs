using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK {
    public class Utils {

        public static string ReadFileAndEncodeToBase64(string filePath) {
            return Convert.ToBase64String(File.ReadAllBytes(filePath));
        }

        public static int ExtraerArchivosDesdeZipEnBase64(string zipBase64,string outputDir, ExtractExistingFileAction ExtractExistingFileAction = ExtractExistingFileAction.DoNotOverwrite) {
            byte[] zipBytes = Convert.FromBase64String(zipBase64);
            return ExtraerArchivosZipAFolder(zipBytes,outputDir, ExtractExistingFileAction);
        }
        /// <summary>
        /// Extrae archivos de un zip 
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <param name="outputDir"></param>
        /// <param name="ExtractExistingFileAction"></param>
        /// <returns></returns>
        public static int ExtraerArchivosZipAFolder(byte[] bytes, string outputDir, ExtractExistingFileAction ExtractExistingFileAction = ExtractExistingFileAction.DoNotOverwrite) {
            int i = 0;
            using (MemoryStream stream = new MemoryStream(bytes))
            using (ZipFile zip = ZipFile.Read(stream)) {
                Directory.CreateDirectory(outputDir);
               
                if (!Directory.Exists(outputDir)) {
                    throw new ArgumentException("El directorio no existe y no se pudo crear");
                }
                foreach (ZipEntry e in zip) {
                    e.Extract(outputDir, ExtractExistingFileAction);
                    i++;
                }
            }
            return i;
        }
    }
}
