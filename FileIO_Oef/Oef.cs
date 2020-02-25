using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace FileIO_Oef
{
    class Oef
    {
        public static void ManageData(string path, string fileName)
        {
            BackEnd.ExtractZip(path, fileName);
            string extractedPath = path + $@"\{fileName}";
            string newDirectory = path + @"\Straten";
            Directory.CreateDirectory(newDirectory);
            Dictionary<int, string> straatNamen = BackEnd.ParseStraatNamen(extractedPath, "WRstraatnamen");

            ////using (StreamWriter sw = new StreamWriter(@$"{newDirectory}\straten.txt"))
            ////{
            ////    foreach (KeyValuePair< int, string> straat in straatNamen)
            ////    {
            ////        sw.WriteLine(straat.Value);
            ////    }
            ////}

            Dictionary<int, List<int>> stratenInGemeente = BackEnd.ParseStratenInGemeente(extractedPath, "StraatnaamID_gemeenteID");

            Dictionary<int, string> gemeenteNamen = BackEnd.ParseGemeenteNaam(extractedPath, "WRGemeentenaam");


            //using (StreamWriter sw = new StreamWriter(@$"{newDirectory}\stratenperGemeente.txt"))
            //{
            //    foreach (KeyValuePair<int, List<int>> pair in stratenInGemeente)
            //    {
            //        if(gemeenteNamen.ContainsKey(pair.Key))
            //        sw.WriteLine(gemeenteNamen[pair.Key]);
            //    }
            //}




            Dictionary<int, string> provincyNamen = BackEnd.ParseProvinyNaam(extractedPath, "ProvincieIDsVlaanderen", "ProvincieInfo");

            Dictionary<int, List<int>> GemeentesInProvincy = BackEnd.ParseGemeentesinProvincy(extractedPath, "ProvincieIDsVlaanderen", "ProvincieInfo");

            foreach (KeyValuePair<int, string> provincy in provincyNamen)
            {
                Directory.CreateDirectory(newDirectory + $@"\{provincy.Value}");
            }

            foreach (KeyValuePair<int, string> gemeente in gemeenteNamen)
            {
                int provincyID = -1;
                foreach (KeyValuePair<int, List<int>> gePropair in GemeentesInProvincy)
                {
                    if (provincyNamen.ContainsKey(gePropair.Key))
                    {
                        foreach (int gemeenteID in gePropair.Value)
                        {
                            if (gemeenteID == gemeente.Key)
                            {
                                provincyID = gePropair.Key;
                            }
                        }
                    }
                }
                if (provincyID != -1)
                {
                    if (!File.Exists(newDirectory + $@"\{provincyNamen[provincyID]}\{gemeente.Value}.txt"))
                    {
                        var file = File.Create(newDirectory + $@"\{provincyNamen[provincyID]}\{gemeente.Value}.txt");

                        file.Close();
                    }

                }

            }

            foreach (KeyValuePair<int, string> straat in straatNamen)
            {
                int provincyIDKept = -1;
                int gemeenteIDKept = -1;

                //find gemeente
                foreach (KeyValuePair<int, List<int>> strGePair in stratenInGemeente)
                {
                    if (gemeenteNamen.ContainsKey(strGePair.Key))
                    {
                        foreach (int straatID in strGePair.Value)
                        {
                            if (straatID == straat.Key)
                            {
                                gemeenteIDKept = strGePair.Key;
                            }
                        }
                    }

                }

                //find provincy

                foreach (KeyValuePair<int, List<int>> gePropair in GemeentesInProvincy)
                {
                    if (provincyNamen.ContainsKey(gePropair.Key))
                    {
                        foreach (int gemeenteID in gePropair.Value)
                        {
                            if (gemeenteID == gemeenteIDKept)
                            {
                                provincyIDKept = gePropair.Key;
                            }
                        }
                    }
                }

                if (provincyIDKept != -1)
                {
                    if (gemeenteIDKept != -1)
                    {
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(newDirectory + $@"\{provincyNamen[provincyIDKept]}", $@"{gemeenteNamen[gemeenteIDKept]}.txt"), true))
                        {
                            outputFile.WriteLine(straat.Value);
                        }
                    }
                }


            }
        }

    }
}
