using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public abstract class Khoi
    {
        protected abstract ViTri[][] CacOVuong { get; } //cac ô vuông tạo nên khối
        protected abstract ViTri RiaBatDau { get; } //xác định nơi khối được xuất hiện trong lưới
        public abstract int Id { get; } // id phân biệt giữa các khối với nhau

        private int TrangThaiQuay;   //lưu trạng thái quay gần đây

        private ViTri Ria;

        public Khoi()
        {
            Ria = new ViTri(RiaBatDau.Hang1, RiaBatDau.Cot1);
        }

        public IEnumerable<ViTri> ViTriCacOVuong()  //vị trí lưới ánh xạ khối 
        {
            //IEnumerable là một danh sách có các thuộc tính sau:
            //Danh sách chỉ đọc, không được phép thêm/ bớt phần tử
            //Chỉ duyệt một chiều từ đầu tới cuối danh sách.Sử dụng foreach để thực hiện duyệt

            foreach (ViTri v in CacOVuong[TrangThaiQuay])
            {
                yield return new ViTri(v.Hang1 + Ria.Hang1, v.Cot1 + Ria.Cot1);
                //Yield là từ khóa sẽ báo hiệu cho trình biên dịch biết rằng phương thức, toán tử, get mà nó xuất hiện sẽ là một khối lặp.
                //Trình biên dịch sẽ tự động sinh ra một class implement từ IEnumerable, IEnumerator để thể hiện khối lặp đó
            }
        }

        //Xoay khối góc 90 độ theo chiều kim đồng hồ
        public void XoayXuoi()
        {
            TrangThaiQuay = (TrangThaiQuay + 1) % CacOVuong.Length;
        }
        //Xoay khối góc 90 độ theo ngược chiều kim đồng hồ
        public void XoayNguoc()
        {
            if(TrangThaiQuay == 0)
            {
                TrangThaiQuay = CacOVuong.Length - 1;
            }
            else
            {
                TrangThaiQuay--;
            }
        }
        public void DiChuyen(int hang, int cot) // di chuyển bằng cách tăng giảm Rìa hàng và cột
        {
            Ria.Hang1 += hang;
            Ria.Cot1 += cot;
        }

        public void ThietLapLai()
        {
            TrangThaiQuay = 0;
            Ria.Hang1 = RiaBatDau.Hang1;
            Ria.Cot1 = RiaBatDau.Cot1;
        }
    }
}
