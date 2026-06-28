using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Wpf_MVVM_calculator.Model
{
    public class CalculatorSystem
    {
        class Item
        {
            public enum Type { Number, Symbol }
            public Type myType;
            public string src;
            public double Number
            {
                get { return double.Parse(src); }
                set { src = value.ToString(); }
            }
        }
        public static String Calculator(String input)
        {
            List<string> dts = new List<string>();
            char[] ops = {'+','-','*','/' };
            string temp = "";
            foreach (var v in input)
            {
                if(ops.Contains(v))
                {
                    dts.Add(temp);
                    dts.Add(""+ v);
                    temp = "";
                }
                else
                {
                    temp += v;
                }
            }
            dts.Add(temp);
            List<Item> listItems = new List<Item>();
            foreach (var v in dts) 
            {
                Item item = new Item();
                item.src = v;
                if(ops.Contains(v.FirstOrDefault()))
                {
                    item.myType = Item.Type.Symbol;
                }
                else
                {
                    item.myType = Item.Type.Number;
                }
                listItems.Add(item);
            }
            for (int i = 1; i < listItems.Count; i += 2) 
            { 
                if(listItems[i].src == "*")
                {
                    listItems[i - 1].Number *= listItems[i + 1].Number;
                    listItems[i].src = "+";
                    listItems[i + 1].src = "0";
                } 
                if(listItems[i].src == "/")
                {
                    listItems[i - 1].Number /= listItems[i + 1].Number;
                    listItems[i].src = "+";
                    listItems[i + 1].src = "0";
                }
            }
            double ret = listItems[0].Number;
            for (int i = 1; i < listItems.Count; i += 2) 
            { 
                if(listItems[i].src == "+")
                {
                    ret += listItems[i + 1].Number;
                } 
                if(listItems[i].src == "-")
                {
                    ret -= listItems[i + 1].Number;
                }
               
            } 
            return ret.ToString();
        }
    }
}
