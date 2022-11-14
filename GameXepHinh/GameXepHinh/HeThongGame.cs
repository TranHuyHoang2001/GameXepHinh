using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameXepHinh
{
    public class HeThongGame
    {
        //hold 2 dimensional array retangle
        private readonly int[,] luoi; //readonly có thể sử dụng giá trị default mà không cần khởi tạo
        //readonly có thể được khởi tạo tại thời điểm khai báo, hoặc trong constructor
        //first dimension is row, second dimension is column
        //creat property for row and column
        public int Hang { get; set; }   //Rows
        public int Cot { get; set; }    //Colums
        //define index x and y array
        public int this[int h, int c]
        {
            get => luoi[h, c];
            set => luoi[h, c] = value;
        }
        public HeThongGame(int hang, int cot)
        {
            Hang = hang;
            Cot = cot;
            luoi = new int[hang, cot];
        }
        public bool KtraTrongLuoi(int h, int c)
        {
            return h >= 0 && h < Hang && c >= 0 && c < Cot;  //lon hon 0 và nho hon so luong hang va cot

        }
        public bool TrongKhong(int h, int c)      //kiem tra phan tu rỗng hay không
        {
            return KtraTrongLuoi(h, c) && luoi[h, c] == 0;
        }

        public bool HangDaDay(int h)       //kiem tra hang đã đầy chưa
        {
            for(int c = 0; c < Cot; c++)
            {
                if(luoi[h, c] == 0)  // nếu hàng có bất ky phan tu nao có gia tri 0 thì tra ve false
                {
                    return false;
                }    
            }  
            return true;
        }

        public bool HangRong(int h)      //kiem tra hang rỗng không
        {
            for(int c = 0; c < Cot; c++)
            {
                if (luoi[h, c] != 0)
                {
                    return false;
                }    
            }
            return true;
        }
        // hàng đã đầy sẽ xoá và hàng bên trên sẽ rơi xuống

        private void XoaHang(int h)
        {
            for(int c =0; c < Cot; c++)
            {
                luoi[h, c] = 0;  //gán giá trị phần tử = 0 emptycell
            }    
        }

        private void RoiXuong(int h, int soHang)
        {
            for(int c =0; c < Cot; c++)
            {
                luoi[h + soHang, c] = luoi[h, c];
                luoi[h, c] = 0;
            }    
        }

        public int XoaCacHang()
        {
            int DaXoa = 0;
            //xoa từ 0 và di chuyển từ hàng dưới lên hàng trên
            for(int h = Hang-1; h >= 0; h--)
            {
                if(HangDaDay(h))  //Kiem Tra hàng đã đầy thì xoá và tăng số lượng xoá
                {
                    XoaHang(h);
                    DaXoa++;
                } 
                else if(DaXoa > 0) //neu hang xoa lon hon 0 thì chuyển hàng trên xuống theo số hàng đã xoá
                {
                    RoiXuong(h, DaXoa);
                }    
            }  
            return DaXoa;

        }
    }
}
