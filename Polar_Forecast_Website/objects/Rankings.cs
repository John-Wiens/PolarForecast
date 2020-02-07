using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.objects
{
    public class Rankings
    {
        public int teamnumber { get; set; }
        public int rank { get; set; }
        public float opr { get; set; }
        public float powerranking { get; set; }
        public int year { get; set; }

    }
    public class DS_2019 : Rankings
    {
        public int hatches { get; set; }
        public int cargo { get; set; }

    }

   

}