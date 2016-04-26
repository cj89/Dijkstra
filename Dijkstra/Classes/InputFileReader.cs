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
        private string _inputFile;

        /// <summary>
        ///Csúcsok száma
        /// </summary>
        public int NodeNumber
        {
            get;
            private set;
        }

        /// <summary>
        ///Élek száma
        /// </summary>
        public int EdgeNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// Start-csúcs
        /// </summary>
        public int StartNode
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
                        Console.WriteLine("Ha kész, nyomjon meg egy gombot!");
                        Console.ReadKey();
                    }
                }
            } while (InputFileInfoError);


            FileRead();

        }

        public void FileRead()
        {
            FileStream fs = new FileStream(_inputFile, FileMode.Open);

            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] lineSplit = line.Split(' ');

            NodeNumber = int.Parse(lineSplit[0]);
            EdgeNumber = int.Parse(lineSplit[1]);
            StartNode = int.Parse(lineSplit[2]);

            line = sr.ReadLine();

            _inputmatrix = new int[EdgeNumber, 3];

            int i = 0;
            while(line != null)
            {
                lineSplit = line.Split(' ');            

                for(int j = 0; j < 3; j++)
                {
                    _inputmatrix[i, j] = int.Parse(lineSplit[j]);
                }

                i++;
                line = sr.ReadLine();
            }

            sr.Close();
            fs.Close();

        }

        /// <summary>
        /// Ellenőrizzük, hogy létezik-e az Input mappa,
        /// illetve az input mappán belül a Graph.txt fájl.
        /// </summary>
        public void InputCheck()
        {
            string InputDirectoryPath = Directory.GetCurrentDirectory() + "\\Input";
            _inputFile = InputDirectoryPath + "\\Graph.txt";

            //Ha nem léteik a könyvtár
            if (false == Directory.Exists(InputDirectoryPath))
            {
                //akkor elkészítjük
                Directory.CreateDirectory(InputDirectoryPath);
            }

            FileInfo InputFileInfo = new FileInfo(_inputFile);

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
