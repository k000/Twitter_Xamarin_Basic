using System;

using Xamarin.Forms;

namespace TwetMemo
{
    public class DetailSaveItemPage : ContentPage
    {
        public DetailSaveItemPage(TwItem item)
        {

            TwitterDatabase database = new TwitterDatabase();


            var btnMenu = new StackLayout
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = {
                    new Button {Text = "戻る",
                        Command = new Command(  () => {
                            Navigation.PopModalAsync();
                        })},

                    new Button {Text = "削除する",
                        Command = new Command(  () => {

                         
                            database.DeleteItem(item);
                            DisplayAlert("完了","削除しました","OK");
                            Application.Current.MainPage = new ShowData();
                        })},
                }

            };




            Content = new StackLayout
            {
                Children = {
                    new Label { Text = item.UserName },
                    new Label { Text = item.CreateDay },
                    new Label { Text = item.Text },
                    btnMenu
                }
            };
        }
    }
}

