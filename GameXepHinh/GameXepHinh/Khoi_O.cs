using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class Khoi_O : Khoi
    {
        private readonly ViTri[][] cacovuong = new ViTri[][]
        {
            new ViTri[] { new(0,0), new(0,1), new(1,0), new(1,1) } //Khối 0 xoay 4 trạng thái là giống nhau
        };
        public override int Id => 4;
        protected override ViTri RiaBatDau => new ViTri(0, 4);
        protected override ViTri[][] CacOVuong => cacovuong;
    }
}
