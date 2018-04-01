using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 動態新增元件
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    
        /*下一新增內容
        *按鈕數量擴充至16個
        *新增一次補齊按鈕功能
         */
    public partial class MainWindow : Window
    {
        Button[] b_arr = new Button[16];
        int bt_count=0;


        public MainWindow()
        {
            InitializeComponent();

            //初始化BUTTON陣列
            for (int i = 0; i < b_arr.Length; i++) {
                Button empty = new Button();
                empty.Name = "empty"+Convert.ToString(i);//設定陣列內按鈕名稱
                //empty.
                b_arr[i] = empty;
            }
        }

        public Button setbutton(Button bt,int height,int width,String name,String content) {
            bt.Height = height;
            bt.Width = width;
            bt.Name = name;
            bt.Content = content;
            return bt;
        }
        
        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            Button b1 = new Button();
            
            b1.VerticalAlignment = VerticalAlignment.Top;
            b1.HorizontalAlignment = HorizontalAlignment.Left;

            //新增按鈕，存進陣列
            for (int i = 0; i < b_arr.Length; i++) {
                if (b_arr[i].Name=="empty"+Convert.ToString(i)) {
                    b1 = setbutton(b1,100,100, "bt" + Convert.ToString(i), "按鈕" + (i + 1));
                    b1.Click += new RoutedEventHandler(remove);//按鈕事件=>移除按鈕
                    b_arr[i] = b1;
                    b1.Margin = new Thickness(35 + 115 * (i % 4), 130 + 120 * (i / 4), 0, 0);
                    break;
                }
            }
            
            gr1.Children.Add(b1);//將按鈕加進GRID
            bt_count += 1;//按鈕數量

            if (bt_count == 16)
            {
                bt_add.IsEnabled = false;
            }
            else
            {
                bt_add.IsEnabled = true;
            }
        }

        //按鈕全補
        private void bt_all_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < b_arr.Length; i++) {
                if (b_arr[i].Name == "empty"+Convert.ToString(i)) {
                    b_arr[i].VerticalAlignment = VerticalAlignment.Top;
                    b_arr[i].HorizontalAlignment = HorizontalAlignment.Left;
                    b_arr[i] = setbutton(b_arr[i], 100, 100, "bt" + Convert.ToString(i), "按鈕" + (i + 1));
                    b_arr[i].Click += new RoutedEventHandler(remove);
                    b_arr[i].Margin = new Thickness(35 + 115 * (i % 4), 130 + 120 * (i / 4), 0, 0); ;
                    gr1.Children.Add(b_arr[i]);
                }
            }
        }

        private void remove(object sender, RoutedEventArgs e) {
            bt_count -= 1;
            if (bt_count == 16)
            {
                bt_add.IsEnabled = false;
            }
            else
            {
                bt_add.IsEnabled = true;
            }

            Button b2 = (Button)sender;

            //將被移除的按鈕陣列位置還原
            for (int i = 0; i < b_arr.Length; i++) {
                if (b_arr[i].Name == b2.Name) {
                    b_arr[i].Name = "empty" + Convert.ToString(i);
                }
            }
            gr1.Children.Remove(((Button) sender));//Button sender表被移除的按鈕
        }
    }
}
