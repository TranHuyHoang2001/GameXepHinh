using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class Khoi_I : Khoi
    {
        private readonly ViTri[][] cacovuong = new ViTri[][]
        {
            //lưu trữ vị trí ô vuông cho 4 trạng thái xoay
            new ViTri[] {new(1,0), new(1,1), new(1,2), new(1,3)},
            new ViTri[] {new(0,2), new(1,2), new(2,2), new(3,2)},
            new ViTri[] {new(2,0), new(2,1), new(2,2), new(2,3)},
            new ViTri[] {new(0,1), new(1,1), new(2,1), new(3,1)},
        };

        public override int Id => 1;
        protected override ViTri RiaBatDau => new ViTri(-1, 3); // vị trí (-1,3) làm cho khối sinh ra ở giữa hàng trên
        protected override ViTri[][] CacOVuong => cacovuong;  //lưu vi tri 4 trang thai ở trên
    }
}
