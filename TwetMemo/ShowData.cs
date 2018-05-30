using System;

using Xamarin.Forms;

namespace TwetMemo
{
    public class ShowData : ContentPage
    {

        readonly TwitterDatabase _db = new TwitterDatabase();

        public ShowData()
        {


            var listview = new ListView
            {
                ItemsSource = _db.GetItems(),
                ItemTemplate = new DataTemplate(typeof(TextCell))

            };


            listview.ItemTemplate.SetBinding(TextCell.TextProperty,"Text");
            listview.ItemTemplate.SetBinding(TextCell.DetailProperty, "UserName");


            listview.ItemTapped += (sender, e) =>
            {
                TwItem item = (TwItem)e.Item;
                Navigation.PushModalAsync(new DetailSaveItemPage(item));
            };
                   



            Content = new StackLayout
            {
                Children = {
                    new Button {Text = "戻る",
                        Command = new Command(  () => {
                            Application.Current.MainPage = new TwetMemoPage();
           
                        })},

                    listview
                }
            };



        }
    }
}

