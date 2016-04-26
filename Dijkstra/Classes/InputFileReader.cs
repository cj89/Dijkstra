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
        private int[,] _inputMatrix;
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
            try
            {
                InputCheck();
            }
            catch (Exception e)
            {
                if ("InputFileInfo.Exists" == e.Message)
                {
                    Console.WriteLine("Kérem töltse ki az Input mappában a Graph.txt fájlt!");
                    Console.WriteLine("Ha kész, nyomjon meg egy gombot!");
                    Console.ReadKey();
                }
                else
                {
                    throw;
                }
            }

            try
            {
                FileRead();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void FileRead()
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(_inputFile, FileMode.Open);
                sr = new StreamReader(fs);

                string line = sr.ReadLine();
                string[] lineSplit = line.Split(' ');

                NodeNumber = int.Parse(lineSplit[0]);
                EdgeNumber = int.Parse(lineSplit[1]);
                StartNode = int.Parse(lineSplit[2]);

                line = sr.ReadLine();

                _inputMatrix = new int[EdgeNumber, 3];

                int i = 0;
                while(line != null && i < EdgeNumber)
                {
                    lineSplit = line.Split(' ');            

                    for(int j = 0; j < 3; j++)
                    {
                        _inputMatrix[i, j] = int.Parse(lineSplit[j]);
                    }

                    i++;
                    line = sr.ReadLine();
                }

                sr.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if(sr != null)
                {
                    sr.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
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
