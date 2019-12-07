using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyEventPro
{
    class MyEventArg : EventArgs
    {
        //传递主窗体的数据信息
        public string Text { get; set; }
    }
}
