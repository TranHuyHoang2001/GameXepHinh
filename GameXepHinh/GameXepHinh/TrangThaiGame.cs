using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class TrangThaiGame
    {
        private Khoi Khoihientai;

        public Khoi KhoiHienTai
        {
            get => Khoihientai;
            private set
            {
                Khoihientai = value;
                Khoihientai.ThietLapLai(); //set vị tri bắt đầu 


                // Khối bắt đầu di chuyển xuống từ mép trên canvas đen
                for(int i =0; i < 2; i++)       // di chuyển khối xuống 2 hàng
                {
                    Khoihientai.DiChuyen(1, 0);   //tăng rìa hàng lên 1 đẩy khối hiện tại xuống
                    if(!KhoiHopLe())          // nếu khối không hợp lệ thì dịch ngược về
                    {
                        Khoihientai.DiChuyen(-1, 0);
                    }    
                }    
            }

        }

        public HeThongGame HeThongGame { get; }
        public KhoiTiepTheo KhoiTiepTheo { get; }
        public bool KetThucGame { get; private set; }
        public int Diem { get; private set; }  // điểm sẽ tính theo số hàng đã xoá( Phần DatKhoi)
        public Khoi DoiKhoi { get; private set; }
        public bool Doi { get; private set; }
        public TrangThaiGame()
        {
            HeThongGame = new HeThongGame(22, 10);
            KhoiTiepTheo = new KhoiTiepTheo();
            KhoiHienTai = KhoiTiepTheo.LayVaCapNhat(); // đưa khối tiếp theo vào game
            Doi = true;
        }
        // kiem tra khối hiện tại có ở vị trí hợp lệ không
        private bool KhoiHopLe()
        {
            foreach (ViTri v in KhoiHienTai.ViTriCacOVuong()) //chạy từng vị trí các ô vuông của khối hiện tại
            {
                if(!HeThongGame.TrongKhong(v.Hang1, v.Cot1)) //bất kì ô nào bên ngoài lưới hoặc trùng ô khác sẽ return false
                {
                    return false;
                }    
            } 
            return true;     // nếu nó chạy toàn bộ vòng lặp thì return true
        }
        public void doiKhoi()
        {
            if(!Doi)   // nếu không thể đổi ta return không gì cả
            {
                return;
            } 
            if(DoiKhoi == null)
            {
                DoiKhoi = KhoiHienTai;
                KhoiHienTai = KhoiTiepTheo.LayVaCapNhat();
            }
            // nếu có khối ở chỗ đổi thì ta phải đổi khối hiện tại và khối ở chỗ đổi
            else
            {
                Khoi trunggian = KhoiHienTai;
                KhoiHienTai = DoiKhoi;
                DoiKhoi = trunggian;
            }
            Doi = false; //không thể spam 
        }
        //Xoay Khối
        public void XoayKhoiXuoiChieu()
        {
            KhoiHienTai.XoayXuoi();

            if (!KhoiHopLe())
            {
                KhoiHienTai.XoayNguoc();   // nếu không hợp lệ xoay ngược lại
            } 
                
        }

        public void XoayKhoiNguocChieu()
        {
            KhoiHienTai.XoayNguoc();

            if (!KhoiHopLe())
            {
                KhoiHienTai.XoayXuoi();   // nếu không hợp lệ xoay ngược lại
            }
        }
        //di chuyển trái phải
        public void DiChuyenSangTrai()
        {
            KhoiHienTai.DiChuyen(0, -1);

            if (!KhoiHopLe())
            {
                KhoiHienTai.DiChuyen(0, 1);   // nếu không hợp lệ dịch sang phải 1 ô
            }
        }
        public void DiChuyenSangPhai()
        {
            KhoiHienTai.DiChuyen(0, 1);

            if (!KhoiHopLe())
            {
                KhoiHienTai.DiChuyen(0, -1);   // nếu không hợp lệ dịch sang trái 1 ô
            }
        }

        private bool GameKetThuc()
        {
            return !(HeThongGame.HangRong(0) && HeThongGame.HangRong(1)); //1 trong 2 hàng ẩn bên trên không rỗng thì kết thúc game

        }
        //phương thức được gọi khi khối hiện tại không thể di chuyển xuống
        private void DatKhoi()          //Đặt Khối  Khối đã chạm đáy của ma trận lưới
        {
            foreach (ViTri v in KhoiHienTai.ViTriCacOVuong())  //vòng lặp vị trí các ô vuông của khối hiện tại và đặt vị trí trong hệ thống game bằng với id của khối
            {
                HeThongGame[v.Hang1, v.Cot1] = KhoiHienTai.Id;
            }
            Diem += HeThongGame.XoaCacHang();    //xoá các hàng đã đầy, các hàng đã xoá sẽ cộng vào điểm

            if(GameKetThuc())    // kiểm tra game kết thúc
            {
                KetThucGame = true;      // thua game
            }
            else
            {
                KhoiHienTai = KhoiTiepTheo.LayVaCapNhat();  //tiep tuc choi
                Doi = true;
            }
        }

        public void DiChuyenXuong()
        {
            KhoiHienTai.DiChuyen(1, 0);

            if(!KhoiHopLe())
            {
                KhoiHienTai.DiChuyen(-1, 0);
                DatKhoi();   // trong trường hợp khối không thể di chuyển xuống
            }    
        }
        //lấy vị trí và trả số lượng phần tử rỗng ngay dưới nó

        private int O_VuongRoiXuong(ViTri v)
        {
            int Roi = 0;

            while(HeThongGame.TrongKhong(v.Hang1 + Roi + 1,v.Cot1))
            {
                Roi++;
            }
            return Roi;
        }
        //tìm ra bao nhiêu hàng mà khối hiện tại có thể rơi xuống

        public int KhoiRoiXuong()
        {
            int Roi = HeThongGame.Hang;
            foreach(ViTri v in KhoiHienTai.ViTriCacOVuong())
            {
                Roi = System.Math.Min(Roi, O_VuongRoiXuong(v));
            }
            return Roi;
        }
        // di chuyển khối gần đây xuống nhiều hàng nhất có thể và đặt nó trong hệ thống
        public void RoiKhoi()
        {
            KhoiHienTai.DiChuyen(KhoiRoiXuong(), 0);
            DatKhoi();
        }
    }
}
