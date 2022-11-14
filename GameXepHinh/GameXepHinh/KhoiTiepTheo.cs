using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class KhoiTiepTheo
    {
        //chứa mảng khối 
        private readonly Khoi[] cacKhoi = new Khoi[]
        {
            new Khoi_I(),
            new Khoi_J(),
            new Khoi_L(),
            new Khoi_O(),
            new Khoi_S(),
            new Khoi_T(),
            new Khoi_Z()
        };

        private readonly Random random = new Random();

        public Khoi KhoiTiep { get; private set; }

        //contructor
        public KhoiTiepTheo()
        {
            KhoiTiep = KhoiNgauNhien();
        }
        private Khoi KhoiNgauNhien()
        {
            return cacKhoi[random.Next(cacKhoi.Length)];
        }

        public Khoi LayVaCapNhat()
        {
            Khoi k = KhoiTiep;
            do
            {
                KhoiTiep = KhoiNgauNhien();  // gán khối tiếp với 1 khối random
            }
            while (k.Id == KhoiTiep.Id);
            return k;
        }
    }
}
