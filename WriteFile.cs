﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testRecursive
{
    public class WriteFile
    {
        public abstract class FileWriter
        {
            private static readonly string FolderPath = @"C:\Users\rebel\OneDrive\Desktop\";

            protected string FullFilePath;
            protected int SaveCounter;
            protected StringBuilder ContentBuilder;

            protected FileWriter(string fileName)
            {
                FullFilePath = Path.Combine(FolderPath, fileName);
                SaveCounter = 0;
                ContentBuilder = new StringBuilder();
                Initialize();
            }

            private void Initialize()
            {
                if (File.Exists(FullFilePath))
                    File.WriteAllText(FullFilePath, "");
            }

            public void AddContent(string content)
            {
                AppendContent(content);
                SaveIfNeeded();
            }

            public void SaveToFile()
            {
                File.AppendAllText(FullFilePath, ContentBuilder.ToString());
            }

            private void SaveIfNeeded()
            {
                SaveCounter++;
                if (SaveCounter <= 100) return;

                SaveCounter = 0;
                SaveToFile();
                ContentBuilder.Clear();
            }

            protected abstract void AppendContent(string content);
        }

        public class OptimizedFileWriter() : FileWriter(_fileName)
        {
            private const string _fileName = "Sha256.txt";

            protected override void AppendContent(string content)
            {
                ContentBuilder.Append(content);
            }
        }

        public class ErrorFileWriter() : FileWriter(_fileName)
        {
            private const string _fileName = "Sha256-error.txt";

            protected override void AppendContent(string content)
            {
                ContentBuilder.AppendLine(content);
            }
        }
    }
}
