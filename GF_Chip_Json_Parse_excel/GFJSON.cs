using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace GF_Chip_Json_Parse_excel
{
    public class GFChip
    {
        public string id;
        public string user_id;
        public string chip_id;
        public string chip_exp;
        public string chip_level;
        public string color_id;
        public string grid_id;
        public string squad_with_user_id;
        public string position;
        public string shape_info;
        public string assist_damage;
        public string assist_reload;
        public string assist_hit;
        public string assist_def_break;
        public string damage;
        public string atk_speed;
        public string hit;
        public string def;
        public string is_locked;
    }
    public class GFOut
    {
        public string color;
        public string ic_class;
        public string type;
        public string level;
        public string hit;
        public string reload;
        public string damage;
        public string destroy;
    }

    public class GFJSON
    {
        private string jsPath = "";
        private List<GFChip> chips;
        private Dictionary<string, string> dictExcelShape;

        public GFJSON(){
            setDict();
        }

        public void setPath(string path)
        {
            this.jsPath = path;
        }

        public List<GFChip> parseChip()
        {
            using (StreamReader r = new StreamReader(jsPath))
            {
                chips = new List<GFChip>();
                string json = r.ReadToEnd();
                JObject o = JObject.Parse(json);
                var c = o["chip_with_user_info"];
                o = JObject.Parse(c.ToString());
                foreach (var p in o.Properties())
                {
                    chips.Add(p.Value.ToObject<GFChip>());
                }     
            }
            return chips;
        }
        public string getColor(GFChip chip)
        {
            string color_id = chip.color_id;
            switch (color_id)
            {
                case "1":
                    return "2";
                case "2":
                    return "1";
                default:
                    return "0";
            }
        }

        public string getGridNumber(GFChip chip)
        {
            string chip_id = chip.chip_id;
            if (chip_id.Length != 4)
            {
                return "0";
            }
            switch (chip_id[2])
            {
                case '6':
                    return "6";
                case '5':
                    return "5";
                case '4':
                    return "4";
                case '3':
                    return "3";
                default:
                    return "0";
            }
        }

        public string getKind(GFChip chip)
        {
            string chip_id = chip.chip_id;
            if (chip_id.Length != 4)
            {
                return "0";
            }
            switch (chip_id[3])
            {
                case '1':
                    return "2";
                case '2':
                    return "1";
                default:
                    return "0";
            }
        }

        public string[] getProperty(GFChip chip)
        {
            string[] prop = { "", "", "", "" };
            prop[0] = chip.assist_damage;
            prop[1] = chip.assist_def_break;
            prop[2] = chip.assist_hit;
            prop[3] = chip.assist_reload;
            return prop;
        }

        public string getRank(GFChip chip)
        {
            string chip_id = chip.chip_id;
            if (chip_id.Length != 4)
            {
                return "0";
            }
            switch (chip_id[0])
            {
                case '2':
                    return "2";
                case '3':
                    return "3";
                case '4':
                    return "4";
                case '5':
                    return "5";
                default:
                    return "0";
            }
        }

        private void setDict()
        {
            dictExcelShape = new Dictionary<string, string>() {
                { "3", "tr1"}, { "4", "tr2"}, { "5", "t1"}, { "6", "t2"},
                { "7", "t3a"}, { "8", "t3b"}, { "9", "t4a"}, { "10", "t4b"},
                { "11", "t5"}, { "12", "pb"}, { "13", "pa"}, { "14", "i"},
                { "15", "u"}, { "16", "za"}, { "17", "zb"}, { "18", "v"},
                { "19", "la"}, { "20", "lb"}, { "21", "w"}, { "22", "nb"},
                { "23", "na"}, { "24", "yb"}, { "25", "ya"}, { "26", "x"},
                { "27", "t"},  { "28", "fa"}, { "29", "fb"}, { "30", "1"},
                { "31", "2"}, { "32", "3"}, { "33", "4a"}, { "34", "4b"},
                { "35", "5"}, { "36", "6"}, { "37", "7"}, { "38", "8"}, { "39", "9"}
            };
        }
        
        public List<string[]> getExcelChip(List<GFChip> chips, bool showInEquip = false, bool colorBlue = true, bool isShow34 = false)
        {
            List<string[]> chip_out = new List<string[]>();
            foreach(var chip in chips)
            {
                if (!showInEquip && chip.squad_with_user_id != "0")
                    continue;
                if (getRank(chip) != "5")
                    continue;

                string color = getColor(chip);
                if ( (colorBlue && color != "1") || (!colorBlue) && color != "2")
                    continue;
                string gridNum = getGridNumber(chip);
                if(gridNum != "6" && gridNum != "5")
                    if (!isShow34 || (isShow34 && (gridNum != "4" && gridNum != "3") ) )
                        continue;

                string kind = getKind(chip);
                string chip_level = chip.chip_level;
                string gridId = chip.grid_id;

                string[] prop = getProperty(chip);
                string[] output = getPropertyVal(gridId, gridNum, kind, chip_level, prop);
                chip_out.Add(output);
            }
            return chip_out;
        }

        public string[] getPropertyVal(string grid_id, string gridNum, string kind, string chip_level, string[] prop)
        {
            string[] output = {"" ,"", "", "", "", "" };
            int chip_level_i = Int32.Parse(chip_level);
            output[0] = dictExcelShape[grid_id];
            output[1] = chip_level;
            double[] baseVal = { 4.4, 12.7, 7.1, 5.7 };
            double gridCorrection = 0.0;
            double strengCorrection = 0.0;
            switch (gridNum)
            {
                case "6":
                    gridCorrection = 1;
                    break;
                case "5":
                    if(kind == "1" )
                        gridCorrection = 1;
                    else
                        gridCorrection = 0.92;
                    break;
                case "4":
                    gridCorrection = 0.8;
                    break;
                case "3":
                    gridCorrection = 0.76;
                    break;
                default:
                    gridCorrection = 0;
                    break;
            }

            if (chip_level_i <= 10)
                strengCorrection = 1.0 + 0.08 * chip_level_i;
            else
                strengCorrection = 1.8 + 0.07 * (chip_level_i-10);

            for (int i = 0; i <= 3; i++)
            {
                int propgridNum =  Int32.Parse(prop[i]);
                double ouput_i = Math.Ceiling(propgridNum * baseVal[i] * gridCorrection);
                ouput_i = Math.Ceiling(ouput_i * strengCorrection);
                output[i+2] = Convert.ToString((int)ouput_i);
            }
            return output;
        }
    }
}
