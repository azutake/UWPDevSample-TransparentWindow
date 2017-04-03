using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace UWPDev_TransparentWindow
{
	/// <summary>
	/// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
	/// </summary>
	public sealed partial class MainPage : Page
	{
		Compositor _compositor;
		SpriteVisual _hostSprite;

		public MainPage()
		{
			InitializeComponent();

			_compositor = ElementCompositionPreview
				.GetElementVisual(this).Compositor;

		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			_hostSprite = _compositor.CreateSpriteVisual();
			_hostSprite.Size = new System.Numerics.Vector2(
				(float)grid.ActualWidth,
				(float)grid.ActualHeight);

			ElementCompositionPreview.SetElementChildVisual(
				grid, _hostSprite);

			_hostSprite.Brush = _compositor.CreateHostBackdropBrush();
		}

		private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (_hostSprite != null)
				_hostSprite.Size = e.NewSize.ToVector2();
		}
	}
}
