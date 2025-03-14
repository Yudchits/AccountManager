using System;
using System.IO;
using System.Reflection;

namespace AccountManager.Application.Context
{
    public sealed class DirectoryContext
    {
        private static readonly DirectoryContext instance = new();

        public static DirectoryContext Instance 
        { 
            get
            {
                return instance;
            }
        }

        public string RootPath { get; private set; }
        public string AppDataPath { get; private set; }

        private DirectoryContext()
        {
            RootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            AppDataPath = Path.Combine(specialFolder, "AccountManager");
        }
    }
}