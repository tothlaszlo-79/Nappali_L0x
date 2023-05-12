using imput = Plugin.InputKit.Shared.Controls;

namespace Nappali_L0x;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private async void btStart_Clicked(object sender, EventArgs e)
	{
		slquestions.Children.Clear();
		var data = 
			await TestService.GetTest("http://johanyak.hu/vp");
		for (int i = 0; i < data.Items.Count; i++)
		{
			var rbg = new StackLayout();
			slquestions.Children.Add(rbg);

			rbg.Children.Add(new Label { 
				Text = 
				$"{i + 1}.{data.Items[i].Question}"
			});
			rbg.Children.Add(new RadioButton { 
				Content = new Label { 
					Text = data.Items[i].Answer_1 
				}
			});
            rbg.Children.Add(new RadioButton
            {
                Content = new Label
                {
                    Text = data.Items[i].Answer_2
                }
            });
            rbg.Children.Add(new RadioButton
            {
                Content = new Label
                {
                    Text = data.Items[i].Answer_3
                }
            });
            rbg.Children.Add(new RadioButton
            {
                Content = new Label
                {
                    Text = data.Items[i].Answer_4
                }
            });
			rbg.Children.Add(new Label
			{
				Text = $"{data.Items[i].Key}",
				IsVisible = false
			});
        }




	}

	private void btSubmit_Clicked(object sender, EventArgs e)
	{
		foreach (StackLayout x in slquestions.Children.Cast<StackLayout>())
		{
			for (int i = 1; i < 5; i++)
			{
				var answer = x.Children[i] as RadioButton;
				if (!answer.IsChecked) continue;
				var l = answer.Content as Label;

				if (i.ToString() == ((Label)x.Children[5]).Text)
					l.TextColor = Color.FromArgb("#FF00FF00");
				else
					l.TextColor = Colors.Red;
			}
		}
	}
}

