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
        *按鈕數量擴充至16個(陣列用RESIZE方法)
        *新增一次補齊按鈕功能
         */
    public partial class MainWindow : Window
    {
        Button[] b_arr = new Button[5];
        int bt_count=0,temp_i=0;


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
        
        private void bt_add_Click(object sender, RoutedEventArgs e)
        {
            Button b1 = new Button();
            
            b1.Height = 100;
            b1.Width = 100;
            b1.VerticalAlignment = VerticalAlignment.Top;
            b1.HorizontalAlignment = HorizontalAlignment.Left;

            //新增按鈕，存進陣列
            for (int i = 0; i < b_arr.Length; i++) {
                if (b_arr[i].Name=="empty"+Convert.ToString(i)) {
                    b1.Content = "按鈕" + (i+1);
                    b1.Name = "bt" + Convert.ToString(i);
                    b1.Click += new RoutedEventHandler(remove);//按鈕事件=>移除按鈕
                    b_arr[i] = b1;
                    temp_i = i;//暫存i
                    break;
                }
            }

            //利用暫存i來選取按鈕位置
            switch (temp_i) {
                case 0:
                    b1.Margin = new Thickness(35, 130, 0, 0);
                    break;

                case 1:
                    b1.Margin = new Thickness(150, 130, 0, 0);
                    break;

                case 2:
                    b1.Margin = new Thickness(265, 130, 0, 0);
                    break;

                case 3:
                    b1.Margin = new Thickness(380, 130, 0, 0);
                    break;

                case 4:
                    b1.Margin = new Thickness(35, 250, 0, 0);
                    break;
            }
            gr1.Children.Add(b1);//將按鈕加進GRID

            bt_count += 1;//按鈕數量

            /*if (bt_count == 5)
            {
                bt_add.IsEnabled = false;
            }
            else
            {
                bt_add.IsEnabled = true;
            }*/
        }

        private void remove(object sender, RoutedEventArgs e) {
            bt_count -= 1;
            /*if (bt_count == 5)
            {
                bt_add.IsEnabled = false;
            }
            else
            {
                bt_add.IsEnabled = true;
            }*/

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
