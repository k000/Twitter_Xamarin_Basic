using Xamarin.Forms;

/*

    構想

    検索する
        一覧を見る
        気になるやつをクリックする
        保存する

    見る
        一覧を表示する
        削除する


 * */




namespace TwetMemo
{
    public partial class TwetMemoPage : ContentPage
    {




        public TwetMemoPage()
        {
            
            //InitializeComponent();
            //Contentにレイアウトをぶちこんでいくぅ
           
            var entry = new Entry{HorizontalOptions = LayoutOptions.FillAndExpand};
           

          //  var indi = new ActivityIndicator { IsRunning = false };



            Content = new StackLayout
            {
                Children = {

                //    indi,

                    entry,

                    /*
                    new Button {Text = "検索する",
                        Command = new Command( () => {
                            IsEnabled = false;
                            System.Console.WriteLine("call");
                           // Navigation.PushModalAsync(new SerchResult(entry.Text));
                            Application.Current.MainPage = new NavigationPage(new SerchResult(entry.Text));
                            //NavigationPage.has
                            // Navigation.PushAsync(new SerchResult(entry.Text));
                            //IsEnabled = true;
                        })},
                    */


                    new Button {Text = "検索する",
                        Command = new Command(  () => {

                            if(string.IsNullOrEmpty(entry.Text)){
                                DisplayAlert("検索ワードを入力してください","検索ワードが未入力です","OK");
                            }else{
                            IsEnabled = false;
                           Application.Current.MainPage = new SerchResult(entry.Text);
                            }

                        })},



                    new Button {Text = "保存データを見る",
                        Command = new Command(  () => {
                          //  indi.IsRunning = true;

                            IsEnabled = false;
                            //System.Console.WriteLine("call");
                           // Navigation.PushModalAsync(new SerchResult(entry.Text));
                            Application.Current.MainPage = new ShowData();
                            // Navigation.PushAsync(new SerchResult(entry.Text));
                            //IsEnabled = true;
                           // Navigation.PushAsync(new SerchResult(entry.Text));
                           //.PushAsync(new SerchResult(entry.Text));
                        })},


                },



                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 20), 0, 0)
            };

        }
    }
}
