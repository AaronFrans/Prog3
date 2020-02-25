using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Linq;


namespace FileIO_Oef
{
    class BackEnd
    {
        public static void ExtractZip(string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ZipFile.ExtractToDirectory(path + $@"\{fileName}.zip", path);
        }
        public static Dictionary<int, string> ParseStraatNamen(string path, string fileName)
        {
            Dictionary<int, string> straten = new Dictionary<int, string>();

            List<string[]> lines = FileSplitter(path, fileName, ';');


            foreach (var line in lines)
            {
                int id;
                int.TryParse(line[0], out id);
                if (id > 0)
                {

                    straten.Add(id, line[1].Trim(' ', '"'));
                }

            }

            straten = straten.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            return straten;

        }


        public static Dictionary<int, List<int>> ParseStratenInGemeente(string path, string fileName)
        {
            Dictionary<int, List<int>> stratenInGemeente = new Dictionary<int, List<int>>();
            List<string[]> lines = FileSplitter(path, fileName, ';');
            foreach (var line in lines)
            {
                int gemeenteID, straatID;
                int.TryParse(line[0], out straatID);
                int.TryParse(line[1], out gemeenteID);
                if (gemeenteID > 0)
                {
                    bool isFound = false;
                    if (stratenInGemeente.Count == 0)
                    {

                        stratenInGemeente.Add(gemeenteID, new List<int>() { straatID });

                    }
                    else
                    {
                        foreach (KeyValuePair<int, List<int>> Gemeente in stratenInGemeente)
                        {

                            if (gemeenteID == Gemeente.Key)
                            {
                                isFound = true;
                            }


                        }
                        if (!isFound)
                        {
                            stratenInGemeente.Add(gemeenteID, new List<int>() { straatID });
                        }
                        else
                        {
                            stratenInGemeente[gemeenteID].Add(straatID);
                        }
                    }

                }

            }

            return stratenInGemeente;
        }

        public static Dictionary<int, string> ParseGemeenteNaam(string path, string fileName)
        {
            Dictionary<int, string> gemeente = new Dictionary<int, string>();

            List<string[]> lines = FileSplitter(path, fileName, ';');

            foreach (var line in lines)
            {
                bool isAdded = false;
                if (line[2] == "nl")
                {
                    int id;
                    int.TryParse(line[1], out id);
                    foreach (KeyValuePair<int, string> pair in gemeente)
                    {
                        if (id == pair.Key)
                        {
                            isAdded = true;
                        }
                    }
                    if (isAdded == false)
                        gemeente.Add(id, line[3]);




                }
            }
            gemeente = gemeente.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return gemeente;
        }

        public static Dictionary<int, string> ParseProvinyNaam(string path, string fileName1, string fileName2)
        {
            Dictionary<int, string> provincy = new Dictionary<int, string>();
            List<string[]> lines = FileSplitter(path, fileName1, ',');
            List<int> neededProvincyIDs = new List<int>();
            foreach (var line in lines)
            {
                foreach (string st in line)
                {
                    int.TryParse(st, out int id);
                    neededProvincyIDs.Add(id);
                }
            }

            lines = FileSplitter(path, fileName2, ';');

            foreach (var line in lines)
            {

                int provincyID;
                int.TryParse(line[1], out provincyID);
                if (line[2] == "nl")
                {
                    bool isNeeded = false;
                    foreach (int id in neededProvincyIDs)
                    {
                        if (id == provincyID)
                        {
                            isNeeded = true;
                        }
                    }

                    if (isNeeded)
                    {
                        bool isAdded = false;

                        int id;
                        int.TryParse(line[1], out id);
                        foreach (KeyValuePair<int, string> pair in provincy)
                        {
                            if (id == pair.Key)
                            {
                                isAdded = true;
                            }
                        }
                        if (isAdded == false)
                            provincy.Add(id, line[3]);

                    }
                }
            }
            provincy = provincy.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return provincy;

        }

        public static Dictionary<int, List<int>> ParseGemeentesinProvincy(string path, string fileName1, string fileName2)
        {
            Dictionary<int, List<int>> gemeenteInProvincy = new Dictionary<int, List<int>>();
            List<string[]> lines = FileSplitter(path, fileName1, ',');
            List<int> neededProvincyIDs = new List<int>();
            foreach (var line in lines)
            {
                foreach (string st in line)
                {
                    int.TryParse(st, out int id);
                    neededProvincyIDs.Add(id);
                }
            }

            lines = FileSplitter(path, fileName2, ';');
            foreach (var line in lines)
            {
                int gemeenteID, provincyID;
                int.TryParse(line[1], out provincyID);
                int.TryParse(line[0], out gemeenteID);
                if (provincyID > 0)
                {
                    if (line[2] == "nl")
                    {
                        bool isNeeded = false;
                        foreach (int id in neededProvincyIDs)
                        {
                            if (id == provincyID)
                            {
                                isNeeded = true;
                            }
                        }

                        if (isNeeded)
                        {
                            bool isFound = false;
                            if (gemeenteInProvincy.Count == 0)
                            {

                                gemeenteInProvincy.Add(provincyID, new List<int>() { gemeenteID });

                            }
                            else
                            {
                                foreach (KeyValuePair<int, List<int>> Provincy in gemeenteInProvincy)
                                {

                                    if (provincyID == Provincy.Key)
                                    {
                                        isFound = true;
                                    }


                                }
                                if (!isFound)
                                {
                                    gemeenteInProvincy.Add(provincyID, new List<int>() { gemeenteID });
                                }
                                else
                                {
                                    gemeenteInProvincy[provincyID].Add(gemeenteID);
                                }
                            }
                        }

                    }


                }

            }

            return gemeenteInProvincy;
        }





        public static List<string[]> FileSplitter(string path, string fileName, char delim)
        {
            List<string[]> splitLines = new List<string[]>();
            using (StreamReader reader = new StreamReader(path + $@"\{fileName}.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(delim);
                    splitLines.Add(values);
                }
            }

            return splitLines;

        }




    }
}


