using System;

using Xamarin.Forms;

namespace TwetMemo
{
    public class DetailTwtPage : ContentPage
    {
        //引数で受け取るのは実際にタップした詳細ツイートです
        public DetailTwtPage(CoreTweet.Status item)
        {

            TwitterDatabase database = new TwitterDatabase();

            var btnMenu = new StackLayout
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = {
                    new Button {Text = "戻る",
                        Command = new Command(  () => {
                         
                           // IsEnabled = false;
                            //System.Console.WriteLine("call");
                           // Navigation.PushModalAsync(new SerchResult(entry.Text));
                            Navigation.PopModalAsync();
                            // Navigation.PushAsync(new SerchResult(entry.Text));
                            //IsEnabled = true;
                           // Navigation.PushAsync(new SerchResult(entry.Text));
                           //.PushAsync(new SerchResult(entry.Text));
                        })},
                    
                    new Button {Text = "保存する",
                        Command = new Command(  () => {

                            var twitem = new TwItem{
                                UserName = item.User.ScreenName,
                                CreateDay = item.User.CreatedAt.DateTime.ToString(),
                                Text = item.Text,
                                saveTime = DateTime.Now
                            };

                            database.SaveData(twitem);

                            DisplayAlert("完了","保存しました","OK");


                        })},
                }
                                               
            };



            Content = new StackLayout
            {
                Children = {
                    new Label { Text = item.User.ScreenName },
                    new Label { Text = item.User.CreatedAt.DateTime.ToString()},
                    new Label { Text = item.Text },
                    btnMenu
                },
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 20), 0, 0)
            };





        }
    }
}

