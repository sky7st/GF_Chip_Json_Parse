using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace GF_CHIP_JSON
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
        private Dictionary<string, string> dictShape;
        private Dictionary<string, string> dictShapeOut;
        private const string r1 = "infinityfrost";
        private const string r2 = "fatalchapters";
        private int validCnt = 0;
        public GFJSON(){
            validCnt = 0;
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
            prop[0] = chip.assist_hit;
            prop[1] = chip.assist_reload;
            prop[2] = chip.assist_damage;
            prop[3] = chip.assist_def_break;
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
            dictShape = new Dictionary<string, string>()
            {
                {"30", "61"}, {"31", "62"}, {"32", "63"},
                { "33", "641"}, {"34", "642"}, {"35", "65"},
                { "36", "66"}, {"37", "67"}, {"38", "68"},
                { "39", "69"}, {"21", "511"}, {"22", "512"},
                { "23", "513"}, {"24", "514"}, {"25", "515"},
                { "26", "516"}, {"27", "517"}, {"28", "518"},
                { "29", "519"}, {"20", "521"}, {"19", "522"},
                { "18", "523"}, {"17", "524"}, {"16", "525"},
                { "15", "526"}, {"14", "527"}, {"13", "528"}, {"12", "529"}
            };

            dictShapeOut = new Dictionary<string, string>()
            {
                {"61", "1"}, {"62", "2"}, {"63", "3"},
                { "641", "41"}, {"642", "42"}, {"65", "5"},
                { "66", "6"}, {"67", "7"}, {"68", "8"},
                { "69", "9"}, {"511", "5"}, {"512", "22"},
                { "513", "21"}, {"514", "32"}, {"515", "31"},
                { "516", "6"}, {"517", "4"}, {"518", "11"},
                { "519", "12"}, {"521", "132"}, {"522", "131"},
                { "523", "120"}, {"524", "112"}, {"525", "111"},
                { "526", "10"}, {"527", "9"}, {"528", "82"}, {"529", "81"}
            };
        }

        public string getShape(GFChip chip)
        {
            string grid_id = chip.grid_id;
            if (dictShape.ContainsKey(grid_id))
                return dictShape[grid_id];
            else
                return "0";
        }
        
        public int getPos(List<GFChip> chips)
        {
            return (int)(chips.Count - 13 * chips.Count / 13 + 1);
        }
        
        public string getAllChips(List<GFChip> chips, bool showInEquip=true)
        {
            validCnt = 0;
            string s = "[" + r1[getPos(chips)] + "!";
            int i = 1;
            foreach (var chip in chips)
            {
                if (!showInEquip)
                    if (chip.squad_with_user_id != "0")
                        continue;
                GFOut ic = new GFOut();
                ic.color = getColor(chip);
                if (getRank(chip) == "5")
                {
                    string grid_num = getGridNumber(chip);
                    if (grid_num == "6")
                        ic.ic_class = "56";
                    else if (grid_num == "5")
                        ic.ic_class = "551";
                    else
                        continue;
                }
                else
                    continue;
                string shape = getShape(chip);
                if (dictShapeOut.ContainsKey(shape))
                    ic.type = dictShapeOut[shape];
                else
                    continue;
                ic.level = chip.chip_level;
                string[] prop = getProperty(chip);
                ic.hit = prop[0];
                ic.reload = prop[1];
                ic.damage = prop[2];
                ic.destroy = prop[3];
                string f = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},1&",
                                        i, ic.color, ic.ic_class, ic.type,
                                        ic.level, ic.hit, ic.reload,ic.damage,
                                        ic.destroy);
                s += f;
                validCnt++;
            }
            s += "?" + r2[getPos(chips)] + "]";
            return s;
        }

        public int getValidCnt()
        {
            return validCnt;
        }
    }
}
