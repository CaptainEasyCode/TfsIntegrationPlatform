// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System;
using System.IO;
using System.Text;

namespace MigrationTestLibrary
{
    public class TestUtils
    {
        private static string defaultTextReportFolder = "TextReports";
        private static String textReportRoot = Path.Combine(Path.GetTempPath(), defaultTextReportFolder);
        public static String TextReportRoot
        {
            get
            {
                if (!Directory.Exists(textReportRoot))
                {
                    Directory.CreateDirectory(textReportRoot);
                }
                return TestUtils.textReportRoot;
            }
        }

        private static string specialXMLCharacters = "ΤΤΩ Λεμ®¶@◙ﮙ";
        public static string SpecialXMLCharacters
        {
            get { return TestUtils.specialXMLCharacters; }
        }

        private static string invalidXMLCharacters = "";
        public static string InvalidXMLCharacters
        {
            get { return TestUtils.invalidXMLCharacters; }
        }


        public static void DeleteFile(string localPath)
        {
            if (File.Exists(localPath))
            {
                FileAttributes attr = File.GetAttributes(localPath);
                if ((attr & FileAttributes.ReadOnly) != 0)
                {
                    attr &= ~FileAttributes.ReadOnly;
                    File.SetAttributes(localPath, attr);
                }

                File.Delete(localPath);
            }
        }

        public static string CreateRandomFile(string path, int length)
        {
            DeleteFile(path);

            string parentDir = Path.GetDirectoryName(path);
            Directory.CreateDirectory(parentDir);

            using (StreamWriter sw = new StreamWriter(File.OpenWrite(path)))
            {
                sw.Write(GetRandomAsciiString(length));
            }

            return path;
        }

        public static string EditRandomFile(string path)
        {
            if (File.Exists(path))
            {
                FileAttributes atts = File.GetAttributes(path);
                atts &= ~FileAttributes.ReadOnly;

                File.SetAttributes(path, atts);

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(GetRandomAsciiString(100));
                }

                return path;
            }
            else
            {
                return CreateRandomFile(path, 1024);
            }
        }

        public static string GetRandomAsciiString(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            StringBuilder sb = new StringBuilder(length);
            Random rng = new Random();
            for (int i = 0; i < length; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(
                        Math.Floor(26 * rng.NextDouble() + 65))
                    );
                sb.Append(ch);
            }

            return sb.ToString();
        }

        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                string [] files=Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    DeleteFile(file);
                }
                Directory.Delete(path,true);
            }
        }

        public static string EnsureEndsWithSlash(string uriPath)
        {
            if (!uriPath.EndsWith("/"))
            {
                return uriPath + '/';
            }

            return uriPath;
        }

        /// <summary>
        /// Path.Combine for URI paths 
        /// </summary>
        /// <param name="path1">The first path</param>
        /// <param name="path2">The second path</param>
        /// <returns>Combined path</returns>
        public static string URIPathCombine(string path1, string path2)
        {
            return EnsureEndsWithSlash(path1) + path2;
        }
    }
}
