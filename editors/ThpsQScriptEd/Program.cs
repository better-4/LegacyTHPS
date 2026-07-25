using System;
using System.IO;
using LegacyThps.QScript;

namespace ThpsQScriptEd
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("ThpsQScriptEd, dcxdemo");

            if (args.Length != 2)
            {
                Console.WriteLine("usage: THPSQScriptEd.exe {input} {output}");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            if (!File.Exists(inputPath)) {
                Console.WriteLine($"file not found: {inputPath}");
                return;
            }

            SymbolCache.Create();
            QBuilder.Init();

            Directory.CreateDirectory(Directory.GetParent(outputPath).FullName);

            switch (Path.GetExtension(args[0].ToUpper()))
            {
                case ".Q":
                    QBuilder.Tokenizer_ParseText(File.ReadAllText(inputPath));
                    QBuilder.Save(outputPath);
                    break;

                case ".QB":
                    QBuilder.ParseFile(inputPath);
                    File.WriteAllText(outputPath, QBuilder.GetSource(false));
                    break;

                default:
                    break;
            }
        }

    }
}
