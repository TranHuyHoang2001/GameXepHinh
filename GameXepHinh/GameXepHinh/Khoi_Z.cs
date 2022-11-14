using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class Khoi_Z : Khoi
    {
        private readonly ViTri[][] cacovuong = new ViTri[][]
        {
            //lưu trữ vị trí ô vuông cho 4 trạng thái xoay
            new ViTri[] {new(0,0), new(0,1), new(1,1), new(1,2)},
            new ViTri[] {new(0,2), new(1,1), new(1,2), new(2,1)},
            new ViTri[] {new(1,0), new(1,1), new(2,1), new(2,2)},
            new ViTri[] {new(0,1), new(1,0), new(1,1), new(2,0)},
        };

        public override int Id => 7;
        protected override ViTri RiaBatDau => new ViTri(0, 3);
        protected override ViTri[][] CacOVuong => cacovuong;
    }
}
