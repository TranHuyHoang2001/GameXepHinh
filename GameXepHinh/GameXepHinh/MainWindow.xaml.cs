using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameXepHinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] oVuong_Anh = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),   //id0- Khối Rỗng
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),    //id1- Khối I
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),    //id2- Khối J
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),  //id3- Khối L
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),  //id4- Khối O
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),   //id5- Khối S
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),   //id6- Khối T
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative))        //id7- Khối Z
        };
        private readonly ImageSource[] Khoi_Anh = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative))
        };
        private readonly Image[,] DieuKhienAnh; // mảng 2 chiều

        private readonly int DoTreLonNhat = 1000;    // Độ Trễ lớn nhất
        private readonly int DoTreNhoNhat = 75;   // Độ Trễ nhỏ nhất
        private readonly int DoTreGiam = 25;    // Độ trễ giảm

        private TrangThaiGame trangthai_game = new TrangThaiGame();

        public MainWindow()
        {
            InitializeComponent();
            DieuKhienAnh = CaiDatGameCanvas(trangthai_game.HeThongGame);
        }

        private Image[,] CaiDatGameCanvas(HeThongGame heThong)
        {
            Image[,] DieuKhienAnh = new Image[heThong.Hang, heThong.Cot];
            int PhanTuSize = 25;

            for(int h = 0; h < heThong.Hang; h++)
            {
                for(int c = 0; c < heThong.Cot; c++)    //Mỗi vị trí tạo 1 ảnh ddkhien vs độ rộng chiều cao 25px
                {
                    Image dieuKhienAnh = new Image
                    {
                        Width = PhanTuSize,
                        Height = PhanTuSize
                    };
                    // set khoảng cách từ top canvas đến top ảnh = hàng trừ 2 hàng ẩn (không trong canvas) nhân vs phần tử size
                    //vị trí , đếm từ trên xuống dưới, trái sang phải
                    Canvas.SetTop(dieuKhienAnh, (h - 2) * PhanTuSize + 10);  //+ 10px 
                    Canvas.SetLeft(dieuKhienAnh, c * PhanTuSize);
                    GameCanvas.Children.Add(dieuKhienAnh); // biểu đồ của canvas và thêm mảng
                    DieuKhienAnh[h, c] = dieuKhienAnh;

                }    
            }  
            return DieuKhienAnh; // có mảng hai chiều, 1 ảnh cho từng phần tử trong hệ thống game, 2 hàng top để tạo ra khối trên canvas bị ẩn đi

        }

        private void VeHeThong(HeThongGame heThong)
        {
            //lặp các vị trí
            for(int h =0; h < heThong.Hang; h++)
            {
                for(int c = 0; c < heThong.Cot; c++)
                {
                    int id = heThong[h, c]; //mỗi vị trí ta lấy id bắt đầu
                    //set nguồn ảnh ở vị trí sử dụng id
                    DieuKhienAnh[h, c].Opacity = 1;  //độ mờ 
                    DieuKhienAnh[h, c].Source = oVuong_Anh[id];
                }    
            }    
        }
        private void VeKhoi(Khoi khoi)
        {
            foreach (ViTri v in khoi.ViTriCacOVuong())
            {
                DieuKhienAnh[v.Hang1, v.Cot1].Opacity = 1;  // độ mờ khối
                DieuKhienAnh[v.Hang1, v.Cot1].Source = oVuong_Anh[khoi.Id];
            }    
        }

        private void VeKhoiTiepTheo(KhoiTiepTheo khoiTiepTheo)
        {
            Khoi next = khoiTiepTheo.KhoiTiep;
            TiepTheo_Image.Source = Khoi_Anh[next.Id];  //TiepTheo_Image trong xaml design

        }
        private void VeDoiKhoi(Khoi doikhoi)
        {
            if(doikhoi == null)
            {
                Doi_Image.Source = Khoi_Anh[0];  //Khối empty
            }
            else
            {
                Doi_Image.Source = Khoi_Anh[doikhoi.Id];
            }
        }
        //Bóng của các khối đang rơi xuống
        private void VeKhoiBong(Khoi khoi)
        {
            int KhoangCachRoi = trangthai_game.KhoiRoiXuong();

            foreach (ViTri v in khoi.ViTriCacOVuong())
            {
                DieuKhienAnh[v.Hang1 + KhoangCachRoi, v.Cot1].Opacity = 0.25;   // độ mờ
                DieuKhienAnh[v.Hang1 + KhoangCachRoi, v.Cot1].Source = oVuong_Anh[khoi.Id];  //cập nhật source
                //Phần tử nơi khối sẽ rơi xuống đk tìm bằng thêm khoảng cách rơi
            }    
        }
        // vẽ cả hệ thống và khối
        private void Ve(TrangThaiGame trangthai_game)
        {
            VeHeThong(trangthai_game.HeThongGame);
            VeKhoi(trangthai_game.KhoiHienTai);
            VeKhoiBong(trangthai_game.KhoiHienTai);
            VeKhoiTiepTheo(trangthai_game.KhoiTiepTheo);
            VeDoiKhoi(trangthai_game.DoiKhoi);
            DiemText.Text = $"Điểm: {trangthai_game.Diem}";  //DiemText trong Xaml design

        }

        private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await VongLapGame();  //bắt đầu vòng lặp khi canvas được load
        }

      private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

      }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private async Task VongLapGame() 
        {
            Ve(trangthai_game);
            // vòng lặp chạy đến khi game kết thúc
            while(!trangthai_game.KetThucGame) //nếu trạng thái game khác kết thúc thì thực hiện các câu lệnh
            {
                int DoTre = Math.Max(DoTreNhoNhat, DoTreLonNhat - (trangthai_game.Diem * DoTreGiam));
                await Task.Delay(500);  // chờ khối chậm 500 mili giây
                trangthai_game.DiChuyenXuong(); 
                Ve(trangthai_game);  // vẽ lại trạng thái game reload
            }

            GameOverMenu.Visibility = Visibility.Visible; // khi thua game sẽ hiển thị gameovermenu đã thiết kế
            DiemCuoiCungText.Text = $"Điểm: {trangthai_game.Diem}";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(trangthai_game.KetThucGame) //nếu game kết thúc thì ấn key sẽ không làm gì.
            {
                if (e.Key == Key.Enter)
                {
                    ChoiLai_Click(new object(), new RoutedEventArgs());
                }
            } 
            switch (e.Key)
            {
                case Key.Left:
                    trangthai_game.DiChuyenSangTrai();
                    break;
                case Key.Right:
                    trangthai_game.DiChuyenSangPhai();
                    break;
                case Key.Down:
                    trangthai_game.DiChuyenXuong();
                    break;
                case Key.Up:
                    trangthai_game.XoayKhoiXuoiChieu();
                    break;
                case Key.Z:
                    trangthai_game.XoayKhoiNguocChieu();
                    break;
                case Key.X:
                    trangthai_game.doiKhoi();
                    break;
                case Key.Space:
                    trangthai_game.RoiKhoi();
                    break;
                default:
                    return;   // nếu không ấn key trên nó ko làm gì cả.
            }    

            Ve(trangthai_game);
        }

        private async void ChoiLai_Click(object sender, RoutedEventArgs e)
        {
            //tạo trạng thái game mới
            trangthai_game = new TrangThaiGame();
            GameOverMenu.Visibility=Visibility.Hidden; //ẩn Gameovermenu
            await VongLapGame();  //bắt đầu lại vòng lặp game
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            
           
        }
        private async void HuongDan_Click()
        {
            //HuongDan.Visibility = Visibility.Visible;
        }

        private async void OK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
