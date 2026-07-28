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
            //     // single copy, ideally would be proper subcommands but cba
            //     if (args.Length != 2)
            //     {
            //         Console.WriteLine("usage: THPSQScriptEd.exe {input} {output}");
            //         return;
            //     }
            //
            //     string inputPath = args[0];
            //     string outputPath = args[1];
            //
            //     if (!File.Exists(inputPath)) {
            //         Console.WriteLine($"file not found: {inputPath}");
            //         return;
            //     }
            //
            //     SymbolCache.Create();
            //     QBuilder.Init();
            //
            //     Directory.CreateDirectory(Directory.GetParent(outputPath).FullName);
            //
            //     switch (Path.GetExtension(inputPath.ToUpper()))
            //     {
            //         case ".Q":
            //             Console.WriteLine($"Compiling {inputPath} to {outputPath}");
            //             QBuilder.Tokenizer_ParseText(File.ReadAllText(inputPath));
            //             QBuilder.Save(outputPath);
            //             break;
            //
            //         case ".QB":
            //             Console.WriteLine($"Decompiling {inputPath} to {outputPath}");
            //             QBuilder.ParseFile(inputPath);
            //             File.WriteAllText(outputPath, QBuilder.GetSource(false));
            //             break;
            //
            //         default:
            //             break;
            //     }
            // }
            // bulk copy, probably more useful - cuts down on cpu time during rebuilds
            if (args.Length != 2)
            {
                Console.WriteLine("usage: THPSQScriptEd.exe {input_dir} {output_dir}");
                return;
            }

            string inputDir = args[0];
            string outputDir = args[1];

            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine($"directory not found: {inputDir}");
                return;
            }

            SymbolCache.Create();
            QBuilder.Init();

            Directory.CreateDirectory(Directory.GetParent(outputDir).FullName);

            foreach (string inputPath in Directory.GetFiles(inputDir)) {
                string outputPath = Path.Join(outputDir, Path.GetFileName(inputPath));

                switch (Path.GetExtension(inputPath.ToUpper()))
                {
                    case ".Q":
                        Console.WriteLine($"Compiling {inputPath} to {outputPath}");
                        QBuilder.Tokenizer_ParseText(File.ReadAllText(inputPath));
                        QBuilder.Save(outputPath);
                        break;

                    case ".QB":
                        Console.WriteLine($"Decompiling {inputPath} to {outputPath}");
                        QBuilder.ParseFile(inputPath);
                        File.WriteAllText(outputPath, QBuilder.GetSource(false));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
