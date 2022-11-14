using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class ViTri
    {
        // vi trí các phần tử trong lưới
        public int Hang1 { get; set; }
        public int Cot1 { get; set; }

        //Contructor
        public ViTri(int hang1, int cot1)
        {
            Hang1 = hang1;
            Cot1 = cot1;
        }
    }
}
