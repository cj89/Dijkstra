using System;
using System.IO;

//Dániel Egyed

namespace Dijkstra.Classes
{
    /// <summary>
    /// Input fájl beolvasása
    /// </summary>
    class InputFileReader
    {
        private int[,] _inputmatrix;

        /// <summary>
        ///Csúcsok száma
        /// </summary>
        public int N
        {
            get;
            private set;
        }

        /// <summary>
        /// Start-csúcs
        /// </summary>
        public int S
        {
            get;
            private set;
        }

        public InputFileReader()
        {
            bool InputFileInfoError = false;

            do
            {
                try
                {
                    InputFileInfoError = false;
                    InputCheck();
                }
                catch (Exception e)
                {
                    if ("InputFileInfo.Exists" == e.Message)
                    {
                        InputFileInfoError = true;
                        Console.WriteLine("Kérem töltse ki a Graph.txt fájl!");
                        Console.WriteLine("Ha kész:,nyomjon meg egy gombot");
                        Console.ReadKey();
                    }
                }
            } while (InputFileInfoError);


            FileRead();

        }

        public void FileRead()
        {
           

        }

        /// <summary>
        /// Ellenőrizzük, hogy létezik-e az Input mappa,
        /// illetve az input mappán belül a Graph.txt fájl.
        /// </summary>
        public void InputCheck()
        {
            string InputDirectoryPath = Directory.GetCurrentDirectory() + "\\Input";
            string InputFile = InputDirectoryPath + "\\Graph.txt";

            //Ha nem léteik a könyvtár
            if (false == Directory.Exists(InputDirectoryPath))
            {
                //akkor elkészítjük
                Directory.CreateDirectory(InputDirectoryPath);
            }

            FileInfo InputFileInfo = new FileInfo(InputFile);

            //Ha nem létezik a fájl
            if (false == InputFileInfo.Exists)
            {
                //akkor létrehozzuk
                StreamWriter CreateStreamWriter = InputFileInfo.CreateText();
                CreateStreamWriter.Close();
                throw new Exception("InputFileInfo.Exists");
            }
        }
    }
}
