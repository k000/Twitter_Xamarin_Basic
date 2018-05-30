using System;
using CoreTweet;

using Xamarin.Forms;

namespace TwetMemo
{
    public class SerchResult : ContentPage
    {
        public SerchResult(string keyword)
        {

            Title = keyword + "：の検索結果";

            var tokens = CoreTweet.Tokens.Create(
                        //ここに自分のトークンなどを指定する
            );

            var result = tokens.Search.Tweets(count => 10, q => keyword);


            ListView listview;
            listview = new ListView { ItemsSource = result, ItemTemplate = new DataTemplate(typeof(TextCell)) };

            listview.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
            listview.ItemTemplate.SetBinding(TextCell.DetailProperty, new Binding("User.ScreenName"));

            listview.ItemTapped += (sender, e) =>
            {
                var item = (CoreTweet.Status)e.Item;
                ///Console.WriteLine(item.Text);
                Navigation.PushModalAsync(new DetailTwtPage(item));

            };

         // var indi = new ActivityIndicator { IsRunning = true };


            Content = new StackLayout
            {
                Children = {
                    new Button {Text = "戻る",
                        Command = new Command(  () => {
                         
                           // IsEnabled = false;
                            //System.Console.WriteLine("call");
                           // Navigation.PushModalAsync(new SerchResult(entry.Text));
                            Application.Current.MainPage = new TwetMemoPage();
                            // Navigation.PushAsync(new SerchResult(entry.Text));
                            //IsEnabled = true;
                           // Navigation.PushAsync(new SerchResult(entry.Text));
                           //.PushAsync(new SerchResult(entry.Text));
                        })},
                    listview
                },

                Padding = new Thickness(0, Device.OnPlatform(20, 0, 20), 0, 0)
            };






        }
    }
}

