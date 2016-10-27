using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Prompt
    {
        public string sPromptTitle;
        public List<String> sPromptOptions;
        public int iNumSelectable;
        public Prompt(string sPromptTitle, List<String> sPromptOptions, int iNumSelectable)
        {
            this.sPromptTitle = sPromptTitle;
            this.sPromptOptions = sPromptOptions;
            this.iNumSelectable = iNumSelectable;
        }
    }
}
