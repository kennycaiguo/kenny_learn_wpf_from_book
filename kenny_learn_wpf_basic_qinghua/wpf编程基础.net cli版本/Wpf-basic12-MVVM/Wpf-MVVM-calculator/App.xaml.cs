using System.Configuration;
using System.Data;
using System.Windows;
using Wpf_MVVM_calculator.Model;
using Wpf_MVVM_calculator.View;
using Wpf_MVVM_calculator.ViewModel;

namespace Wpf_MVVM_calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender,StartupEventArgs e)
        {
            //创建view窗口
            Window_Simple winSimple = new Window_Simple();
            Window_Simple_Black winBlack = new Window_Simple_Black();
            Window_Simple_3d win3D = new Window_Simple_3d();
            //创建View Model
            VM_Calculator calulator = new VM_Calculator();
            //创建Model
            CalculatorSystem model = new CalculatorSystem();
            //把View Model和Model关联起来
            calulator.CalculatorSystem = model;
            //ViewModel和View关联
            winSimple.DataContext = calulator;
            winBlack.DataContext = calulator;
            win3D.DataContext = calulator;
            //创建view控制窗口,它也是view不过它有控制功能
            Window_SimpleViewManager winMgr = new Window_SimpleViewManager();
            //创建ViewModel管理窗口
            VM_WindowManager vm_windowMgr = new VM_WindowManager();
            //把View管理窗口和ViewModel管理窗口关联起来
            winMgr.DataContext = vm_windowMgr;
            //这个案例比较简单,直接用ViewModel实现逻辑
            vm_windowMgr.views[0] = winSimple;
            vm_windowMgr.views[1] = winBlack;
            vm_windowMgr.views[2] = win3D;
            vm_windowMgr.views[3] = winMgr;
            winMgr.Show();
            vm_windowMgr.ShowAllViews();
        }
    }

}
